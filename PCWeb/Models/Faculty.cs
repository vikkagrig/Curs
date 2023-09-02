using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class Faculty
    {
        [Key]
        public int IDFac { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
