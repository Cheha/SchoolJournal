using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Services
{
    interface IHashidsService
    {
        string Encode(int id);
        int Decode(string cachedId);
    }
}
