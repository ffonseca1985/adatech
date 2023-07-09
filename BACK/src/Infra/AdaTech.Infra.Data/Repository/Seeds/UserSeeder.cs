using AdaTech.Domain.Models;
using AdaTech.Infra.Security;
using Microsoft.Extensions.Configuration;

namespace AdaTech.Infra.Data.Repository.Seeds
{
    public class UserSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserSeeder(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Seed()
        {
            if (!_context.Cards.Any())
            {
                var userName = _configuration["Credentials:login"];
                var password = _configuration["Credentials:senha"]; ;

                var hash = PasswordHasherInMemory.HashPassword(userName, password);
                _context.Users.Add(new User(userName, hash));

                _context.SaveChanges();
            }
        }
    }
}
