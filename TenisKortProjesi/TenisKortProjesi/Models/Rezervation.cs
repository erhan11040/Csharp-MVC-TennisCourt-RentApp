//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TenisKortProjesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezervation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervation()
        {
            this.Bills = new HashSet<Bills>();
        }
    
        public int id { get; set; }
        public Nullable<int> UsersId { get; set; }
        public Nullable<int> FieldsId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> HoursId { get; set; }
        public Nullable<bool> IsComplated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual Fields Fields { get; set; }
        public virtual Hours Hours { get; set; }
        public virtual Users Users { get; set; }
    }
}