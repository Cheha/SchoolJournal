using Microsoft.AspNet.Identity.EntityFramework;
using SchoolJounal.Model;
using SchoolJournal.Domain;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<SchoolClassSubject> SchoolClassSubjects { get; set; }
        public DbSet<TeacherSchoolClass> TeacherSchoolClasses { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
      //      : base("SchoolClassDB", throwIfV1Schema: false)
            
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}