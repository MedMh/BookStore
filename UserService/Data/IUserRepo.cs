using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepo
    {
         bool SaveChages();
         IEnumerable<User> GetAllUsers();
         User GetUserById(int Id);
         void CreateUser(User user);
    }
}