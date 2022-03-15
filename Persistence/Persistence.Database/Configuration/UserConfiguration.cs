using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.UserId);
            entityTypeBuilder.Property(x => x.Name).IsRequired();
            entityTypeBuilder.Property(x => x.LastName).IsRequired();
        }
    }
}
