using MassTransit;
using Orchestrator.Contracts;
using Sample.Sagas.Application.Repositories.Database;
using Sample.Sagas.Domain;
using Serilog;

namespace Orchestrator.UseCases
{
    public class GetTransferFilesUseCase : IGetTransferFilesUseCase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IFileRepository fileRepository;

        public GetTransferFilesUseCase(IPublishEndpoint publishEndpoint, IFileRepository fileRepository)
        {
            this.publishEndpoint = publishEndpoint;
            this.fileRepository = fileRepository;
        }

        public Task Execute()
        {
            var path = Environment.GetEnvironmentVariable("INPUT_LOCAL_PATH");

            if(!string.IsNullOrEmpty(path))
            {
                var files = new DirectoryInfo(path).GetFiles("*.csv").ToList();

                Log.Information($"JobFileTransferUseCase - Total files on server: {files.Count} - FileNames: {string.Join(" - ", files.Select(s => s.Name).ToList())}");

                files.ForEach(async f =>
                {
                    var file = new Sample.Sagas.Domain.File(Guid.NewGuid(), f.Name, FileStatus.New);
                    var read = new ReadFileSubmitted(file.Id, f.FullName);

                    fileRepository.Add(file);

                    await publishEndpoint.Publish(read);
                });
            }

            return Task.CompletedTask;
        }
    }
}
