using CongestionTaxCalculator.Application.Services.CongestionTaxRule;
using CongestionTaxCalculator.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CongestionTaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CongestionTaxCalculatorController : ControllerBase
    {
        private readonly ILogger<CongestionTaxCalculatorController> _logger;
        private readonly ICongestionTaxRuleService _congestionTaxRuleService;

        public CongestionTaxCalculatorController(ILogger<CongestionTaxCalculatorController> logger, ICongestionTaxRuleService congestionTaxRuleService)
        {
            _logger = logger;
            _congestionTaxRuleService = congestionTaxRuleService;
        }

        [HttpPost(Name = "calculate-tax")]
        public IActionResult CalculateTax(CalculateTaxViewModel calculateTaxViewModel)
        {
            try
            {
                _logger.LogInformation(string.Format("Fetching calculateTaxViewModel :- {0}", JsonConvert.SerializeObject(calculateTaxViewModel)));
                var totalTax = _congestionTaxRuleService.CalculateTax(calculateTaxViewModel);
                _logger.LogInformation($"Returning {totalTax} tax value.");

                return Ok(totalTax);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");

                return StatusCode(500, "Internal server error");
            }
        }
    }
}