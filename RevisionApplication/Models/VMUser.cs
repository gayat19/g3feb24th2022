using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Models
{
    public class VMUser :User
    {
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password mismatch")]

        public string ReTypePass { get; set; }
    }
}
