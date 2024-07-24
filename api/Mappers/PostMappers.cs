using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Post;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class PostMappers
    {
        public static ReturnPostDto  ToPostDtoFromGet( this Post postModel, UserForPostDto userDto) {



            return new ReturnPostDto {
                Id = postModel.Id,
                Message = postModel.Message,
                Owner = userDto,
                Date = postModel.Date,
                Image = postModel.Image,
            };      
        }

        //
        public static Post ToPostFromCreateDto(this CreatePostDto postDto, User owner) {

            return new Post {

                Message = postDto.Message,
                OwnerId = postDto.OwnerId,
                Owner = owner,
                Date = DateTime.Now,
                Image = postDto.Image,
            };
        }
    }
}
/*
      public int Id { get; set; }
        public String? Message { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? Date { get; set; }
        public String? Image { get; set; }
*/