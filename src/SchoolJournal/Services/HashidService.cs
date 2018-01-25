<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HashidsNet;
=======
﻿using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> 4929d347b74de476c734a677c60cdcf70b2973f8

namespace SchoolJournal.Services
{
    public class HashidService : IHashidsService
    {
        private readonly Hashids _hashids;
        private readonly string salt = "This is spaartaaaaa";
        private readonly int num = 6;

        public HashidService()
        {
            _hashids = new Hashids(salt: salt, minHashLength: num);
        }

        public int Decode(string cachedId)
        {
            return _hashids.Decode(cachedId)[0];
        }

        public string Encode(int id)
        {
            return _hashids.Encode(id);
        }
    }
}