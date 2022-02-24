using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Services
{
    public class GetRoles
    {
        public List<SelectListItem> GetRoleList()
        {
            List<SelectListItem> roles = new List<SelectListItem>()
            {
                new SelectListItem{Text="Admin",Value="admin"},
                new SelectListItem{Text="Power User",Value="power"},
                new SelectListItem{Text="User",Value="user"}
            };
            return roles;
        }
    }
}
