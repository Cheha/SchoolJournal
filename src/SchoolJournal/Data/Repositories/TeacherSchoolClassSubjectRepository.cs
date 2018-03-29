using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;
using System.Threading.Tasks;

namespace SchoolJournal.Data.Repositories
{
    public class TeacherSchoolClassSubjectRepository : ITeacherSchoolClassSubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherSchoolClassSubjectRepository()
        {
            _context = new ApplicationDbContext();
        }

        //Get list TeacherSchoolClassSubject by selected Teacher
        public List<TeacherSchoolClassSubject> GetListOfTeacherSchoolClassSubjects(int teacherId)
        {
            return _context.TeacherSchoolClassSubjects.Include("Teacher").Include("SchoolClassSubject").Where(x => x.TeacherId == teacherId).ToList();
        }


    }
}