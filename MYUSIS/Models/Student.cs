//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MYUSIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.FamilyAdresses = new HashSet<FamilyAdress>();
            this.StudentAdresses = new HashSet<StudentAdress>();
            this.StudentCourses = new HashSet<StudentCourse>();
            this.StudentExams = new HashSet<StudentExam>();
            this.StudentInfoes = new HashSet<StudentInfo>();
            this.StudentLessons = new HashSet<StudentLesson>();
            this.StudentLogins = new HashSet<StudentLogin>();
            this.StudentNotes = new HashSet<StudentNote>();
        }
    
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> LecturerID { get; set; }
        public string Status { get; set; }
        public string TCKN { get; set; }
        public Nullable<int> Class { get; set; }
        public Nullable<int> Period { get; set; }
        public string RegistryType { get; set; }
        public System.DateTime RegistryDate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyAdress> FamilyAdresses { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAdress> StudentAdresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentExam> StudentExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentInfo> StudentInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentLogin> StudentLogins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentNote> StudentNotes { get; set; }
    }
}