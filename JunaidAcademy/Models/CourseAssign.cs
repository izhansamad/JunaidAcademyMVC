//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JunaidAcademy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class CourseAssign
    {
        public int CourseAssignID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CourseID { get; set; }
        [DefaultValue("Pending")]
        public string Status { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
