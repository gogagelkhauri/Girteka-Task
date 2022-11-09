using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces.Services;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(IMapper mapper,EntityFrameworkDbContext applicationDbContext, ICSVReaderService csvService,int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                Log.Information("SeedAsync start - ", DateTime.Now);
                if (!await applicationDbContext.AggregatedDatas.AnyAsync())
                {
                    List<AggregatedDataDTO> data = csvService.Read();
                    if (data.Any())
                    {
                        var mappedData = ObjectMapper.Mapper.Map<List<AggregatedData>>(data);
                        var dbContextTransaction = applicationDbContext.Database.BeginTransaction();
                        try
                        {
                            await applicationDbContext.AggregatedDatas.AddRangeAsync(mappedData);
                            await applicationDbContext.SaveChangesAsync();
                            dbContextTransaction.Commit();
                        }
                        catch(Exception ex)
                        {
                            Log.Fatal(ex, $"SeedAsync dbContextTransaction Exception - {DateTime.Now} ");
                            dbContextTransaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;
                retryForAvailability++;
                Log.Fatal(ex, $"SeedAsync Exception - {DateTime.Now} ");
                await SeedAsync(mapper,applicationDbContext, csvService, retryForAvailability);
                throw;
            }

            Log.Information("SeedAsync end - ", DateTime.Now);
        }

    }
}
