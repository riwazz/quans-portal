//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace angularvizeproje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class kategoritbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kategoritbl()
        {
            this.sorulartbl = new HashSet<sorulartbl>();
        }
    
        public int kategoriid { get; set; }
        public string kategoriAdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sorulartbl> sorulartbl { get; set; }
    }
}
