using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Exam
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public Exam(string name, int grade, DateTime date)
        {
            Name = name;
            Grade = grade;
            Date = date;
        }
        public Exam()
        {
            Name = "Noname";
            Grade = 0;
            Date = DateTime.Today;
        }
        public override string ToString() => $"Название предмета: {Name}, оценка за экзамен: {Grade}, дата проведение экзамена: {Date.Date}.";
    }
}
