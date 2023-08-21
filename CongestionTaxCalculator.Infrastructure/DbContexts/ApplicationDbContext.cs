using CongestionTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.Extensions.Configuration;
using Nager.Date;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongestionTaxCalculator.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        string databaseLocation = Path.Combine(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName, "CongestionTaxCalculatorDatabase");
        if (!Directory.Exists(databaseLocation)) Directory.CreateDirectory(databaseLocation);

        string dataSource = string.Concat("Data Source=", databaseLocation, "CongestionTaxCalculatorDatabase.db;");
        options.UseSqlite(dataSource);
    }
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<CongestionTaxRule> CongestionTaxRules { get; set; } = null!;
    public virtual DbSet<TaxExemptVehicle> TaxExemptVehicles { get; set; } = null!;
    public virtual DbSet<TaxFreeDay> TaxFreeDays { get; set; } = null!;
    public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        SeedDataModel(builder);
        base.OnModelCreating(builder);
    }

    #region Private Seeding Methods
    private void SeedDataModel(ModelBuilder builder)
    {
        SeedVehicleType(builder);
        SeedCity(builder);
        SeedTaxExemptVehicle(builder);
        SeedCongestionTaxRule(builder);
        SeedTaxFreeDay(builder);
    }
    private void SeedVehicleType(ModelBuilder builder)
    {
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 1, Type = "Emergency" });
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 2, Type = "Bus" });
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 3, Type = "Diplomat" });
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 4, Type = "Motorcycle" });
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 5, Type = "Military" });
        builder.Entity<VehicleType>().HasData(new VehicleType { Id = 6, Type = "Foreign" });
    }
    private void SeedCity(ModelBuilder builder)
    {
        builder.Entity<City>().HasData(new City { Id = 1, Name = "Gothenburg" });
    }
    private void SeedTaxExemptVehicle(ModelBuilder builder)
    {
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 1, CityId = 1, VehicleTypeId = 1 });
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 2, CityId = 1, VehicleTypeId = 2 });
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 3, CityId = 1, VehicleTypeId = 3 });
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 4, CityId = 1, VehicleTypeId = 4 });
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 5, CityId = 1, VehicleTypeId = 5 });
        builder.Entity<TaxExemptVehicle>().HasData(new TaxExemptVehicle { Id = 6, CityId = 1, VehicleTypeId = 6 });
    }
    private void SeedTaxFreeDay(ModelBuilder builder)
    {
        var StartDate2013 = new DateTime(2013, 1, 1, 0, 0, 0);
        var count = 1;

        while (StartDate2013.Year == 2013)
        {
            if (DateSystem.IsWeekend(StartDate2013, CountryCode.SE) || DateSystem.IsPublicHoliday(StartDate2013, CountryCode.SE) || DateSystem.IsPublicHoliday(StartDate2013.AddDays(1), CountryCode.SE) || StartDate2013.Month == 7)
            {
                var day = new DateTime(2013, StartDate2013.Month, StartDate2013.Day, 0, 0, 0);
                builder.Entity<TaxFreeDay>().HasData(new TaxFreeDay { Id = count++, CityId = 1, Day = day });
            }

            StartDate2013 = StartDate2013.AddDays(1);
        }
    }
    private void SeedCongestionTaxRule(ModelBuilder builder)
    {
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 1, CityId = 1, Start = new TimeSpan(6, 0, 0), End = new TimeSpan(6, 29, 59), Charge = 8 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 2, CityId = 1, Start = new TimeSpan(6, 30, 0), End = new TimeSpan(6, 59, 59), Charge = 13 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 3, CityId = 1, Start = new TimeSpan(7, 0, 0), End = new TimeSpan(7, 59, 59), Charge = 18 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 4, CityId = 1, Start = new TimeSpan(8, 0, 0), End = new TimeSpan(8, 29, 59), Charge = 13 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 5, CityId = 1, Start = new TimeSpan(8, 30, 0), End = new TimeSpan(14, 59, 59), Charge = 8 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 6, CityId = 1, Start = new TimeSpan(15, 0, 0), End = new TimeSpan(15, 29, 59), Charge = 13 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 7, CityId = 1, Start = new TimeSpan(15, 30, 0), End = new TimeSpan(16, 59, 59), Charge = 18 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 8, CityId = 1, Start = new TimeSpan(17, 0, 0), End = new TimeSpan(17, 59, 59), Charge = 13 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 9, CityId = 1, Start = new TimeSpan(18, 0, 0), End = new TimeSpan(18, 29, 59), Charge = 8 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 10, CityId = 1, Start = new TimeSpan(18, 30, 0), End = new TimeSpan(23, 59, 59), Charge = 0 });
        builder.Entity<CongestionTaxRule>().HasData(new CongestionTaxRule { Id = 11, CityId = 1, Start = new TimeSpan(0, 0, 0), End = new TimeSpan(5, 59, 59), Charge = 0 });
    }

    #endregion
}