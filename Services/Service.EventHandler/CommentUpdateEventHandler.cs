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
    public class CommentUpdateEventHandler : INotificationHandler<CommentUpdateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentUpdateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        async Task INotificationHandler<CommentUpdateCommand>.Handle(CommentUpdateCommand command, CancellationToken cancellationToken)
        {
            var user = _applicationDbContext.Users.Where(x => x.UserId == command.User.UserId).FirstOrDefault();

            var post = _applicationDbContext.Posts.Where(x => x.PostId == command.Post.PostId).FirstOrDefault();

            var comment = _applicationDbContext.Comments.Where(x => x.CommentId == command.CommentId).FirstOrDefault();

            comment.CommentId = command.CommentId;
            comment.Annotation = command.Annotation;
            comment.Post = post;
            comment.User = user;

            await _applicationDbContext.SaveChangesAsync();

        }
    }
}
