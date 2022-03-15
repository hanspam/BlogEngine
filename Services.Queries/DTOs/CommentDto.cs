using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public UserDto? User { get; set; }

        public PostDto? Post { get; set; }

        public string? Annotation { get; set; }
    }
}
