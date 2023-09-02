using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SQLite;

namespace PCMob
{
    public class Entrant
    {
        [PrimaryKey, AutoIncrement]
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
