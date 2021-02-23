using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class VisaKind
    {
        public int Id { get; set; }
        //public int CountryId { get; set; }
        public CountryCity CountryCity { get; set; }
        public string Text { get; set; }
        public string Setting { get; set; }
        public ICollection<Advise> Advises { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
