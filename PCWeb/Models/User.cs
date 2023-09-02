using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class User
    {
        [Key]
        public int IDUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
