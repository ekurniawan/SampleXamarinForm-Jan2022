using System;
using System.Collections.Generic;
using System.Text;

namespace SampleXamarinForm.Models
{

    public class MenuItem
    {
        public MenuItem()
        {
            TargetType = typeof(MenuItem);        
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string ImageIcon { get; set; }
    }
}
