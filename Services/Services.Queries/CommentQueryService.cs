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
    public class CommentQueryService : ICommentQueryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<CommentDto>> GetAllAsync()
        {
            return (await _applicationDbContext.Comments.ToListAsync()).MapTo<List<CommentDto>>();

        }

        public async Task<CommentDto> GetAsync(int id)
        {
            return (await _applicationDbContext.Comments.SingleAsync(x => x.CommentId == id)).MapTo<CommentDto>();
        }
    }
}
