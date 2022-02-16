using System;
using System.Collections.Generic;

namespace PanelAdmin.Entities
{
    public class CryGroup
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Image { get; set; }
        
        public List<CryUser> regularUsers { get; set; }
        
        public List<CryUser> adminUsers { get; set; }
    }
}