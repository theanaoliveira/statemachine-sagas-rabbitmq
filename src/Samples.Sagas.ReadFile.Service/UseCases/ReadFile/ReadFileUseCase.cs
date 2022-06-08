using MassTransit;
using Sample.Sagas.Application.Repositories.Services;
using Samples.Sagas.ReadFile.Service.Masstransit.Contracts;

namespace Samples.Sagas.ReadFile.Service.UseCases.ReadFile
{
    public class ReadFileUseCase : IReadFileUseCase
    {
        private readonly IFileConvert fileConvert;
        private readonly IBus bus;

        public ReadFileUseCase(IFileConvert fileConvert, IBus bus)
        {
            this.fileConvert = fileConvert;
            this.bus = bus;
        }

        public async Task Execute(ReadFileRequest request)
        {
            request.FileTransfers = fileConvert.ConvertCsv(request.File.FilePath);

            for (var i = 0; i < request.FileTransfers.Count; i++)
            {
                request.FileTransfers[i].SetFileId(request.File.FileId);
                await bus.Publish<ILineSubmitted>(new { FileId = request.File.FileId, LineId = request.FileTransfers[i].Id });
            }
        }
    }
}
