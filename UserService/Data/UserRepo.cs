using System.Collections.Generic;
using UserService.Models;
using System.Linq;

namespace UserService.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChages()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int Id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == Id);
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new System.ArgumentNullException();
            }
            _context.Users.Add(user);
        }
    }
}