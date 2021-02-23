using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class StudyField
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
