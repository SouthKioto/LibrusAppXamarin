using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrusAppXamarin.Classes
{
    public class Grade
    {
        [PrimaryKey, AutoIncrement]
        public int GradeId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Score { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
    }
}
