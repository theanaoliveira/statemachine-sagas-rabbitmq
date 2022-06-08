using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Sagas.Domain.Transfer;

namespace Sample.Sagas.Infrastructure.Database.Map
{
    public class FileTransferMap : IEntityTypeConfiguration<FileTransfer>
    {
        public void Configure(EntityTypeBuilder<FileTransfer> builder)
        {
            builder.ToTable("FileTransfer");
            builder.HasKey(x => x.Id);
        }
    }
}
