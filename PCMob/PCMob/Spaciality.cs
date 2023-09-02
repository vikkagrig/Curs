using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCMob
{
    public class Spaciality
    {
        [PrimaryKey, AutoIncrement]
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
