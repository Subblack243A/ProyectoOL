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
    
    public partial class PANTALLA
    {
        public int ID_PANTALLA { get; set; }
        public string PANTALLA1 { get; set; }
        public string MONITOR { get; set; }
        public int FK_USUARIO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
