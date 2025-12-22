using ConsoleApp1;

internal class Exam : IDateAndCopy
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
    public override string ToString() => $"Название предмета: {Name}, оценка за экзамен: {Grade}, дата проведение экзамена: {Date.ToShortDateString()}.";
    public override bool Equals(object? obj)
    {
        return (obj == null || !(obj is Exam e)) ? false : this.Name == e.Name && this.Grade == e.Grade && this.Date == e.Date;
    }
    public static bool operator ==(Exam? e1, Exam? e2) 
    { 
        return e1 == null ? e2 == null : e1.Equals(e2); 
    }
    public static bool operator !=(Exam? e1, Exam? e2) 
    { 
        return e1 == null ? e2 != null : !e1.Equals(e2); 
    }
    public override int GetHashCode() 
    { 
        return this == null ? base.GetHashCode() : (Name + Grade.ToString() + Date.ToString()).GetHashCode(); 
    }
    public object DeepCopy() 
    { 
        return new Exam(Name, Grade, Date); 
    }
}
