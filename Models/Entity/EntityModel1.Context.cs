﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok_Project.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcStokDBEntities1 : DbContext
    {
        public MvcStokDBEntities1()
            : base("name=MvcStokDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategoriler_TBL> Kategoriler_TBL { get; set; }
        public virtual DbSet<Musteriler_TBL> Musteriler_TBL { get; set; }
        public virtual DbSet<Satislar_TBL> Satislar_TBL { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urunler_TBL> Urunler_TBL { get; set; }
    }
}
