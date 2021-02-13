using Microsoft.AspNetCore.Mvc;
using MSSQLServerMonitoring.Api.Dto;
using MSSQLServerMonitoring.Api.Mappers;
using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public UsersController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<List<UserDto>> ListAll()
        {
            List<User> users = await _repositoryWrapper.User.GetAll();
            return users.Map();
        }

        [HttpPost]
        public async Task AddUser([FromBody] UserDto userDto)
        {
            var user = new User(userDto.Login, userDto.Email, userDto.Password);
            await _repositoryWrapper.User.Add(user);
            _repositoryWrapper.Save();
        }
    }
}
