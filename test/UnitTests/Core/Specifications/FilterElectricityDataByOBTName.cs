using Core.Entities;
using Core.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Core.Specifications
{
    public class FilterElectricityDataByOBTName
    {
        private readonly string TINKLAS = "Test test";
        private readonly string appartmentType = "Test Appartment Type";
        private readonly string electricityDataUsed = "Test electricityDataUsed";

        [Fact]
        public void MatchesAggregatedDataWithGivenAppartmentType()
        {
            var spec = new FilterElectricityDataByOBTNameSpec(appartmentType);

            var result = spec.Evaluate(GetTestAggregatedDataCollection()).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(appartmentType, result.OBT_PAVADINIMAS);
        }

        [Fact]
        public void MatchesNoAggregatedDataIfAppartmentTypeNotPresent()
        {
            string batAppartmentType = "BadAppartmentType";
            var spec = new FilterElectricityDataByOBTNameSpec(batAppartmentType);

            var result = spec.Evaluate(GetTestAggregatedDataCollection()).Any();

            Assert.False(result);
        }

        public List<AggregatedData> GetTestAggregatedDataCollection()
        {
            var aggregatedData1Mock = new Mock<AggregatedData>(TINKLAS,appartmentType, electricityDataUsed);
            aggregatedData1Mock.SetupGet(s => s.Id).Returns(1);

            var aggregatedData2Mock = new Mock<AggregatedData>(TINKLAS,appartmentType, electricityDataUsed);
            aggregatedData2Mock.SetupGet(s => s.Id).Returns(2);

            return new List<AggregatedData>()
            {
                aggregatedData1Mock.Object,
                aggregatedData1Mock.Object
            };
        }
    }
}
