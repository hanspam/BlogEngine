using MediatR;
using Persistence.Database;
using Service.EventHandler.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EventHandler
{
    public class PostUpdateEventHandler : INotificationHandler<PostUpdateCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostUpdateEventHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        async Task INotificationHandler<PostUpdateCommand>.Handle(PostUpdateCommand command, CancellationToken cancellationToken)
        {
            var status = _applicationDbContext.Status.Where(x => x.StatusId == command.Status.StatusId).FirstOrDefault();

            var user = _applicationDbContext.Users.Where(x => x.UserId == command.User.UserId).FirstOrDefault();

            var post = _applicationDbContext.Posts.Where(x => x.PostId == command.PostId).FirstOrDefault();
            
            //test
            post.User = user;
            post.Title = command.Title;
            post.Content = command.Content;
            post.Status = status;

            await _applicationDbContext.SaveChangesAsync();

        }
    }
}
