using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class TaxExemptVehicle : BaseEntity
    {
        public int VehicleTypeId { get; set; }
        public int CityId { get; set; }
    }
}
