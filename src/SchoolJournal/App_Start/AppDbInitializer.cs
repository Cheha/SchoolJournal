using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolJournal.Data;
using SchoolJournal.Domain;
using System;
using System.Collections.Generic;
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
            var userTeacher = new ApplicationUser
            {
                Email = "teacher@gmail.com",
                UserName = "teacher@gmail.com"
            };

            string passwordTeacher = "123456";

            result = userManager.Create(userTeacher, passwordTeacher);

            if (result.Succeeded)
            {
                userManager.AddToRole(userTeacher.Id, teacherRole.Name);
            }

            var teacher = new Teacher
            {
                FirstName = "Ucha",
                LastName = "Uchilkina",
                UserId = userTeacher.Id
            };
            context.Teachers.Add(teacher);

            var sc5A = new SchoolClass { Name = "5A" };
            context.SchoolClasses.Add(sc5A);

            // Students
            var st1 = new Student
            {
                FirstName = "Fedir",
                LastName = "Melnychenko",
                SchoolClass = sc5A
            };
            context.Students.Add(st1);

            var st2 = new Student
            {
                FirstName = "Ostap",
                LastName = "Myronenko",
                SchoolClass = sc5A
            };
            context.Students.Add(st2);

            // Subjects
            var math = new Subject { Name = "Mathematic" };
            context.Subjects.Add(math);

            var geom = new Subject { Name = "Geometry" };
            context.Subjects.Add(geom);

            context.TeacherSubjects.Add(new TeacherSubject {
                Teacher = teacher,
                Subject = math
            });
            context.TeacherSubjects.Add(new TeacherSubject
            {
                Teacher = teacher,
                Subject = geom
            });

            context.SchoolClassSubjects.Add(
                new SchoolClassSubject {
                    SchoolClass = sc5A,
                    Subject = math
                }
            );
            context.SchoolClassSubjects.Add(
                new SchoolClassSubject
                {
                    SchoolClass = sc5A,
                    Subject = geom
                }
            );

            context.SaveChanges();

            // Marks
            var marks = new List<Mark>
            {
                new Mark{
                    Date = DateTime.Today,
                    StudentId = st1.Id,
                    SubjectId = math.Id,
                    Value = 10
                },
                new Mark{
                    Date = DateTime.Today.AddDays(-1),
                    StudentId = st1.Id,
                    SubjectId = math.Id,
                    Value = 11
                },
                new Mark{
                    Date = DateTime.Today.AddDays(-5),
                    StudentId = st1.Id,
                    SubjectId = math.Id,
                    Value = 3
                },
                new Mark{
                    Date = DateTime.Today,
                    StudentId = st2.Id,
                    SubjectId = math.Id,
                    Value = 9
                }
            };

            context.Marks.AddRange(marks);

            context.SaveChanges();
        }
    }
}