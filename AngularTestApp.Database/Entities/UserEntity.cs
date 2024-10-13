namespace AngularTestApp.Database.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public CountryEntity Country { get; set; }

    public int CountryId { get; set; }

    public ProvinceEntity Province { get; set; }

    public int ProvinceId { get; set; }
}