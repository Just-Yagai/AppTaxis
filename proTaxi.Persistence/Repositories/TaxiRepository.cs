using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using proInstute.Persistence.Repository;
using proTaxi.Domain.Entities;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using Taxi.Persistence.Models;

namespace Taxi.Persistence.Repositories
{
    public class TaxiRepository : BaseRepository<Taxiss, int>, ITaxisRepository
    {
        private readonly TaxiDb taxiDbContext;
        private readonly ILogger<TaxiRepository> logger;
        private readonly IConfiguration configuration;

        public TaxiRepository(TaxiDb taxiDbContext,
                              ILogger<TaxiRepository> logger,
                              IConfiguration configuration) : base(taxiDbContext)
        {
            this.taxiDbContext = taxiDbContext;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<DataResult<List<TaxiModel>>> GetTaxiByPlaca(string placa)
        {
            DataResult<List<TaxiModel>> result = new DataResult<List<TaxiModel>>();

            try
            {
                var query = await (from taxi in this.taxiDbContext.Taxis
                                   where taxi.Deleted == false
                                   && taxi.Placa == placa
                                   select new TaxiModel()
                                   {
                                       Placa = taxi.Placa,
                                       Id = taxi.Id
                                   }).ToListAsync();

                result.Result = query;
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["taxi:get_taxi_placa"];
                result.Success = false;
                this.logger.LogError(this.configuration["taxi:get_taxi_placa"], ex.ToString());
            }
            return result;
        }

        public async Task<DataResult<TaxiModel>> GetTaxiById(int id)
        {
            DataResult<TaxiModel> result = new DataResult<TaxiModel>();

            try
            {
                TaxiModel? dato = await (from taxi in this.taxiDbContext.Taxis
                                         where taxi.Deleted == false
                                         && taxi.Id == id
                                         select new TaxiModel()
                                         {
                                             Placa = taxi.Placa,
                                             Id = taxi.Id
                                         }).FirstOrDefaultAsync();

                result.Result = dato;
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["taxi:get_taxi_id"];
                result.Success = false;
                this.logger.LogError(this.configuration["taxi:get_taxi_id"], ex.ToString());
            }

            return result;
        }

        public async Task<DataResult<List<TaxiModel>>> GetAllTaxis()
        {
            DataResult<List<TaxiModel>> result = new DataResult<List<TaxiModel>>();

            try
            {
                var query = await (from taxi in this.taxiDbContext.Taxis
                                   where taxi.Deleted == false
                                   select new TaxiModel()
                                   {
                                       Placa = taxi.Placa,
                                       Id = taxi.Id
                                   }).ToListAsync();

                result.Result = query;
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["taxi:get_all_taxis"];
                result.Success = false;
                this.logger.LogError(this.configuration["taxi:get_all_taxis"], ex.ToString());
            }

            return result;
        }

        public override Task<bool> Save(Taxiss entity)
        {
            return base.Save(entity);
        }

        public override Task<bool> Update(Taxiss entity)
        {
            return base.Update(entity);
        }
    }
}
