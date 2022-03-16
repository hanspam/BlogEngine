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
            var users = _applicationDbContext.Users.Where(x => x.UserId == command.UserId).FirstOrDefault();

            var posts = _applicationDbContext.Posts.Where(x => x.PostId == command.PostId).FirstOrDefault();

            await _applicationDbContext.AddAsync(new Comment
            {
                User = users,
                Post = posts,
                Annotation = command.Annotation,
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
