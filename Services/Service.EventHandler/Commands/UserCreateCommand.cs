using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventHandler.Commands
{
    public class UserCreateCommand : INotification
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UserRol { get; set; }
    }
}
