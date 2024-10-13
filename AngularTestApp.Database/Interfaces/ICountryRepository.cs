using AngularTestApp.Database.Entities;

namespace AngularTestApp.Database.Interfaces;

public interface ICountryRepository
{
    Task<ICollection<ProvinceEntity>> GetProvinces(int countryId);

    Task<ICollection<CountryEntity>> GetCountries();
}