using AutoMapper;
using Core.DTO;
using Core.Interfaces.Services;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Services
{
    public class CSVReaderService : ICSVReaderService
    {
        private readonly string[] _csvFilePaths;
        public readonly IMapper _mapper;

        public CSVReaderService(IConfiguration configuration)
        {
            var section = configuration.GetSection("CSVFilePath");
            _csvFilePaths = section.Get<string[]>();
        }


        public List<AggregatedDataDTO> Read()
        {
            List<AggregatedDataCSVDTO> results = new List<AggregatedDataCSVDTO>();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = false
            };

            foreach (var filePath in _csvFilePaths)
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var data = csv.GetRecords<AggregatedDataCSVDTO>();
                    results.AddRange(data);
                }
            }

            return results.GroupBy(x => new { x.TINKLAS,x.OBT_PAVADINIMAS })
                            .Select(y => new AggregatedDataDTO() {
                                TINKLAS = y.Select(t => t.TINKLAS).FirstOrDefault(),
                                OBT_PAVADINIMAS = y.Select(t => t.OBT_PAVADINIMAS).FirstOrDefault(),
                                //may be this logic is not correct but but its simple to change
                                ElectricityDataUsed = (           
                                            y.Sum(t => 
                                            {
                                                float res;
                                                if (float.TryParse(t.PPlus, out res))
                                                {
                                                    return res;
                                                }
                                                return 0;
                                            }) -
                                            y.Sum(t =>
                                            {
                                                float res;
                                                if (float.TryParse(t.PMinus, out res))
                                                {
                                                    return res;
                                                }
                                                return 0;
                                            }) 
                                        ).ToString()
                            }).ToList();
        }

    }
}
