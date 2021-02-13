using MSSQLServerMonitoring.Api.Dto;
using MSSQLServerMonitoring.Domain.UserModel;
using System.Collections.Generic;
using System.Linq;

namespace MSSQLServerMonitoring.Api.Mappers
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                isAdmin = user.isAdmin
            };
        }

        public static List<UserDto> Map(this IEnumerable<User> users)
        {
            return users == null ? new List<UserDto>() : users.ToList().ConvertAll(Map);
        }
    }
}
