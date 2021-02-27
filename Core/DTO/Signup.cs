using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class Signup
    {
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
        public string Status { get; set; }
    }
}
