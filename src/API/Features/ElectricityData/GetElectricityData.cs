using Core.DTO;
using MediatR;

namespace API.Features.ElectricityData
{
    public class GetElectricityData : IRequest<IEnumerable<ElectricityDataResponseDTO>>
    {
        public string OBT_NAME { get; set; }

        public GetElectricityData(string oBT_NAME)
        {
            OBT_NAME = oBT_NAME;
        }
    }
}
