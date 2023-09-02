using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class List
    {
        [Key]
        public int IDList { get; set; }
        public Nullable<int> IDSpec { get; set; }
        public Nullable<int> IDEntrant { get; set; }
        public string FormStudy { get; set; }
        public Nullable<int> Priority { get; set; }
    }
}
