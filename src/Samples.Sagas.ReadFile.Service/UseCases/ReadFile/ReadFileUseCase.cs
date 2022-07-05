using MassTransit;
using Sample.Sagas.Application.Repositories.Database;
using Sample.Sagas.Application.Repositories.Services;
using Sample.Sagas.Domain;
using Samples.Sagas.ReadFile.Service.Masstransit.Contracts;

namespace Samples.Sagas.ReadFile.Service.UseCases.ReadFile
{
    public class ReadFileUseCase : IReadFileUseCase
    {
        private readonly IFileConvert fileConvert;
        private readonly IFileRepository fileRepository;
        private readonly IFileTransferRepository fileTransferRepository;
        private readonly IBus bus;

        public ReadFileUseCase(IFileConvert fileConvert, IFileRepository fileRepository, IFileTransferRepository fileTransferRepository, IBus bus)
        {
            this.fileConvert = fileConvert;
            this.fileRepository = fileRepository;
            this.fileTransferRepository = fileTransferRepository;
            this.bus = bus;
        }

        public async Task Execute(ReadFileRequest request)
        {
            fileRepository.UpdateStatus(request.File.FileId, FileStatus.InProcess);

            request.FileTransfers = fileConvert.ConvertCsv(request.File.FilePath);

            for (var i = 0; i < request.FileTransfers.Count; i++)
            {
                request.FileTransfers[i].SetFileId(request.File.FileId);
                await bus.Publish<ILineSubmitted>(new { FileId = request.File.FileId, LineId = request.FileTransfers[i].Id });
            }

            fileTransferRepository.Add(request.FileTransfers);
        }
    }
}
