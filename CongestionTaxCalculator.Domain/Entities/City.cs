using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class City : BaseEntity
    {
        public required string Name { get; set; }
    }
}
