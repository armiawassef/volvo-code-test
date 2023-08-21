using Entities = CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Infrastructure.DbContexts;
using CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle;
using CongestionTaxCalculator.Common.Repositories.CongestionTaxRule;

namespace CongestionTaxCalculator.Infrastructure.Repositories.CongestionTaxRule
{

    public class CongestionTaxRuleRepository : GenericRepository<Entities.CongestionTaxRule>, ICongestionTaxRuleRepository
    {
        public CongestionTaxRuleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
