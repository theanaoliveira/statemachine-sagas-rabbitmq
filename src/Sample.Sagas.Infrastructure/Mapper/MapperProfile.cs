using AutoMapper;
using Sample.Sagas.Domain.Transfer;
using Sample.Sagas.Infrastructure.Csv.Transfer;

namespace Sample.Sagas.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FileTransfer, FileTransferItem>().ReverseMap();
        }
    }
}
