using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }

        public UserDto? User { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public StatusDto? Status { get; set; }

        public DateTime Created { get; set; }
    }
}
