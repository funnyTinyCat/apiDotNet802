using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Post;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDBContext _context;
        
        public PostRepository(ApplicationDBContext context) {

            this._context = context;
        }

        public async Task<Post> CreateAsync(CreatePostDto postDto)
        {
            Post post = new Post();

            post.Date = DateTime.Now;
            post.Image = null;
            post.Message = postDto.Message;
            post.OwnerId = postDto.OwnerId;

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }
    }
}