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
    
    public partial class TBL_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USUARIO()
        {
            this.TBL_INCIDENTE = new HashSet<TBL_INCIDENTE>();
        }
    
        public int USU_ID { get; set; }
        public Nullable<int> ROL_ID { get; set; }
        public Nullable<int> PER_ID { get; set; }
        public string USU_LOGIN { get; set; }
        public string USU_PASSWORD { get; set; }
        public string USU_EMAIL { get; set; }
        public Nullable<System.DateTime> USU_ADD { get; set; }
        public Nullable<int> USU_STATUS { get; set; }
    
        public virtual TBL_ESTADO TBL_ESTADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INCIDENTE> TBL_INCIDENTE { get; set; }
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        public virtual TBL_ROL TBL_ROL { get; set; }
    }
}
