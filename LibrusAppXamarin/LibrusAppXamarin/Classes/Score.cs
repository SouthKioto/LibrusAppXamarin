using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrusAppXamarin.Classes
{
    public class Score
    {
        [AutoIncrement, PrimaryKey]
        public int Score_id { get; set; }
        public int User_id { get; set; }
        public int Subject_id { get; set; }
        public string Subject_name { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
    }
}
