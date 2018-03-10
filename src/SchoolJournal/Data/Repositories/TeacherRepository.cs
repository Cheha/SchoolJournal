﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;

//Класний керівник має доступ до 
//всіх оцінок і предметів свого класу.
// (1-V) Тобто треба добавити ще одну роль - глянеш, як Саша зробив.
// (2) І відповідно в класі шкільного класу треба зробити foreign key на вчителя, який буде класним керівником.

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
        public Teacher GetTeacher(int Id)
        {
            return _context.Teachers.Find(Id);
        }

        // GetAllTeachers
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        //Create teacher
        public void CreateTeacher(Teacher newTeacher)
        {
            _context.Teachers.Add(newTeacher);
            _context.SaveChanges();
        }

        //Delete teacher
        public void DeleteTeacher(int id)
        {
            _context.Teachers.Remove(_context.Teachers.Where(x => x.Id == id).Single());
            _context.SaveChanges();
        }

        //Update teacher
        public void UpdateTeacher(Teacher model)  // НЕт нужды т.к. context один и тот же
        {
            _context.Teachers.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void UpdateTeacher(Teacher model) // Лишний запрос в БД.
        //{
        //    Teacher temp = _context.Teachers.Where(x => x.Id == model.Id).Single();
        //    temp.FirstName = model.FirstName;
        //    temp.LastName = model.LastName;
        //    _context.SaveChanges();
        //}

        //Add class for teacher
        public void AddNewTeacherSchoolClass(SchoolClass newSchoolClass, Teacher thisTeacher)
        {
            _context.TeacherSchoolClasses.Add(new TeacherSchoolClass() { Teacher = thisTeacher, SchoolClass = newSchoolClass });
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

        //Get list of teachers classes
        public List<TeacherSchoolClass> GetListOfTeacherClasses(int teacherId)
        {
            return _context.TeacherSchoolClasses.Include("SchoolClass").Where(x => x.TeacherId == teacherId).ToList();
        }
    }
}