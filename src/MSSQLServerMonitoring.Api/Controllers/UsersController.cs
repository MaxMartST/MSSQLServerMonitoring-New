using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<User>> ListAll()
        {
            List<User> users = await _repositoryWrapper.User.GetAll();
            return users;
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await _repositoryWrapper.User.Add(user);
        }
    }
}
