using Sample.Sagas.Domain.Transfer;

namespace Sample.Sagas.Application.Repositories.Services
{
    public interface IFileConvert
    {
        List<FileTransfer> ConvertCsv(string file);
    }
}
