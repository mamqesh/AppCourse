﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppTasks.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class danil2Entities2 : DbContext
    {
        public danil2Entities2()
            : base("name=danil2Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admininstrator> Admininstrator { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionText> OptionText { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Sex> Sex { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
    }
}
