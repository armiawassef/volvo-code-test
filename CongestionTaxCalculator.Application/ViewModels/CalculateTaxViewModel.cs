namespace CongestionTaxCalculator.Application.ViewModels
{
    public class CalculateTaxViewModel
    {
        public required int VehicleType { get; set; }

        public required DateTime [] CrossingDates { get; set; }

        public required int City { get; set; }
    }
}
