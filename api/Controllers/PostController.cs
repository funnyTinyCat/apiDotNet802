using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Message;
using api.Dtos.Post;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepo;
        private readonly IUserRepository _userRepo;

        public PostController(IPostRepository postRepo, IUserRepository userRepo) {

            this._postRepo = postRepo;
            this._userRepo = userRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var posts =  await _postRepo.GetAllAsync();

            List<ReturnPostDto> returnPostDtos = new List<ReturnPostDto>();

            foreach( Post post in posts) {

                var ownerDto =  await _userRepo.GetUserForPostAsync(post.OwnerId);

                if (ownerDto == null) {

                    return NotFound("Owner not found.");
                }

                returnPostDtos.Add(post.ToPostDtoFromGet(ownerDto));
            }

   //         var returnPostDtos = posts.Select(s => s.ToPostDtoFromGet( await _userRepo.GetUserForPostAsync(s.OwnerId)));

            MessagePostDto message = new MessagePostDto();

            message.Message = "Success!";
            message.Data = returnPostDtos.ToList<ReturnPostDto>();

            return Ok(message);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {

       //     if(!ModelState.IsValid)
       //        return BadRequest(ModelState);

            var post = await _postRepo.GetByIdAsync(id);

            if (post == null) {
                return NotFound("Post was not found.");
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDto postDto) 
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _postRepo.CreateAsync(postDto)) {



            }



            return Ok()

        }
    }
}