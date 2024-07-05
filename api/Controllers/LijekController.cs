using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Dtos.Lijek;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace api.Controllers
{
    [ApiController]
    [Route("api/lijek")]
    public class LijekController : ControllerBase
    {
        private readonly ILijekRepository _lijekRepo;
        private readonly IFileService _fileService;
        private readonly ILogger<LijekController> _logger;

        public LijekController(ILijekRepository lijekRepo, IFileService fileService,
            ILogger<LijekController> logger)
        {
            this._lijekRepo = lijekRepo;
            this._fileService = fileService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            // if(!ModelState.IsValid)
            //      return BadRequest(ModelState);

            var lijekovi = await _lijekRepo.GetAllAsync();

            var returnLijekDto = lijekovi.Select(s => s.ToLijekFromGet());

            return Ok(returnLijekDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var lijek = await _lijekRepo.GetByIdAsync(id);

            if (lijek == null) {
                return NotFound();
            }

            return Ok(lijek.ToLijekFromGet());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateLijekDto lijekDto) {

//            if(!ModelState.IsValid)
//                return BadRequest(ModelState);

            try{

                if (lijekDto.Slika?.Length > 5 * 1024 * 1024) {

                    return StatusCode(StatusCodes.Status400BadRequest, 
                                "File size shouldn't exceed 5 MB.");
                }

                string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];

                // allow to save data if SlikaUpload is null?
                string createdImageName = "";
                byte[]? fileByte = null;

                if (lijekDto.SlikaUpload != null) {

                    createdImageName = await _fileService.SaveFileAsync(lijekDto.SlikaUpload, allowedFileExtensions);
                    // convert IFromFile to byte[]?
                    fileByte = await _fileService.ConvertFromFileToByteArrAsync(lijekDto.SlikaUpload);
                }

                if(await _lijekRepo.CheckSifraUniquenessAsync(lijekDto.Sifra, 0, "create")) {

                    return StatusCode(StatusCodes.Status400BadRequest, 
                    "Postoji već ista šifra.");
                }


                lijekDto.SlikaNaziv = createdImageName;
                lijekDto.Slika = fileByte;                

                var lijekModel = lijekDto.ToLijekFromCreate();

                await _lijekRepo.CreateAsync(lijekModel);

                return CreatedAtAction(nameof(GetById), new {id = lijekModel.Id}, lijekModel.ToLijekDto());


            } catch(Exception ex) {

                _logger.LogError(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, 
            [FromForm] UpdateLijekDto lijekDto) {

            try {

                var existingLijek = await _lijekRepo.GetByIdAsync(id);

                if(existingLijek == null) {

                    return StatusCode(StatusCodes.Status404NotFound, 
                        $"Product with id {id} is not found.");
                }

                string? oldImageNaziv = existingLijek.SlikaNaziv;
                
                if(lijekDto.SlikaUpload != null) {

                    if(lijekDto.SlikaUpload.Length > 5 * 1024 * 1024) {

                        return StatusCode(StatusCodes.Status400BadRequest, 
                        "File size shouldn't exceed 5 MB.");
                    }

                    string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];

                    string createdImageName = await _fileService.SaveFileAsync(lijekDto.SlikaUpload, 
                     allowedFileExtensions);

                    lijekDto.SlikaNaziv = createdImageName;

                    // change byte[] Slika database field?
                    byte[] fileByte = await _fileService.ConvertFromFileToByteArrAsync(lijekDto.SlikaUpload);                    

                    lijekDto.Slika = fileByte;
                }

              // delete old slika file
                if ((lijekDto.SlikaUpload != null) && (!oldImageNaziv.IsNullOrEmpty()))
                    _fileService.DeleteFile(oldImageNaziv);


                if(await _lijekRepo.CheckSifraUniquenessAsync(lijekDto.Sifra, id, "update")) {

                    return StatusCode(StatusCodes.Status400BadRequest, 
                    "Postoji već ista šifra.");
                }


              var lijek = await _lijekRepo.UpdateAsync(id, lijekDto.ToLijekFromUpdate()); 

                if (lijek == null) {

                    return NotFound("Lijek not found.");
                }

                return Ok(lijek.ToLijekDto());                

            } catch (Exception ex) {

                _logger.LogError(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingLijek = await _lijekRepo.GetByIdAsync(id);

            if (existingLijek == null) {

                return StatusCode(StatusCodes.Status404NotFound, 
                        $"Product with id {id} is not found.");
            }

            if (!existingLijek.SlikaNaziv.IsNullOrEmpty())
                _fileService.DeleteFile(existingLijek.SlikaNaziv);

            var lijekModel = await _lijekRepo.DeleteAsync(id);

            if (lijekModel == null) {

                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("image/{id:int}")]
        public async Task<IActionResult> UpdateImage([FromRoute] int id, [FromForm] LijekImageDto lijekImage) {

            try {

                var existingLijek = await _lijekRepo.GetByIdAsync(id);

                if(existingLijek == null) {

                    return StatusCode(StatusCodes.Status404NotFound, 
                        $"Product with id {id} is not found.");
                }

                string? oldImageNaziv = existingLijek.SlikaNaziv;
                
 //               if(image != null) {

                    if(lijekImage.SlikaUpload.Length > 5 * 1024 * 1024) {

                        return StatusCode(StatusCodes.Status400BadRequest, 
                        "File size shouldn't exceed 5 MB.");
                    }

                    string[] allowedFileExtensions = [".jpg", ".jpeg", ".png"];

                    string createdImageName = await _fileService.SaveFileAsync(lijekImage.SlikaUpload, 
                     allowedFileExtensions);

                    //lijekDto.SlikaNaziv = createdImageName; - vidjeti šta sa ovim?

                    // change byte[] Slika database field?
                    byte[] fileByte = await _fileService.ConvertFromFileToByteArrAsync(lijekImage.SlikaUpload);                    

           //         lijekDto.Slika = fileByte; - i šta sa oim?
   //             }

              // delete old slika file
                if ((lijekImage.SlikaUpload != null) && (!oldImageNaziv.IsNullOrEmpty()))
                    _fileService.DeleteFile(oldImageNaziv);

  
              var lijekImageDto = await _lijekRepo.UpdateImageAsync(id, fileByte, createdImageName); 

                if (lijekImageDto == null) {

                    return NotFound("Nije dobro kreirana nova slika.");
                }

                

                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(lijekImageDto.ReturnLijekImage());

                return Ok(jsonData);

            } catch (Exception ex) {

                _logger.LogError(ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

    }
}