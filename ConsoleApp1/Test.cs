using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Test
    {
        public string NameSubject { get; set; }
        public bool TestPassed { get; set; }
        public Test(string nameSubject, bool testPassed)
        {
            NameSubject = nameSubject;
            TestPassed = testPassed;
        }
        public Test() : this("NoName", false) 
        {

        }
        public override string ToString() => $"Предмет: {NameSubject}, Зачёт: {TestPassed}";
    }
}
