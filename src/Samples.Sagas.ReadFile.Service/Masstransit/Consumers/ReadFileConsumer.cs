using MassTransit;
using Microsoft.Extensions.Logging;
using Samples.Sagas.ReadFile.Service.UseCases.ReadFile;

namespace Samples.Sagas.ReadFile.Service.Masstransit.Consumers
{
    public class ReadFileConsumer : IConsumer<Contracts.File>
    {
        private readonly ILogger<ReadFileConsumer> logger;
        private readonly IReadFileUseCase readFileUseCase;

        public ReadFileConsumer(ILogger<ReadFileConsumer> logger, IReadFileUseCase readFileUseCase)
        {
            this.logger = logger;
            this.readFileUseCase = readFileUseCase;
        }

        public Task Consume(ConsumeContext<Contracts.File> context)
        {
            return readFileUseCase.Execute(new ReadFileRequest(context.Message));
        }
    }
}
