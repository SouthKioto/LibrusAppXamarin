using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrusAppXamarin.Classes
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Subject_id { get; set; }
        public string Name { get; set; }
    }
}
