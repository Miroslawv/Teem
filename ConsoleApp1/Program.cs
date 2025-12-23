using System.Collections;
using System.ComponentModel.Design.Serialization;
using ConsoleApp1;

Person p1 = new();
Person p2 = new();
Console.WriteLine(p1 == p2);
Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p2.GetHashCode());

Student s1 = new(new Person("Name", "Surname", new DateTime(2000, 1, 1)), Education.Specialist, 392);
s1.AddExam(
    new Exam("Subject1", 2, new DateTime(2000, 1, 2)),
    new Exam("Subject2", 3, new DateTime(2000, 1, 3)),
    new Exam("Subject3", 6, new DateTime(2000, 1, 4)));
s1.Tests.AddRange(new Test[]
{
    new Test("Subject1", false),
    new Test("Subject2", true),
    new Test("Subject3", true)
});

Student s2 = s1.DeepCopy() as Student;
s1.AddExam(
    new Exam("Subject4", 7, new DateTime(2000, 1, 5)),
    new Exam("Subject5", 8, new DateTime(2000, 1, 6)),
    new Exam("Subject6", 9, new DateTime(2000, 1, 7)));
Console.WriteLine(s1);
Console.WriteLine(s2);

try { s2.NumGroup = 99; }
catch(ArgumentException ex) { Console.WriteLine(ex.Message); }

foreach (object o in s1.GetEnumeratorTestsExams()) Console.WriteLine(o);

foreach (Exam e in s1.GetEnumeratorExamsGrade(3)) Console.WriteLine(e);

foreach (string s in s1) Console.WriteLine(s);

foreach (object o in s1.GetEnumeratorPassedExamsTests()) Console.WriteLine(o);

foreach (Test t in s1.GetEnumeratorPassedTest()) Console.WriteLine(t);
