using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrator.Configuration.Persist
{
    public class MigrationStateMap : SagaClassMap<MigrationState>
    {
        protected override void Configure(EntityTypeBuilder<MigrationState> entity, ModelBuilder model)
        {
            base.Configure(entity, model);  
        }
    }
}
