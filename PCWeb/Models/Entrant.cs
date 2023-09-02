using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class Entrant
    {
        [Key]
        public int IDEntrant { get; set; }
        public Nullable<int> IDUser { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public Nullable<System.DateTime> DateBirthday { get; set; }
        public Nullable<int> Point { get; set; }
        public string PersonalyData { get; set; }
        public byte[] Photo { get; set; }
    }
}
