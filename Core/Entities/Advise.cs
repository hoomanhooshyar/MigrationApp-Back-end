using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Advise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        //public int CountryId { get; set; }
        public CountryCity CountryCity { get; set; }
        //public int VisaKindId { get; set; }
        public VisaKind VisaKind { get; set; }
        //public int VisitKindId { get; set; }
        public VisitKind VisitKind { get; set; }
        //public int AdvisorId { get; set; }
        public User AdvisorId { get; set; }
        public string Setting { get; set; }
    }
}
