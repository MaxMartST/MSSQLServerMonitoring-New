using System.Runtime.Serialization;

namespace MSSQLServerMonitoring.Api.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "isAdmin")]
        public bool isAdmin { get; set; }
    }
}
