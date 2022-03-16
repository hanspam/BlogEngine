using MediatR;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventHandler.Commands
{
    public class CommentCreateCommand : INotification
    {
        public int UserId { get; set; }

        public int PostId { get; set; }

        public string? Annotation { get; set; }
    }
}
