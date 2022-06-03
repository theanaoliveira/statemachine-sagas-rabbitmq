using MassTransit;
using Orchestrator.Contracts;
using Serilog;

namespace Orchestrator.UseCases
{
    public class GetTransferFilesUseCase : IGetTransferFilesUseCase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public GetTransferFilesUseCase(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public Task Execute()
        {
            var path = Environment.GetEnvironmentVariable("INPUT_LOCAL_PATH");

            if(!string.IsNullOrEmpty(path))
            {
                var files = new DirectoryInfo(path).GetFiles("*.csv").ToList();

                Log.Information($"JobFileTransferUseCase - Total files on server: {files.Count()} - FileNames: {string.Join(" - ", files.Select(s => s.Name).ToList())}");

                files.ForEach(async f =>
                {
                    var read = new ReadFileSubmitted(Guid.NewGuid(), f.FullName);
                    await publishEndpoint.Publish(read);
                });
            }

            return Task.CompletedTask;
        }
    }
}
