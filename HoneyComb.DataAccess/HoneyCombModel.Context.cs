﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoneyComb.BusinessObjects
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HoneyCombEntities : DbContext
    {
        public HoneyCombEntities()
            : base("name=HoneyCombEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MCR_ANSWERS> MCR_ANSWERS { get; set; }
        public DbSet<MCR_ASSESSMENT> MCR_ASSESSMENT { get; set; }
        public DbSet<MCR_ASSESSMENT_WEIGHT> MCR_ASSESSMENT_WEIGHT { get; set; }
        public DbSet<MCR_CITY> MCR_CITY { get; set; }
        public DbSet<MCR_CONTENT> MCR_CONTENT { get; set; }
        public DbSet<MCR_CONTENT_ALLOCATE> MCR_CONTENT_ALLOCATE { get; set; }
        public DbSet<MCR_CONTENT_ENCRYPTION> MCR_CONTENT_ENCRYPTION { get; set; }
        public DbSet<MCR_CONTENT_INFO> MCR_CONTENT_INFO { get; set; }
        public DbSet<MCR_CONTENT_LOCATION> MCR_CONTENT_LOCATION { get; set; }
        public DbSet<MCR_CONTENT_TYPE> MCR_CONTENT_TYPE { get; set; }
        public DbSet<MCR_COUNTRY> MCR_COUNTRY { get; set; }
        public DbSet<MCR_DISTRICT> MCR_DISTRICT { get; set; }
        public DbSet<MCR_EXAM_BOARD> MCR_EXAM_BOARD { get; set; }
        public DbSet<MCR_GRADE> MCR_GRADE { get; set; }
        public DbSet<MCR_LANGUAGE_LEVEL> MCR_LANGUAGE_LEVEL { get; set; }
        public DbSet<MCR_LOGIN> MCR_LOGIN { get; set; }
        public DbSet<MCR_PERSONS> MCR_PERSONS { get; set; }
        public DbSet<MCR_PROVINCE> MCR_PROVINCE { get; set; }
        public DbSet<MCR_QUESTION_TYPE> MCR_QUESTION_TYPE { get; set; }
        public DbSet<MCR_QUESTIONS> MCR_QUESTIONS { get; set; }
        public DbSet<MCR_ROLES> MCR_ROLES { get; set; }
        public DbSet<MCR_SCHOOL> MCR_SCHOOL { get; set; }
        public DbSet<MCR_SCHOOL_LEVEL> MCR_SCHOOL_LEVEL { get; set; }
        public DbSet<MCR_SCHOOL_TYPE> MCR_SCHOOL_TYPE { get; set; }
        public DbSet<MCR_SUBJECT> MCR_SUBJECT { get; set; }
        public DbSet<MCR_SUBJECT_GROUP> MCR_SUBJECT_GROUP { get; set; }
        public DbSet<MCR_WEIGHT_LEVEL> MCR_WEIGHT_LEVEL { get; set; }
    }
}
