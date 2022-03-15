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
    public class UserQueryService : IUserQueryService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserQueryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var collection = await _applicationDbContext.Users.ToListAsync();

            return collection.MapTo<List<UserDto>>();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            return (await _applicationDbContext.Users.SingleAsync(x => x.UserId == id)).MapTo<UserDto>();
        }
    }
}
