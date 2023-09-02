using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCMob
{
    public class Faculty
    {
        [PrimaryKey, AutoIncrement]
        public int IDFac { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
