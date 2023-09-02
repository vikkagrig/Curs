using System.ComponentModel.DataAnnotations;

namespace PCWeb.Models
{
    public class Spaciality
    {
        [Key]
        public int IDSpec { get; set; }
        public string Code { get; set; }
        public Nullable<int> IDFac { get; set; }
        public string Name { get; set; }
        public Nullable<int> PlaceBudget { get; set; }
        public Nullable<int> PlaceCommerce { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> Mark { get; set; }
        public Nullable<int> Cost { get; set; }
    }
}
