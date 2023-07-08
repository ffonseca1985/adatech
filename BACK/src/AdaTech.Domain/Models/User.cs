
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Domain.Models
{
    public class User
    {
        public User(string userName, string hash)
        {
            UserName = userName;
            Hash = hash;
        }

        [Key]
        public string UserName { get; set; }
        public string Hash { get; set; }
    }
}
