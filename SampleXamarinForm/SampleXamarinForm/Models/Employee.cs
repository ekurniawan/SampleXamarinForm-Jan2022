using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleXamarinForm.Models
{
    public class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
    }
}
