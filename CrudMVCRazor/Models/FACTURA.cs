//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudMVCRazor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURA()
        {
            this.FACTURADETALLEs = new HashSet<FACTURADETALLE>();
            this.FACTURADETALLEs1 = new HashSet<FACTURADETALLE>();
        }
    
        public int Id_Factura { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdVendedor { get; set; }
        public Nullable<double> Iva { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURADETALLE> FACTURADETALLEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURADETALLE> FACTURADETALLEs1 { get; set; }
        public virtual VENDEDORE VENDEDORE { get; set; }
    }
}
