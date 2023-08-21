using CongestionTaxCalculator.Application.Services.CongestionTaxRule;
using CongestionTaxCalculator.Common.Repositories.CongestionTaxRule;
using CongestionTaxCalculator.Common.Repositories.TaxExemptVehicle;
using CongestionTaxCalculator.Common.Repositories.TaxFreeDay;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Infrastructure.DbContexts;
using CongestionTaxCalculator.Infrastructure.Repositories.CongestionTaxRule;
using CongestionTaxCalculator.Infrastructure.Repositories.TaxExemptVehicle;
using CongestionTaxCalculator.Infrastructure.Repositories.TaxFreeDay;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CongestionTaxCalculator.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<ICongestionTaxRuleService, CongestionTaxRuleService>();
        services.AddScoped<ITaxExemptVehicleRepository, TaxExemptVehicleRepository>();
        services.AddScoped<ICongestionTaxRuleRepository, CongestionTaxRuleRepository>();
        services.AddScoped<ITaxFreeDayRepository, TaxFreeDayRepository>();
        return services;
    }
}