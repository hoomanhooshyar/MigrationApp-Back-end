using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UserDTO
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
        public int CountryCityId { get; set; }
        public string CountryCityTitle { get; set; }
        public int StudyFieldId { get; set; }
        public string StudyFieldTitle { get; set; }
        public string StudyFieldType { get; set; }
        public string Status { get; set; }
        public string Credit { get; set; }
        public string Setting { get; set; }
    }
}
