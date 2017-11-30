using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJounal.Model;

namespace SchoolJounal.Repository
{
    public interface ITeacherRepository
    {
        Teacher GetTeacher(int Id);
    }
}
