namespace Samples.Sagas.ReadFile.Service.UseCases.ReadFile
{
    public interface IReadFileUseCase
    {
        Task Execute(ReadFileRequest request);
    }
}
