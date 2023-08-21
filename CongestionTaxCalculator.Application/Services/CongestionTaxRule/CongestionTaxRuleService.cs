
using CongestionTaxCalculator.Application.ViewModels;
using CongestionTaxCalculator.Common;
using CongestionTaxCalculator.Common.Repositories.CongestionTaxRule;
using CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle;
using CongestionTaxCalculator.Common.Repositories.TaxFreeDay;
using CongestionTaxCalculator.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Services.CongestionTaxRule
{

    public class CongestionTaxRuleService : ICongestionTaxRuleService
    {
        private ICongestionTaxRuleRepository _congestionTaxRuleRepository { get; }
        private ITaxExemptVehicleRepository _taxExemptVehicleRepository { get; }
        private ITaxFreeDayRepository _taxfreeDayRepository { get; }

        public CongestionTaxRuleService(ICongestionTaxRuleRepository congestionTaxRuleRepository, ITaxExemptVehicleRepository taxExemptVehicleRepository, ITaxFreeDayRepository taxfreeDayRepository)
        {
            _congestionTaxRuleRepository = congestionTaxRuleRepository;
            _taxExemptVehicleRepository = taxExemptVehicleRepository;
            _taxfreeDayRepository = taxfreeDayRepository;
        }

        public double CalculateTax(CalculateTaxViewModel calculateTaxViewModel)
        {
            double totalTaxResult = 0;
            var vehicleType = _taxExemptVehicleRepository.GetAll().Where(tev => tev.VehicleTypeId == calculateTaxViewModel.VehicleType && tev.CityId == calculateTaxViewModel.City).FirstOrDefault();
            if (vehicleType != null) { return totalTaxResult; }

            var nonFreeDays = new List<DateTime>();
            var crossTollGroups = calculateTaxViewModel.CrossingDates.GroupBy(x => x.Date.ToShortDateString());

            double currentDailyTax = 0;
            double currentHourlyTax = 0;

            foreach (var crossTollByDateGroup in crossTollGroups)
            {
                var taxFreeDay = _taxfreeDayRepository.GetAll().Where(tfd => tfd.Day.ToShortDateString() == crossTollByDateGroup.Key).FirstOrDefault();

                if (taxFreeDay == null)
                {
                    var timeGroups = crossTollByDateGroup.ToList().GroupBy(t => t.Hour);

                    foreach (var timeGroup in timeGroups)
                    {
                        foreach (var time in timeGroup)
                        {
                            var congestionTaxRule = _congestionTaxRuleRepository.GetAll().Where(ctr => (time.TimeOfDay >= ctr.Start && time.TimeOfDay <= ctr.End) && ctr.CityId == calculateTaxViewModel.City).FirstOrDefault();
                            if (congestionTaxRule?.Charge > currentHourlyTax) { currentHourlyTax = congestionTaxRule.Charge; }
                        }

                        currentDailyTax += currentHourlyTax;
                        currentHourlyTax = 0;
                    }
                }

                totalTaxResult = currentDailyTax > 60 ? totalTaxResult + 60 : totalTaxResult + currentDailyTax;
                currentDailyTax = 0;
            }

            return totalTaxResult;
        }
    }
}
