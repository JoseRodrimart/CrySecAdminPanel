﻿using CrySecAdminPanel.Services;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrySecAdminPanel.ViewModel
{
    public partial class CryGroupViewModel
    {
        private GroupService groupService = new GroupService();
        private BindingList<CryGroup> _cryGroups = new BindingList<CryGroup>();

        public BindingList<CryGroup> CryGroups { get { return _cryGroups; } }

        public CryGroupViewModel()
        {
            SetGroups();
        }

        public void SetGroups()
        {
            CryGroups.Clear();
            List<CryGroup> groups = groupService.GetGroups();
            groups.ForEach(u => Trace.WriteLine(u.Name));
            groups.ForEach(CryGroups.Add);  
        }

    }
}