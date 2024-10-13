using AngularTestApp.Database.Entities;
using AngularTestApp.Database.Interfaces;
using AngularTestApp.Server.Helpers;
using AngularTestApp.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AngularTestApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SaveUser(UserViewModel user)
        {
            var hash = new PasswordHash(user.Password);
            var userEntity = new UserEntity()
            {
                CountryId = user.CountryId,
                ProvinceId = user.ProvinceId,
                Email = user.Email,
                PasswordHash = System.Text.Encoding.Default.GetString(hash.Hash)
            };

            await userRepository.SaveUser(userEntity);

            return Ok();
        }
    }
}
