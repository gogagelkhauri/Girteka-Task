using AutoMapper;
using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappings
{
    public class AggregatedDataMapping : Profile
    {
        public AggregatedDataMapping()
        {
            CreateMap<AggregatedDataDTO,AggregatedData>();
        }
    }
}
