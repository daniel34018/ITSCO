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
    
    public partial class TBL_OBSERVACION
    {
        public int OBS_ID { get; set; }
        public Nullable<int> PER_ID { get; set; }
        public Nullable<int> INC_ID { get; set; }
        public Nullable<System.DateTime> OBS_FECHA { get; set; }
        public string OBS_COMENTARIO { get; set; }
        public Nullable<int> OBS_STATUS { get; set; }
        public Nullable<System.DateTime> OBS_ADD { get; set; }
    
        public virtual TBL_ESTADO TBL_ESTADO { get; set; }
        public virtual TBL_INCIDENTE TBL_INCIDENTE { get; set; }
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
    }
}
