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
    
    public partial class StudentNote
    {
        public int StudentNoteID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<double> Agno { get; set; }
        public Nullable<int> AgnoKredi { get; set; }
        public Nullable<double> Yano { get; set; }
        public Nullable<int> YanoKredi { get; set; }
        public Nullable<double> CadYano { get; set; }
        public Nullable<int> CadYanoKredi { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
