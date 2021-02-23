using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class CountryCity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Advise> Advises { get; set; }
        public ICollection<VisaKind> VisaKinds { get; set; }
    }
}
