using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class SubjectArrayManager
    {
        private readonly string[] subjectArray = new string[9];

        [Flags]
        enum Subjects
        {
            C = 1,
            CS = 2,
            CPP = 4,
            JAVA = 8,
            JAVASCRIPT = 16,
            MATH = 32,
            PASCAL = 64,
            PHP = 128,
            PYTHON = 256
        }
        public short SubjectArrayLenght
        {
            get { short i = (short)subjectArray.Length;
                return i; }
        }

        public string this[int index]
        {
            get
            {
                return subjectArray[index];
            }
            set
            {
                subjectArray[index] = value;
            }
        }

        public void AddSubjectsToArray()
        {
            int i = 0;
            foreach (string str in Enum.GetNames(typeof(Subjects)))
            {
                subjectArray[i] = str;
                i++;
            }
            Subjects personSubjects = Subjects.C | Subjects.JAVA | Subjects.MATH;
            //Console.WriteLine($"Person subjects are: {personSubjects}");

            if (personSubjects.HasFlag(Subjects.JAVA))
            {
                //Console.WriteLine("Person knows JAVA");
            }

            //widening
            short i1 = 5;
            int i2 = i1;

            checked
            {
                //narrowing
                short i3 = (short)i2;
            }
            GetValue(2, "asd");
            GetValue(2, "asd", "asd");
            GetValue(3, "asdas", age:2);
            

        }

        private void GetValue(int value, string name, string email ="", int age =0)
        {
            Console.WriteLine(email);
            Console.WriteLine(value);
            Console.WriteLine(name);
            Console.WriteLine(age);
        }
    }
}
