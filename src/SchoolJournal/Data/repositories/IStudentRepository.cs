using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data.repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Get(int id);
        void Add(Student student);
    }
}