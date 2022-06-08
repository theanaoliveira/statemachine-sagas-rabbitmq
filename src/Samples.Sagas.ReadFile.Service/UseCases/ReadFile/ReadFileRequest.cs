using Sample.Sagas.Domain.Transfer;
using Samples.Sagas.ReadFile.Service.Masstransit.Contracts;

namespace Samples.Sagas.ReadFile.Service.UseCases.ReadFile
{
    public class ReadFileRequest
    {
        public Masstransit.Contracts.File File { get; private set; }
        public List<FileTransfer> FileTransfers { get; set; }
        public IEnumerable<ILineSubmitted> LineSubmitteds { get; set; }

        public ReadFileRequest(Masstransit.Contracts.File file)
        {
            File = file;
            FileTransfers = new List<FileTransfer>();
            LineSubmitteds = new List<ILineSubmitted>();
        }
    }
}
