using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public partial class TaxFreeDay : BaseEntity
    {
        public DateTime Day { get; set; }
        public int CityId { get; set; }
    }
}
