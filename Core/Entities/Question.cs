using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Entities
{
    public class Question
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public VisaKind VisaKind { get; set; }
        public DateTime QDate { get; set; }
        public int Price { get; set; }
    }
}
