using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UserRol { get; set; } 

    }
}
