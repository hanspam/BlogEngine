using Common.Mapping;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class PostQueryService : IPostQueryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostQueryService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<PostDto>> GetAllAsync() 
        {
            var collection = await _applicationDbContext.Posts.ToListAsync();

            return collection.MapTo<List<PostDto>>();
        }

        public async Task<PostDto> GetAsync(int id)
        {
            return (await _applicationDbContext.Posts.SingleAsync(x => x.PostId == id)).MapTo<PostDto>();
        }
    }
}
