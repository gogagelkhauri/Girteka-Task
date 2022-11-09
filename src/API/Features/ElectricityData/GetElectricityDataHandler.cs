using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace API.Features.ElectricityData;

public class GetElectricityDataHandler : IRequestHandler<GetElectricityData, IEnumerable<ElectricityDataResponseDTO>>
{
    private readonly IReadRepository<AggregatedData> _aggregatedDataRepository;

    public GetElectricityDataHandler(IReadRepository<AggregatedData> aggregatedDataRepository)
    {
        _aggregatedDataRepository = aggregatedDataRepository;
    }

    public async Task<IEnumerable<ElectricityDataResponseDTO>> Handle(GetElectricityData request, CancellationToken cancellationToken)
    {
        var specification = new FilterElectricityDataByOBTNameSpec(request.OBT_NAME);
        var electricityData = await _aggregatedDataRepository.ListAsync(specification, cancellationToken);

        return electricityData.Select(d => new ElectricityDataResponseDTO(d.TINKLAS, d.OBT_PAVADINIMAS, d.ElectricityDataUsed));
    }
}

