using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
        public int Gender { get; set; }
        //public int CityId { get; set; }
        public CountryCity CountryCity { get; set; }
        //public int StudyFieldId { get; set; }
        public StudyField StudyField { get; set; }
        public string Status { get; set; }
        public string Credit { get; set; }
        public string Setting { get; set; }
        public ICollection<Advise> Advises { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
