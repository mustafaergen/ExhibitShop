﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.VMs
{
    public class ManagerUserRoleVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleSelectionVM> Roles { get; set; }
    }
}
