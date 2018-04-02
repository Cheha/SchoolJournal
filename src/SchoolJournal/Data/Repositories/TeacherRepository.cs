using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;
using System.Threading.Tasks;

namespace SchoolJournal.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private ApplicationDbContext _context;
        public TeacherRepository()
        {
            _context = new ApplicationDbContext();
        }

        //Get Teacher
        public async Task<Teacher> GetTeacher(int Id)
        {
            return await _context.Teachers.FindAsync(Id);
        }

        // GetAllTeachers
        public Task<List<Teacher>> GetAllTeachers()
        {
            return _context.Teachers.ToListAsync();
        }

        //Create teacher
        public void CreateTeacher(Teacher newTeacher)
        {
            _context.Teachers.Add(newTeacher);
            _context.SaveChanges();
        }

        //Delete teacher
        public async void DeleteTeacher(int id)
        {
            _context.Teachers.Remove( await _context.Teachers.Where(x => x.Id == id).SingleOrDefaultAsync());
            _context.SaveChanges();
        }

        //Update teacher
        public void UpdateTeacher(Teacher model)  // Нет нужды т.к. context один и тот же и модель уже есть в нём
        {
            _context.Teachers.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Add subjects for teacher
        public void AddNewTeacherSubject(Subject newSubject, Teacher teacher)
        {
           _context.TeacherSubjects.Add(new TeacherSubject() { Teacher = teacher, Subject = newSubject });
            _context.SaveChanges();
        }

        //Get list of teachers subjects
        public List<TeacherSubject> GetListOfTeachersSubjects(int teacherId)
        {
            return _context.TeacherSubjects.Include("Subject").Where(x => x.TeacherId == teacherId).ToList();
        }

        //Get list of Teacher classes and Subjects
        public List<TeacherSchoolClassSubject> GetListOfTeacherSchoolClassSubjects(int teacherId)
        {
            return _context.TeacherSchoolClassSubjects.Include("Teacher").Include("SchoolClassSubject").Where(x => x.TeacherId == teacherId).ToList();
        }

        //Get Teacher by usedId
        public async Task<Teacher> GetTeacherByUserId(string userId)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.UserId == userId);
        }
    }
}