using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Prathamesh",
                LastName="Jadhav",
                EmailAddress="prathameshjc@gmail.com",
                UserName="prathamesh",
                Password="Pass@123",
                Roles=new List<string>{"reader"}
            },
            new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Dnyaneshwari",
                LastName="Jadhav",
                EmailAddress="dnyaneshwari@gmail.com",
                UserName="dnyaneshwari",
                Password="Dnya@123",
                Roles=new List<string>{"reader","writer"}
            },
        };
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.FirstOrDefault(u=>u.UserName.Equals(username,StringComparison.CurrentCultureIgnoreCase) && u.Password.Equals(password,StringComparison.CurrentCultureIgnoreCase));

            if (user != null) 
                return user;
            return null;
        }
    }
}
