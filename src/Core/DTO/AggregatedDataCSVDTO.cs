using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AggregatedDataCSVDTO
    {
        [Index(0)]
        public string TINKLAS { get; set; }
        [Index(1)]
        public string OBT_PAVADINIMAS { get; set; }
        [Index(4)]
        public string PPlus { get; set; }
        [Index(6)]
        public string PMinus { get; set; }
    }
}
