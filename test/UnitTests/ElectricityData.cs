using Core.DTO;
using Core.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ElectricityData
    {
        private readonly Mock<IElectricitiDataRepositry> _mockOrderRepository;

        public ElectricityData()
        {
            ElectricityDataResponseDTO electricityData = new ElectricityDataResponseDTO("TINKLAS", "OBT_PAVADINIMAS Test", "PPlus Test");
            _mockOrderRepository = new Mock<IElectricitiDataRepositry>();
            _mockOrderRepository.Setup(r => r.GetElectricityApartmetsData()).ReturnsAsync(new List<ElectricityDataResponseDTO>() { electricityData });
        }

        [Fact]
        public async Task NotReturnsNullIfElectricityDataIsPresent()
        {
            var data = await _mockOrderRepository.Object.GetElectricityApartmetsData();
            Assert.NotNull(data);
        }
    }
}
