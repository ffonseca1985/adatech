using AdaTech.Domain.Models;
using AdaTech.Infra.Security;

namespace AdaTech.Infra.Data.Repository.Seeds
{
    public class UserSeeder
    {
        private readonly ApplicationDbContext _context;

        public UserSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Cards.Any())
            {
                var userName = "letscode";
                var password = "lets@123";

                var hash = PasswordHasherInMemory.HashPassword(userName, password);
                _context.Users.Add(new User(userName, hash));

                _context.SaveChanges();
            }
        }
    }
}
