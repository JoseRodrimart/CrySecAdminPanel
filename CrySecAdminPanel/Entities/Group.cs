using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.Entities
{
    public class Group
    {
        public String Name { get; set; }
        public EGroupType Type { get; set; }
        public int Messages { get; set; }
        public List<GroupMember> Members { get; set; }

        public Group(string name, EGroupType type, int messages, List<GroupMember> members)
        {
            Name = name;
            Type = type;
            Messages = messages;
            Members = members;
        }

        public enum EGroupType
        {
            Notifications,
            Chat,
            Test
        }

        public class GroupMember
        {
            public string Name { get; set; }
            public string Mail { get; set; }
            public bool IsAdmin { get; set; }

            public GroupMember(string name, string mail, bool isAdmin)
            {
                Name = name;
                Mail = mail;
                IsAdmin = isAdmin;
            }
        }
    }
}
