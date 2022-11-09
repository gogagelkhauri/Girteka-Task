using Core.DTO;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CSVMappings
{
    public class AggregattedDataMap : ClassMap<AggregatedDataCSVDTO>
    {
        public AggregattedDataMap()
        {
            Map(p => p.TINKLAS).Index(0);
            Map(p => p.OBT_PAVADINIMAS).Index(1);
            Map(p => p.PPlus).Index(4);
            Map(p => p.PMinus).Index(6);
        }
    }
}
