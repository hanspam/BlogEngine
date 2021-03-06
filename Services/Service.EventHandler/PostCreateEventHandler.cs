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
    public class PostCreateEventHandler : INotificationHandler<PostCreateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostCreateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(PostCreateCommand command, CancellationToken cancellationToken)
        {
            var users = _applicationDbContext.Users.Where(x => x.UserId == command.UserId).FirstOrDefault();

            var status = _applicationDbContext.Status.Where(x => x.StatusId == command.StatusId).FirstOrDefault();

            await _applicationDbContext.AddAsync(new Post
            {
                Content = command.Content,
                User = users,
                Created = command.Created,
                Title = command.Title,
                Status = status,
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
