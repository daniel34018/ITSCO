//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI6_HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_ROL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ROL()
        {
            this.TBL_USUARIO = new HashSet<TBL_USUARIO>();
        }
    
        public int ROL_ID { get; set; }
        public string ROL_DESCRIPCION { get; set; }
        public Nullable<System.DateTime> ROL_ADD { get; set; }
        public Nullable<int> ROL_STATUS { get; set; }
    
        public virtual TBL_ESTADO TBL_ESTADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USUARIO> TBL_USUARIO { get; set; }
    }
}
