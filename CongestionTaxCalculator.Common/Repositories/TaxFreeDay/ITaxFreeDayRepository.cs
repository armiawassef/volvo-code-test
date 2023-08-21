using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = CongestionTaxCalculator.Domain.Entities;


namespace CongestionTaxCalculator.Common.Repositories.TaxFreeDay
{
    public interface ITaxFreeDayRepository : IGenericRepository<Entities.TaxFreeDay>
    {
    }
}
