using Core.Entities;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories.AggregatedDataRepositoryTests
{
    public class GetByOBTName
    {
        private readonly EntityFrameworkDbContext _dbContext;
        private readonly EfRepository<AggregatedData> _electricityDataRepository;
        private readonly ITestOutputHelper _output;

        public GetByOBTName(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<EntityFrameworkDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _dbContext = new EntityFrameworkDbContext(dbOptions);
            _electricityDataRepository = new EfRepository<AggregatedData>(_dbContext);
        }

        [Fact]
        public async Task GetsExistingAggregatedData()
        {
            var tinklas = "test Tinklas";
            var obt_pavadinimas = "Test obt_pavadinimas";
            var testElectricityData = "Test ElectricityData";

            var existingAggregatedData = new AggregatedData(tinklas, obt_pavadinimas, testElectricityData);

            _dbContext.AggregatedDatas.Add(existingAggregatedData);
            _dbContext.SaveChanges();
            int aggregatedDataId = existingAggregatedData.Id;
            _output.WriteLine($"OrderId: {aggregatedDataId}");

            var specification = new FilterElectricityDataByOBTNameSpec(obt_pavadinimas);
            var electricityDataFromRepo = await _electricityDataRepository.ListAsync(specification, default);

            Assert.Equal(obt_pavadinimas, electricityDataFromRepo.FirstOrDefault().OBT_PAVADINIMAS);
        }
    }
}
