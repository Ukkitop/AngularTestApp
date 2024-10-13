namespace AngularTestApp.Database.Entities;

public class CountryEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<ProvinceEntity> Provinces { get; set; } = new List<ProvinceEntity>();
}