﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Meet> Meets { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
    }
}
