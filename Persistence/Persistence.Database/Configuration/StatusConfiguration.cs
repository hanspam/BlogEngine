using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class StatusConfiguration
    {
        public StatusConfiguration(EntityTypeBuilder<Status> entityTypeBuilder) {
            entityTypeBuilder.HasIndex(x => x.StatusId);
        }
    }
}
