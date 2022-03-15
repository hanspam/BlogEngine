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
    public class CommentCreateEventHandler : INotificationHandler<CommentCreateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentCreateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(CommentCreateCommand command, CancellationToken cancellationToken)
        {
            await _applicationDbContext.AddAsync(new Comment
            {
                CommentId = command.CommentId,
                User = command.User,
                Post = command.Post,
                Annotation = command.Annotation,
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
