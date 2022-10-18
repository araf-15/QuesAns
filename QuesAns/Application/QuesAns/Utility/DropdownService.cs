using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuesAns.Utility
{
    public class DropdownService
    {
        public IEnumerable<SelectListItem> GetUserTypeSelectListItems(bool isDefaultSelectAdd = true)
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem { Text = "--Select User Type--", Value = "" },
                new SelectListItem { Text = "Student", Value = "S" },
                new SelectListItem { Text = "Teacher", Value = "T" },
            };
            return items;
        }
    }
}
