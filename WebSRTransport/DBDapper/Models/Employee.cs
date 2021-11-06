using System;
using System.Collections.Generic;
using System.Text;

namespace DBDapper.Models
{
    public class Employee
    {
        public int EMP_ID { get; set; }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME { get; set; }

        public DateTime START_DATE { get; set; }
        public string TITLE { get; set; }
    }
}
