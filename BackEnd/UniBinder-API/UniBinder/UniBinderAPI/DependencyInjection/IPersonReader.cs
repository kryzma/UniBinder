using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.DependencyInjection
{
    public interface IPersonReader
    {
        List<Person> GetAllPeople();
    }
}
