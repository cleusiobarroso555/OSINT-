using LivroManager.Data;
using LivroManager.Models;
using BCrypt.Net;

namespace LivroManager.Controllers
{
    public class UserController
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Register(string nome, string email, string password)
        {
            if (_context.Users.Any(u => u.Email == email)) return false;

            var user = new User
            {
                Nome = nome,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }
    }
}
