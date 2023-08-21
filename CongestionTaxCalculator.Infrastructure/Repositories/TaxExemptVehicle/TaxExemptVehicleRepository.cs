using Entities = CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Infrastructure.DbContexts;
using CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle;

namespace CongestionTaxCalculator.Infrastructure.Repositories.TaxExemptVehicle
{

    public class TaxExemptVehicleRepository : GenericRepository<Entities.TaxExemptVehicle>, ITaxExemptVehicleRepository
    {
        public TaxExemptVehicleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
