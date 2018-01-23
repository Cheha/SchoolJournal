using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data.repositories
{
    public interface IStudentRepository
    {
        List<Student> Get();
        Student GetOne(int iD);
        void Add(Student student);
    }
}