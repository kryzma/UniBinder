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
        public int SubjectArrayLenght
        {
            get { return subjectArray.Length; }
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
            Console.WriteLine($"Person subjects are: {personSubjects}");
            //int lenght = SubjectArrayLenght;
            //for(i = 0; i<= lenght-1; i++)
            //{
            //Console.WriteLine(subjectArray[i]);
            //}
        }
    }
}
