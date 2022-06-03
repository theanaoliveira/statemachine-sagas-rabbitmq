using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Sagas.ReadFile.Service.Masstransit.Contracts
{
    public class File
    {
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
    }
}
