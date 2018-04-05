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
        private readonly ISchoolClassSubjectRepository _schoolClassSubjectRepository;

        public TeacherSchoolClassSubjectRepository()
        {
            _context = new ApplicationDbContext();
            _schoolClassSubjectRepository = new SchoolClassSubjectRepository();
        }


        ////CHECHKING PART OF CODE////
        //Get all SchoolClassSubject entries by selected Teacher using id
        public async Task<List<SchoolClassSubject>> GetSchoolClassSubjectsByTeacherId(int teacherId)
        {
            List<SchoolClassSubject> result = await _context.TeacherSchoolClassSubjects.Where(x => x.TeacherId == teacherId).Select(z => z.SchoolClassSubject).ToListAsync();
            return result;
        }
        ////CHECHKING PART OF CODE////







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

        //Adding new entry between Teacher-And-SchoolClassSubject in table TeacherSchoolClassSubject
        public void AddNewEntry(int teacherId, int schoolClassId, int subjectId)
        {
            int entryId =_schoolClassSubjectRepository.CheckEntryBetweenSchoolClassAndSubjectInDataBase(schoolClassId, subjectId);
            if (entryId != 0) //Creating entry in table TeacherSchoolClassSubjects
            {
                _context.TeacherSchoolClassSubjects.Add(new TeacherSchoolClassSubject { SchoolClassSubjectId = entryId, TeacherId = teacherId });
                _context.SaveChangesAsync();
            }
            else if (entryId == 0) // If entry between SchoolClass-And-Subject doesnt exists, create it and add entry to table TeacherSchoolClassSubjects
            {
                _schoolClassSubjectRepository.AddNewEntry(schoolClassId, subjectId);
                _context.TeacherSchoolClassSubjects.Add(new TeacherSchoolClassSubject { SchoolClassSubjectId = entryId, TeacherId = teacherId });
                _context.SaveChangesAsync();
            }
        }

        //Removes entry in tabel TeacherSchoolClassSubject between Teacher and SchoolClassSubject
        public async void RemoveConnection(int teacherId, int schoolClassId, int subjectId)
        {
            int schoolClassSubjectId = _schoolClassSubjectRepository.CheckEntryBetweenSchoolClassAndSubjectInDataBase(schoolClassId, subjectId);
            _context.TeacherSchoolClassSubjects.Remove(await _context.TeacherSchoolClassSubjects.Where(x=>x.TeacherId==teacherId && x.SchoolClassSubjectId== schoolClassSubjectId).FirstOrDefaultAsync());
        }

        //Checking is exists entry between Teacher-And-SchoolClassSubject in table TeacherSchoolClassSubject
        public async Task<int> CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(int teacherId, int schoolClassId, int SubjectId)
        {
            int entrySclClsSubjRes = _schoolClassSubjectRepository.CheckEntryBetweenSchoolClassAndSubjectInDataBase(schoolClassId, SubjectId);

            var result = await _context.TeacherSchoolClassSubjects.Where(x => x.TeacherId == teacherId && x.SchoolClassSubjectId == entrySclClsSubjRes).FirstOrDefaultAsync();
            //int result = await _context.TeacherSchoolClassSubjects.Where(x => x.TeacherId == teacherId && x.SchoolClassSubjectId== entrySclClsSubjRes).Select(t=>t.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}