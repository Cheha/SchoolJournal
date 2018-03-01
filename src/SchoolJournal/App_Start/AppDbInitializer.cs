using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolJournal.Data;
using SchoolJournal.Data.Repository;
using SchoolJournal.Domain;
using System.Data.Entity;

namespace SchoolJournal
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            AddDefaultRolesAndUsers(context);
            base.Seed(context);
        }

        private void AddDefaultRolesAndUsers(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser> (context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Default roles
            var adminRole = new IdentityRole("admin");
            var teacherRole = new IdentityRole("teacher");
            var classteacherRole = new IdentityRole("classteacher");

            roleManager.Create(adminRole);
            roleManager.Create(teacherRole);
            roleManager.Create(classteacherRole);

            // Admin
            var userAdmin = new ApplicationUser
            {
                Email = "schooljournal@gmail.com",
                UserName = "schooljournal@gmail.com"
            };

            string passwordAdmin = "123456";

            var result = userManager.Create(userAdmin, passwordAdmin);

            if (result.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, adminRole.Name);
            }

            // Teacher
            var teacherRepository = new TeacherRepository();

            var teacher = new Teacher
            {
                FirstName = "Ucha",
                LastName = "Uchilkina"
            };

            teacherRepository.CreateTeacher(teacher);

            var userTeacher = new ApplicationUser
            {
                Email = "teacher@gmail.com",
                UserName = "teacher@gmail.com",
                Teacher = teacher
            };

            string passwordTeacher = "123456";

            result = userManager.Create(userTeacher, passwordTeacher);

            if (result.Succeeded)
            {
                userManager.AddToRole(userTeacher.Id, teacherRole.Name);
            }
        }
    }
}