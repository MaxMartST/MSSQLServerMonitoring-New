using MSSQLServerMonitoring.Domain.Toolkit.Domain.Abstractions;

namespace MSSQLServerMonitoring.Domain.UserModel
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
