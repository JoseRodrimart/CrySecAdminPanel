using System;

namespace PanelAdmin.Entities
{
    public class CryGroup
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        //public List<CryUser> regularUsers;
        //public List<CryUser> adminUsers;
    }
}