using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Post
    {
        public int PostId { get; set; }

        public User? User { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public Status? Status { get; set; }

        public DateTime Created { get; set; }
    }
}
