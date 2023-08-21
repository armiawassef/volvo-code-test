using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public partial class CongestionTaxRule : BaseEntity
    {
        public required TimeSpan Start { get; set; }
        public required TimeSpan End { get; set; }
        public required double Charge { get; set; }
        public required int CityId { get; set; }
    }
}
