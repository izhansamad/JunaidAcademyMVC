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
    using System.ComponentModel.DataAnnotations;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseAssigns = new HashSet<CourseAssign>();
        }

        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]

        public string CourseDescription { get; set; }
        [Required]

        public string CourseFee { get; set; }
        [Required]

        public string CourseDuration { get; set; }
        [Required]

        public Nullable<int> CourseSeats { get; set; }
        public string CourseImg { get; set; }
        public Nullable<int> TID { get; set; }

        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAssign> CourseAssigns { get; set; }
    }
}
