using System;
using System.Collections.Generic;
using System.Text;

namespace DBDapper.Models
{
    public class Employee
    {
        public int EMP_ID { get; set; }
        public int LAST_NAME { get; set; }
        public int FIRST_NAME { get; set; }

        public DateTime START_DATE { get; set; }
        public string TITLE { get; set; }
    }
}
