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
        public Task<List<TeacherSchoolClassSubject>> GetListOfTeacherSchoolClassSubjects(int teacherId)
        {
            return _context.TeacherSchoolClassSubjects.Include("Teacher").Include("SchoolClassSubject").Where(x => x.TeacherId == teacherId).ToListAsync();
        }

        //Get Teacher by SchoolClass and Subject
        public async Task<Teacher> GetTeacherBySubjectAndSchoolClass(int subjectId, int schoolClassId)
        {
            SchoolClassSubject result = await _context.SchoolClassSubjects.Where(x => x.SchoolClass.Id == schoolClassId && x.Subject.Id == subjectId).FirstOrDefaultAsync();
            if (result != null)
            {
                var resultTeacher = await _context.TeacherSchoolClassSubjects.Include("Teacher").Where(x => x.SchoolClassSubjectId == result.Id).Select(x => x.Teacher).FirstOrDefaultAsync();
                return resultTeacher;
            }
            else
            {
                return null;
            }
        }
    }
}