using Sample.Sagas.Application.Repositories.Database;
using Sample.Sagas.Domain;

namespace Sample.Sagas.Infrastructure.Database.Repositories
{
    internal class FileRepository : IFileRepository
    {
        public void Add(Domain.File file)
        {
            
        }

        public void UpdateStatus(Guid fileId, FileStatus status)
        {
            
        }
    }
}
