using System.Collections.Generic;
using SchoolJournal.Domain;


namespace SchoolJournal.Data.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Get(int id);
        void Add(Student student);
    }
}