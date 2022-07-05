using Sample.Sagas.Domain;

namespace Sample.Sagas.Application.Repositories.Database
{
    public interface IFileRepository
    {
        void Add(Domain.File file);
        void UpdateStatus(Guid fileId, FileStatus status);
    }
}
