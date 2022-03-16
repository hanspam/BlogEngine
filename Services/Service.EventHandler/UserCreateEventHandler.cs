using MediatR;
using Models.Domain;
using Persistence.Database;
using Service.EventHandler.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventHandler
{
    public class UserCreateEventHandler : INotificationHandler<UserCreateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserCreateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            await _applicationDbContext.AddAsync(new User
            {
                Name = command.Name,
                LastName = command.LastName,
                UserRol = command.UserRol,
                CreatedDate = command.CreatedDate,
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
