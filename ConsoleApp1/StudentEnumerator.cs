using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StudentEnumerator : IEnumerator
    {
        ArrayList examsTests;
        int position = -1;
        public StudentEnumerator(ArrayList Exams, ArrayList Tests)
        {
            examsTests = new ArrayList();
            foreach (Exam i in Exams)
                foreach (Test j in Tests)
                    if (i.Name == j.NameSubject)
                    { examsTests.Add(i); examsTests.Add(j); }
        }
        public bool MoveNext()
        {
            if (position < examsTests.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= examsTests.Count) throw new ArgumentException("Выход за длину списка!");
                return examsTests[position] is Exam e ? e.Name : (examsTests[position] as Test).NameSubject;
            }
        }
        public void Reset() => position = -1;
    }
}
