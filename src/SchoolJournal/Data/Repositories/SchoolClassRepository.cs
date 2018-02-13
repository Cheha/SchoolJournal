using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        ApplicationDbContext _context;

        public SchoolClassRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void AddSchoolClass(SchoolClass schoolClass)
        {
            _context.SchoolClasses.Add(schoolClass);
        }

        public List<SchoolClass> GetSchoolClassList()
        {
            List<SchoolClass> SchoolClassList = _context.SchoolClasses.ToList();
            return SchoolClassList;
        }


        public List<Student> GetStudentsList(int schoolClassId)
        {
            List<Student> studentsList = _context.Students
                .Include("SchoolClass")
                .Where(p => p.SchoolClassId == schoolClassId).ToList();
            return studentsList;
        }

        public List<Subject> GetSubjectsList(int schoolClassId)
        {

            List<SchoolClassSubject> SchoolClassSubject = _context.SchoolClassSubjects
                .Include("Subject")
                .Where(p => p.SchoolClassId == schoolClassId)
                .ToList();


            return SchoolClassSubject.Select(p => p.Subject).ToList();
        }
    }
}