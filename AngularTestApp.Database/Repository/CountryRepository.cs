using AngularTestApp.Database.Context;
using AngularTestApp.Database.Entities;
using AngularTestApp.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularTestApp.Database.Repository;

public class CountryRepository(AngularTestAppDbContext context) : ICountryRepository
{
    public async Task<ICollection<ProvinceEntity>> GetProvinces(int countryId) 
    {
        return await context.Provinces.Where(x => x.Country.Id == countryId).ToListAsync();
    }

    public async Task<ICollection<CountryEntity>> GetCountries()
    {
        return await context.Countries.ToListAsync();
    }
}