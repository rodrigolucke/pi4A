﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace f12020.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class f1apiEntities : DbContext
    {
        public f1apiEntities()
            : base("name=f1apiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<equipe> equipe { get; set; }
        public virtual DbSet<gp> gp { get; set; }
        public virtual DbSet<grid> grid { get; set; }
        public virtual DbSet<piloto> piloto { get; set; }
        public virtual DbSet<temporada> temporada { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<usuario_token> usuario_token { get; set; }
    }
}
