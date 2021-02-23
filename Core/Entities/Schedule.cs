using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        //public int UserId { get; set; }
        public User User { get; set; }
        public int Hour { get; set; }
    }
}
