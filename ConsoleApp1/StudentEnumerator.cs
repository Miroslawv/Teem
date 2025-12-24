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
    internal class StudentEnumerator : IEnumerator<string>
    {
        List<string> Names;
        int position = -1;
        public StudentEnumerator(ArrayList Exams, ArrayList Tests)
        {
            Names = new List<string>();
            foreach (Exam i in Exams)
                foreach (Test j in Tests)
                    if (i.Name == j.NameSubject) Names.Add(i.Name);
        }
        public bool MoveNext()
        {
            if (position < Names.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public string Current
        {
            get
            {
                if (position == -1 || position >= Names.Count) throw new ArgumentException("Выход за длину списка!");
                return Names[position];
            }
        }
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public void Reset() => position = -1;
    }
}
