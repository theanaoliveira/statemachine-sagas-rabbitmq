using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Sample.Sagas.Application.Repositories.Services;
using Sample.Sagas.Domain.Transfer;
using Sample.Sagas.Infrastructure.Csv.Transfer;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sample.Sagas.Infrastructure.Services
{
    public class FileConvert : IFileConvert
    {
        private readonly IMapper mapper;

        public FileConvert(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<FileTransfer> ConvertCsv(string file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = h => Regex.Replace(h.Header.ToLower(), "[^0-9a-zA-Z]+", string.Empty)
            };

            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<FileTransferMap>();

            var lines = csv.GetRecords<FileTransferItem>().ToList();

            return mapper.Map<List<FileTransfer>>(lines);
        }
    }
}
