using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public partial class VehicleType: BaseEntity
    {
        public required string Type { get; set; }
    }
}
