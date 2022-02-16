using System;
using System.Collections.Generic;

namespace PanelAdmin.Entities
{
    public class CryGroup
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Image { get; set; }
        
        public List<CryUser> regularUsers { get; set; }
        
        public List<CryUser> adminUsers { get; set; }

        public CryGroup(int id, String name, String type)
        {
            this.id = id;
            this.Name = name;
            this.Type = type;
        }

        public String ToString()
        {
            return "ID: " + id + "Name: " + Name+ " Type: " + Type+ "Image: " + Image + "";
        }
    }
}