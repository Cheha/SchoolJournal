using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJounal.Model;
using SchoolJounal.Data;

namespace SchoolJounal.Repository
{

    public class TeacherRepository : ITeacherRepository
    {
        private AppContext _context;

        public TeacherRepository()
        {
            _context = new AppContext();
        }

        public Teacher GetTeacher(int Id)
        {
            return _context.Teachers.Find(Id);
        }
    }
}
