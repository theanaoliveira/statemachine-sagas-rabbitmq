using Sample.Sagas.Domain.Transfer;

namespace Sample.Sagas.Application.Repositories.Database
{
    public interface IFileTransferRepository
    {
        void Add(List<FileTransfer> fileTransfers);
    }
}
