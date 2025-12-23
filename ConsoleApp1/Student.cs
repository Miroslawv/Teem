using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    internal class Student : Person, IDateAndCopy, IEnumerable
    {
        Education educ;
        int numGroup;
        ArrayList tests;
        ArrayList exams;
        public Student(Person pers, Education educ, int numGroup, ArrayList exams, ArrayList tests)
        {
            Pers = pers;
            Educ = educ;
            NumGroup = numGroup;
            Exams = exams;
            Tests = tests;
        }
        public Student(Person pers, Education educ, int numGroup) : this(pers, educ, numGroup, new ArrayList(), new ArrayList()) { }
        public Student() : this(new Person(), Education.Specialist, 1, new ArrayList(), new ArrayList()) { }
        public Person Pers
        {
            get => new Person(Name, Surname, Date);
            set
            {
                if (value is null) throw new ArgumentNullException("Данные о человеке являются пустыми!");
                this.Name = value.Name;
                this.Surname = value.Surname;
                this.Date = value.Date;
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
                if (value < 100 || value > 599) throw new ArgumentException("Номер группы не может быть меньше 100 или больше 599!");
                this.numGroup = value; 
            }
        }
        public ArrayList Exams
        {
            get => this.exams;
            set
            {
                if (value is null) throw new ArgumentNullException("Список экзаменов не может быть пустым!");
                foreach (var item in value) if (!(item is Exam)) throw new ArgumentException("В списке экзаменов не может быть элемента не экзамена!"); 
                this.exams = value;
            }
        }
        public ArrayList Tests
        {
            get => this.tests;
            set
            {
                if (value is null) throw new ArgumentNullException("Список тестов не может быть пустым!");
                foreach (var item in value) if (!(item is Test)) throw new ArgumentException("В списке тестов не может быть элемента не теста!");
                this.tests = value;
            }
        }
        public double Avg
        {
            get
            {
                double avg = 0;
                foreach (Exam exam in Exams) avg += exam.Grade;
                return Math.Round(avg / Exams.Count, 2);
            }
        }
        public bool this[Education i] { get => Educ == i; }
        public IEnumerable<object> GetEnumeratorTestsExams()
        {
            ArrayList exte = [];
            exte.AddRange(this.Tests);
            exte.AddRange(this.Exams);
            foreach (object item in exte) yield return item;
        }
        public IEnumerable<Exam> GetEnumeratorExamsGrade(int grade)
        {
            ArrayList ExamsGrade = [];
            foreach (Exam ex in this.Exams)
            {
                if (ex.Grade > grade)
                {
                    ExamsGrade.Add(ex);
                }
            }
            foreach (Exam ex in ExamsGrade) yield return ex;
        }
        public IEnumerator GetEnumerator() => new StudentEnumerator(this.Exams, this.Tests);
        public IEnumerable<object> GetEnumeratorPassedExamsTests()
        {
            foreach(object item in this.GetEnumeratorTestsExams()) 
                if (item is Test t && t.TestPassed) yield return item;
                else if (item is Exam e && e.Grade > 2) yield return item;
        }
        public IEnumerable<Test> GetEnumeratorPassedTest()
        {
            Test t = new();
            Exam e = new();
            foreach (object o in this.GetEnumeratorTestsExams())
            {
                if (o is Test t1) t = t1;
                else if (o is Exam e1) e = e1;
                if (t.NameSubject == e.Name)
                    if (t.TestPassed && e.Grade > 2) yield return t;
            }
        }
        public void AddExam(params Exam[] exams) => Exams.AddRange(exams);
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Pers}, образование: {Educ}, номер группы: {NumGroup}. Экзамены:\n");
            foreach(Exam exam in exams) sb.Append(exam + "\n");
            sb.Append("Тесты:\n");
            foreach (Test test in tests) sb.Append(test + "\n");
            return sb.ToString();
        }
        public virtual string ToShortString() => $"{Pers}, образование: {Educ}, номер группы: {NumGroup}, средний бал: {Avg}.";
        public override bool Equals(object? obj)
        {
            if (obj is  null || !(obj is Student st)) return false;
            else if (this.Pers == st.Pers && this.Educ == st.Educ && this.NumGroup == st.NumGroup)
                if (this.Exams.Count == st.Exams.Count)
                    for (int i = 0; i < this.Exams.Count; i++)
                        if (this.Exams[i] != st.Exams[i]) return false;
            else return false;
            return true;
        }
        public static bool operator ==(Student? st1, Student? st2) => st1 is null ? st2 is null : st1.Equals(st2);
        public static bool operator !=(Student? st1, Student? st2) => st1 is null ? st2 is not null : !st1.Equals(st2);
        public override int GetHashCode()
        {
            try
            {
                if (this is null) base.GetHashCode();
                else
                {
                    int hash = Pers.GetHashCode() + Educ.GetHashCode() + numGroup.GetHashCode();
                    foreach (var e in Exams) hash += e.GetHashCode();
                    foreach (var e in Tests) hash += e.GetHashCode();
                    return hash.GetHashCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return base.GetHashCode();
        }
        public override object DeepCopy()
        {
            Student st = new(new Person(this.Pers.Name, this.Pers.Surname, this.Pers.Date), Educ, NumGroup, new ArrayList(), new ArrayList());
            st.Exams.AddRange(this.Exams);
            st.Tests.AddRange(this.Tests);
            return st;
        }
    }
}
