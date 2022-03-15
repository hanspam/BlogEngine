using Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{
    public interface IUserQueryService
    {
        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> GetAsync(int id);
    }
}
