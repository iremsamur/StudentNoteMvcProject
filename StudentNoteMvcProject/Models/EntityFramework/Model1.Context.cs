//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentNoteMvcProject.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SCHOOLEntities1 : DbContext
    {
        public SCHOOLEntities1()
            : base("name=SCHOOLEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLUBS> CLUBS { get; set; }
        public virtual DbSet<LESSONS> LESSONS { get; set; }
        public virtual DbSet<NOTES> NOTES { get; set; }
        public virtual DbSet<STUDENTS> STUDENTS { get; set; }
    }
}
