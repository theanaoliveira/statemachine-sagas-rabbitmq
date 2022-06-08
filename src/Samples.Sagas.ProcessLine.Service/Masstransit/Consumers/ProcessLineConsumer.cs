using MassTransit;
using Microsoft.Extensions.Logging;
using Samples.Sagas.ProcessLine.Service.Masstransit.Contracts;

namespace Samples.Sagas.ProcessLine.Service.Masstransit.Consumers
{
    public class ProcessLineConsumer : IConsumer<Line>
    {
        private readonly ILogger<ProcessLineConsumer> logger;

        public ProcessLineConsumer(ILogger<ProcessLineConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<Line> context)
        {
            logger.LogInformation($"Consuming message {context.Message}");

            await Task.CompletedTask;
        }
    }
}
