

using CongestionTaxCalculator.Application.ViewModels;
using Entities = CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Application.Services.CongestionTaxRule
{
    public interface ICongestionTaxRuleService
    {
        double CalculateTax(CalculateTaxViewModel calculateTaxViewModel);

    }
}
