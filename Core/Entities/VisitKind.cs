using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class VisitKind
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Advise> Advises { get; set; }
    }
}
