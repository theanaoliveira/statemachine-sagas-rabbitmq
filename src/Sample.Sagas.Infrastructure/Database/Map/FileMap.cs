using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sample.Sagas.Infrastructure.Database.Map
{
    public class FileMap : IEntityTypeConfiguration<Domain.File>
    {
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            builder.ToTable("File");
            builder.HasKey(k => k.Id);
        }
    }
}
