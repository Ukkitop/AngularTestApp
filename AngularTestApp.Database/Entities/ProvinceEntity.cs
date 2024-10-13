namespace AngularTestApp.Database.Entities;

public class ProvinceEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CountryId { get; set; }

    public CountryEntity Country { get; set; } = null!;
}