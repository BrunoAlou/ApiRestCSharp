using System.Collections.Generic;
using System.Linq;
using SeniorApi.Models;

namespace SeniorApi.Repositories
{
  public static class UserRepository
  {
    private static readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                UserCode = "001",
                Name = "teste01",
                CPF = "11111111111",
                UF = "GO",
                BirthDate = "01/01/2024",
                UserName = "teste1",
                Password = "123456",
                Role = "manager"
            }
        };

    public static User Get(string username, string password)
    {
      return _users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
    }
  }
}
