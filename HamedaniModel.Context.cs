﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HamedaniProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HamedaniProjectNewEntities : DbContext
    {
        public HamedaniProjectNewEntities()
            : base("name=HamedaniProjectNewEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerTable> CustomerTables { get; set; }
        public virtual DbSet<MembershipTypeTable> MembershipTypeTables { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<MoviesTable> MoviesTables { get; set; }
    }
}
