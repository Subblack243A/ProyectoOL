﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoOL.Repositories.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OLDBEntities : DbContext
    {
        public OLDBEntities()
            : base("name=OLDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUDITORIA> AUDITORIA { get; set; }
        public virtual DbSet<CAT_ESTADO> CAT_ESTADO { get; set; }
        public virtual DbSet<CAT_GENERO> CAT_GENERO { get; set; }
        public virtual DbSet<CAT_LIBRO> CAT_LIBRO { get; set; }
        public virtual DbSet<CAT_TIPO_DOCUMENTO> CAT_TIPO_DOCUMENTO { get; set; }
        public virtual DbSet<CAT_TIPO_USUARIO> CAT_TIPO_USUARIO { get; set; }
        public virtual DbSet<PANTALLA> PANTALLA { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}
