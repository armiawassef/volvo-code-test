using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle
{
    public interface ITaxExemptVehicleRepository : IGenericRepository<Entities.TaxExemptVehicle>
    {
    }
}
