using MediatR;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventHandler.Commands
{
    public class PostCreateCommand : INotification
    {
        public int UserId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public int StatusId { get; set; }

        public DateTime Created { get; set; }
    }
}
