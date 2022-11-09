using Core.DTO;

namespace Core.Interfaces.Services
{
    public interface ICSVReaderService
    {
        List<AggregatedDataDTO> Read();
    }
}
