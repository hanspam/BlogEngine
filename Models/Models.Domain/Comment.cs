using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }

        public User? User { get; set; }

        public Post? Post { get; set; }

        public string? Annotation { get; set; }
    }
}
