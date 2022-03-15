using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class CommentConfiguration
    {
        public CommentConfiguration(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.CommentId);
        }
    }
}
