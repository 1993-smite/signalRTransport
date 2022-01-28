using System;
using System.Collections.Generic;
using System.Text;

namespace DBDapper.Models
{
    public class User
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}
