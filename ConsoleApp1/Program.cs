using ConsoleApp1;
//1

Person p1 = new Person();
Person p2 = new Person("Екатерина", "Ивановна", new DateTime(1998, 5, 12));

Console.WriteLine(p1);
Console.WriteLine(p2);

p1.ToShortString();
p2.ToShortString();

//2

Person p3 = new Person("Анна", "Сидорова", new DateTime(2000, 3, 15));

p3.Date2 = 1999;

Console.WriteLine(p3);

//3

Exam exam = new Exam("ООП", 9, new DateTime(2025, 1, 20));
Console.WriteLine(exam);
exam.Name = "Информационная безопасность";
exam.Grade = 10;
exam.Date = new DateTime(2025, 1, 25);
Console.WriteLine(exam);

//4

Student student1 = new Student(new Person("Екатерина", "Смирнова", new DateTime(2001, 5, 10)), Education.Specialist, 101, new Exam[0]);
Console.WriteLine("1");
Console.WriteLine(student1);
Console.WriteLine(student1.ToShortString());

student1.Educ = Education.Bachelor;
student1.NumGroup = 202;
Console.WriteLine(student1.ToShortString());

//5

Student student2 = new Student(new Person("Иван", "Петров", new DateTime(2002, 6, 10)), Education.Bachelor, 202, new Exam[0]);
Console.WriteLine(student2[Education.Specialist]);
Console.WriteLine(student2[Education.Bachelor]);
Console.WriteLine(student2[Education.SecondEducation]);

//6

Student student3 = new Student();

student3.Pers.Name = "Мария";
student3.Pers.Surname = "Кузнецова";
student3.Pers.Date = new DateTime(2000, 3, 14);
student3.Educ = Education.Bachelor;
student3.NumGroup = 305;

student3.AddExam(new Exam("Базы данных", 7, new DateTime(2025, 2, 10)), new Exam("Сети", 8, new DateTime(2025, 2, 8)));

Console.WriteLine(student3.ToShortString());

//7
Exam[] e = new Exam[2];
e[0] = new Exam("ООП", 9, new DateTime(2025, 1, 18));
e[1] = new Exam("Право ИБ", 10, new DateTime(2025, 1, 21));
Student student4 = new Student(new Person("Екатерина", "Орлова", new DateTime(1999, 7, 1)), Education.SecondEducation, 42, e);
Console.WriteLine(student4.ToShortString());

//8

Exam[] e2 = new Exam[3];
e2[0] = new Exam("АиП", 6, DateTime.Today);
DateTime t = DateTime.Today;

e2[1] = new Exam("Алгебра", 8, t.AddDays(-1));
e2[2] = new Exam("Физика", 7, t.AddDays(-2));
Student student5 = new Student(new Person("Анна", "Лебедева", new DateTime(2001, 2, 2)), Education.Bachelor, 123, e2);
Console.WriteLine(student5.ToShortString());

//9

Student student6 = new Student(new Person("Екатерина", "Павлова", new DateTime(2002, 11, 3)), Education.Specialist, 221, new Exam[0]);

Console.WriteLine(student6.ToShortString());

Console.WriteLine(student2[Education.Specialist]);
Console.WriteLine(student2[Education.Bachelor]);
Console.WriteLine(student2[Education.SecondEducation]);

student6.Educ = Education.Bachelor;
student6.NumGroup = 333;
student6.AddExam(new Exam("Проектирование ПО", 9, new DateTime(2025, 2, 22)));



Console.WriteLine(student6);

student6.AddExam(new Exam("Теория вычислительных процессов", 8, new DateTime(2025, 2, 25)));
student6.AddExam(new Exam("Иб и право", 8, new DateTime(2025, 2, 27)));
Console.WriteLine(student6);

//10

Exam[] exam10 = new Exam[2];

Student student7 = new Student(new Person("Анна", "Лебедева", new DateTime(2001, 2, 2)), Education.Bachelor, 101, new Exam[]
{
    new Exam("ООП", 8, DateTime.Today),
    new Exam("Алгоритмы", 9, DateTime.Today.AddDays(-1))
});

Exam[] exam11 = new Exam[1];
exam11[0] = new Exam("Сети", 7, DateTime.Today);
Student student8 = new Student(new Person("Борис", "Михайлов", new DateTime(2000, 3, 3)), Education.Specialist, 102, new Exam[] {
    new Exam("Сети", 7, DateTime.Today)
});

Exam[] exam12 = new Exam[3];


Student student9 = new Student(new Person("Екатерина", "Соловьева", new DateTime(1999, 4, 4)), Education.SecondEducation, 103, new Exam[] {
    new Exam("Иб", 10, DateTime.Today),
    new Exam("Право", 10, DateTime.Today.AddDays(-2)),
    new Exam("Архитектура ПО", 9, DateTime.Today.AddDays(-3))
});

Student[] st = new Student[3];
st[0] = student7;
st[1] = student8;
st[2] = student9;

Student temp;


Console.WriteLine(st[0].Avg);
Console.WriteLine(st[1].Avg);
Console.WriteLine(st[2].Avg);

for(int i = 0; i < st.Length - 1; i++)
{
    for(int j = 0; j < st.Length - 1 - i; j++)
    {
        if (st[j].Avg < st[j+1].Avg)
        {
            temp = st[j];
            st[j] = st[j+1];
            st[j+1] = temp;
        }
    }
}

foreach (Student student in st)
{
    Console.WriteLine(student.ToShortString());
}