using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolJournal.Data;
using SchoolJournal.Domain;
using System.Data.Entity;

namespace SchoolJournal
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            AddDefaultRolesAndUser(context);

            base.Seed(context);
        }

        private void AddDefaultRolesAndUser(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole("admin");
            var teacherRole = new IdentityRole("teacher");

            roleManager.Create(adminRole);
            roleManager.Create(teacherRole);

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
                userManager.AddToRole(userAdmin.Id, teacherRole.Name);
            }
        }
    }
}