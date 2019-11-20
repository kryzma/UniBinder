using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.DependencyInjection
{
    public class PersonDI
    {
        public IPersonReader _personReader;

        public PersonDI(IPersonReader personReader)
        {
            _personReader = personReader;
        }

        public List<Person> GetPeople()
        {
            return _personReader.GetAllPeople();
        }

    }
}