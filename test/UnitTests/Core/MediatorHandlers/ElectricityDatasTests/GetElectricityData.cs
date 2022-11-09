using API.Features.ElectricityData;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Core.MediatorHandlers.ElectricityDatasTests
{
    public class GetElectricityData
    {
        private readonly Mock<IReadRepository<AggregatedData>> _mockOrderRepository;
        public GetElectricityData()
        {
            AggregatedData aggregatedData = new AggregatedData("Tinklas","obt_pavadinimas","electricityDataUsed");
            List<AggregatedData> aggregatedDataList = new List<AggregatedData>() { aggregatedData };
            _mockOrderRepository = new Mock<IReadRepository<AggregatedData>>();
            _mockOrderRepository.Setup(x => x.ListAsync(It.IsAny<FilterElectricityDataByOBTNameSpec>(), default))
           .ReturnsAsync(aggregatedDataList);
        }

        [Fact]
        public async Task NotBeNullIfAggregatedDataExists()
        {
            var request = new API.Features.ElectricityData.GetElectricityData("testName");

            var handler = new GetElectricityDataHandler(_mockOrderRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
