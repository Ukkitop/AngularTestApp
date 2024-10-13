using AngularTestApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularTestApp.Database.Context;

public class AngularTestAppDbContext(DbContextOptions<AngularTestAppDbContext> options) : DbContext(options)
{
    public DbSet<CountryEntity> Countries { get; set; }

    public DbSet<ProvinceEntity> Provinces { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var countryList = new List<CountryEntity>
        {
            new()
            {
                Id = 1,
                Name = "Country 1",
            },
            new()
            {
                Id = 2,
                Name = "Country 2",
            }
        };

        modelBuilder.Entity<CountryEntity>().HasData(
            countryList);

        modelBuilder.Entity<ProvinceEntity>().HasData([new
        {
            Id = 1,
            Name = "Province 2.1",
            CountryId = 2
        },
        new
        {
            Id = 2,
            Name = "Province 2.2",
            CountryId = 2
        },
        new
        {
            Id = 3,
            Name = "Province 2.3",
            CountryId = 2
        },
        new
        {
            Id = 4,
            Name = "Province 1.1",
            CountryId = 1
        },
        new
        {
            Id = 5,
            Name = "Province 1.2",
            CountryId = 1
        },
        new
        {
            Id = 6,
            Name = "Province 1.3",
            CountryId = 1
        },
        ]);
    }
}