using proTaxi.Domain.Entities;
using proTaxi.Domain.Interfaces;
using proTaxi.Domain.Models;
using Taxi.Persistence.Models;

namespace proTaxi.Persistence.Interfaces
{
    public interface ITaxisRepository : IRepository<Taxiss, int>
    {
        /// <summary>
        /// Get all Taxis.
        /// </summary>
        /// <returns></returns>
        Task<DataResult<List<TaxiModel>>> GetTaxis();
        /// <summary>
        /// Get taxis by title
        /// </summary>
        /// <param title="title">Title of taxi</param>
        /// <returns></returns>
        Task<DataResult<TaxiModel>> GetTaxiByTitle(string title);

        /// <summary>
        /// Get Taxis by viajes
        /// </summary>
        /// <param name="taxiId">taxiId</param>
        /// <returns>TaxiModel</returns>
        Task<DataResult<List<TaxiModel>>> GetTaxisByViajes(int taxiId);
    }
}
