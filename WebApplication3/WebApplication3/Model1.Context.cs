﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HRDatabaseEntities : DbContext
    {
        public HRDatabaseEntities()
            : base("name=HRDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }
        public virtual DbSet<HRTable> HRTables { get; set; }
        public virtual DbSet<JobTable> JobTables { get; set; }
        public virtual DbSet<JobPositionTable> JobPositionTables { get; set; }
        public virtual DbSet<DepartmentPositionTable> DepartmentPositionTables { get; set; }
        public virtual DbSet<FieldInfoTable> FieldInfoTables { get; set; }
    }
}
