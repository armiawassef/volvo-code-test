using Entities = CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Infrastructure.DbContexts;
using CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle;
using CongestionTaxCalculator.Common.Repositories.TaxFreeDay;

namespace CongestionTaxCalculator.Infrastructure.Repositories.TaxFreeDay
{
    public class TaxFreeDayRepository : GenericRepository<Entities.TaxFreeDay>, ITaxFreeDayRepository
    {
        public TaxFreeDayRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
