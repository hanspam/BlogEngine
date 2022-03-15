using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UserRol { get; set; }
    }
}
