using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    internal class Student
    {
        Person pers;
        Education educ;
        int numGroup;
        Exam[] exams;
        public Student(Person pers, Education educ, int numGroup, Exam[] exams)
        {
            Pers = pers;
            Educ = educ;
            NumGroup = numGroup;
            Exams = exams;
        }
        public Student() : this(new Person(), Education.Specialist, 1, new Exam[] { new Exam() }) { }
        public Person Pers
        {
            get => this.pers;
            set
            {
                if (value == null) throw new ArgumentNullException("Данные о человеке являются пустыми!");
                this.pers = value;
            }
        }
        public Education Educ
        {
            get => this.educ;
            set => this.educ = value;
        }
        public int NumGroup
        {
            get => this.numGroup;
            set {
                if (this.numGroup < 1) throw new ArgumentException("Номер группы не может быть меньше 1!");
                this.numGroup = value; 
            }
        }
        public Exam[] Exams
        {
            get => this.exams;
            set
            {
                if (value == null) throw new ArgumentNullException("Массив является пустым!");
                this.exams = value;
            }
        }
        public double Avg
        {
            get
            {
                double avg = 0;
                Array.ForEach(exams, exam => avg += exam.Grade);
                return avg / exams.Length;
            }
        }
        public bool this[Education i] { get => Educ == i; }
        public void AddExam(params Exam[] exams)
        {
            Exam[] newExams = new Exam[exams.Length + Exams.Length];
            Exams.CopyTo(newExams, 0);
            exams.CopyTo(newExams, Exams.Length);
            Exams = newExams;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Pers}, образование: {Educ}, номер группы: {NumGroup}. Экзамены:\n");
            Array.ForEach(exams, exam => sb.Append(exam + "\n"));
            return sb.ToString();
        }
        public virtual string ToShortString() => $"{Pers}, образование: {Educ}, номер группы: {NumGroup}, средний бал: {Avg}.";
    }
}
