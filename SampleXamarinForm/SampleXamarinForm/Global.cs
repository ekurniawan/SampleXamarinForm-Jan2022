using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleXamarinForm
{
    public class Global
    {
        private static Global _instance;
        public static Global Instance { 
            get
            {
                if(_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }
        }
        public Course myCourse { get; set; }
        public string username { get; set; }
    }
}
