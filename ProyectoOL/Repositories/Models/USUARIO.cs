//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoOL.Repositories.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.PANTALLA = new HashSet<PANTALLA>();
        }
    
        public int ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public short FK_TIPO_DOCUMENTO { get; set; }
        public short FK_TIPO_USUARIO { get; set; }
        public short FK_ESTADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CONTRASENA { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
    
        public virtual CAT_ESTADO CAT_ESTADO { get; set; }
        public virtual CAT_TIPO_DOCUMENTO CAT_TIPO_DOCUMENTO { get; set; }
        public virtual CAT_TIPO_USUARIO CAT_TIPO_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PANTALLA> PANTALLA { get; set; }
    }
}
