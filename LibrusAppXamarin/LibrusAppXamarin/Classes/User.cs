using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrusAppXamarin.Classes
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
    }
}
