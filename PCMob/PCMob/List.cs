using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCMob
{
    public class List
    {
        [PrimaryKey, AutoIncrement]
        public int IDList { get; set; }
        public Nullable<int> IDSpec { get; set; }
        public Nullable<int> IDEntrant { get; set; }
        public string FormStudy { get; set; }
        public Nullable<int> Priority { get; set; }
    }
}
