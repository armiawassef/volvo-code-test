using CongestionTaxCalculator.Application.Services.CongestionTaxRule;
using Moq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Input;
using CongestionTaxCalculator.Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CongestionTaxCalculator.Application;
using CongestionTaxCalculator.Infrastructure.DbContexts;

namespace CongestionTaxCalculator.Tests
{
    public class Tests
    {
        internal IServiceProvider provider;
        private ICongestionTaxRuleService _congestionTaxRuleService;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DbContext, ApplicationDbContext>();
            provider = serviceCollection.AddApplicationModule().BuildServiceProvider();

            _congestionTaxRuleService = provider?.GetService<ICongestionTaxRuleService>();
        }

        [Test]
        public void CongestionTaxRule_In_July_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 07, 3, 16,49,0),
                    new DateTime(2013, 07, 5, 6, 29, 59),
                    new DateTime(2013, 07, 31, 14, 59, 59)
                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_In_WeekEnd_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 08, 17, 16,49,0),
                    new DateTime(2013, 08, 31, 18,49,0),

                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_In_Public_Holiday_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 06, 16,49,0),
                    new DateTime(2013, 12, 25, 18,49,0),
                    new DateTime(2013, 05, 09, 18,49,0),

                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_In_Day_Before_Holiday_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 05, 16,49,0),
                    new DateTime(2013, 12, 24, 18,49,0),
                    new DateTime(2013, 05, 08, 18,49,0),

                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_For_ExemptVehicle_Bus_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 2,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 04, 16,49,0),
                    new DateTime(2013, 12, 11, 19,49,0),
                    new DateTime(2013, 05, 03, 12,49,0),

                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_For_ExemptVehicle_Military_Is_Zero()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 2,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 04, 16,49,0),
                    new DateTime(2013, 12, 11, 19,49,0),
                    new DateTime(2013, 05, 03, 12,49,0),

                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(0));
        }

        [Test]
        public void CongestionTaxRule_For_Max_Tax_Per_Day()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 04, 6, 0, 0),
                    new DateTime(2013, 06, 04, 7, 0, 0),
                    new DateTime(2013, 06, 04, 8, 0, 0),
                    new DateTime(2013, 06, 04, 15, 0, 0),
                    new DateTime(2013, 06, 04, 17, 0, 0),
                    new DateTime(2013, 06, 04, 18, 30, 0)
                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(60));
        }

        [Test]
        public void CongestionTaxRule_For_Same_Hour_Per_Day()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 06, 04, 6, 0, 0),
                    new DateTime(2013, 06, 04, 6, 40, 0)
                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(13));
        }

        [Test]
        public void CongestionTaxRule_Given_Test_Cases()
        {
            var calculateTaxViewModel = new CalculateTaxViewModel()
            {
                City = 1,
                VehicleType = 7,
                CrossingDates = new DateTime[]
                {
                    new DateTime(2013, 01, 14, 21,0,0),

                    new DateTime(2013, 01, 15, 21,0,0), 

                    new DateTime(2013, 02, 7, 6,23,27),
                    new DateTime(2013, 02, 7, 15,27,0),

                    new DateTime(2013, 02, 8, 6,27,0),
                    new DateTime(2013, 02, 8, 6,20,27),
                    new DateTime(2013, 02, 8, 14,35,0),
                    new DateTime(2013, 02, 8, 15,29,0),
                    new DateTime(2013, 02, 8, 15,47,0),
                    new DateTime(2013, 02, 8, 16,1,0),
                    new DateTime(2013, 02, 8, 16,48,0),
                    new DateTime(2013, 02, 8, 17,49,0),
                    new DateTime(2013, 02, 8, 18,29,0),
                    new DateTime(2013, 02, 8, 18,35,0),

                    new DateTime(2013, 03, 26, 14,25,0),
                    new DateTime(2013, 03, 28, 14,07,27) 
                }
            };

            Assert.That(_congestionTaxRuleService.CalculateTax(calculateTaxViewModel), Is.EqualTo(89));
        }
    }
}