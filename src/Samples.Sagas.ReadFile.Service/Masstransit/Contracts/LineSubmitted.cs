namespace Samples.Sagas.ReadFile.Service.Masstransit.Contracts
{
    public interface ILineSubmitted
    { 
        public Guid FileId { get; set; }
        public Guid LineId { get; set; }
    }
}
