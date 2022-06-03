using MassTransit;

namespace Samples.Sagas.ReadFile.Service.Masstransit
{
    public class ReadFileConsumer : IConsumer<Contracts.File>
    {
        public Task Consume(ConsumeContext<Contracts.File> context)
        {
            throw new NotImplementedException();
        }
    }
}
