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
            await _applicationDbContext.AddAsync(new Post
            {
                Content = command.Content,
                User = command.UserId,
                Created = command.Created,
                Title = command.Title,
                Status = command.StatusId,
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
