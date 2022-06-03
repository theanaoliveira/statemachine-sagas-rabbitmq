namespace Sample.Sagas.Domain
{
    public class File
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }
        public FileStatus Status { get; private set; }

        public File(Guid id, string fileName, FileStatus status)
        {
            Id = id;
            FileName = fileName;
            Status = status;
        }
    }
}