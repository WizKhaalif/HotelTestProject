using AuthorizationSystem.Contracts.Actions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationSystem.Controllers
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
            
        }

        public User(UserInfo info)
        {
            Username = info.Username;
            Password = info.Password;
            Role = info.Role;
        }
    }
}