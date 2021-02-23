using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
