using ConsoleApp1;

internal class Person : IDateAndCopy
{
    protected string name;
    protected string surname;
    protected DateTime date;
    public Person(string name, string surname, DateTime date)
    {
        Name = name;
        Surname = surname;
        Date = date;
    }
    public Person()
    {
        Name = "Имя";
        Surname = "Фамилия";
        Date = DateTime.Today;
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public string Surname
    {
        get
        {
            return surname;
        }
        set
        {
            surname = value;
        }
    }
    public DateTime Date
    {
        get
        {
            return date;
        }
        set
        {
            date = value;
        }
    }
    public int Date2
    {
        get
        {
            return Date.Year;
        }
        set
        {
            Date = new DateTime(value, Date.Month, Date.Day);
        }
    }
    public override string ToString() => $"Имя: {Name}, Фамилия: {Surname}, Дата рождения: {Date.ToShortDateString()}";
    public virtual string ToShortString() => $"Имя: {Name}, Фамилия: {Surname}";
    public override bool Equals(object? obj)
    {
        return (obj == null || !(obj is Person p)) ? false :
        this.Name == p.Name && this.Surname == p.Surname && this.Date == p.Date;
    }
    public static bool operator ==(Person? p1, Person? p2) 
    {
        return p1 == null ? p2 == null : p1.Equals(p2);
    }
    public static bool operator !=(Person? p1, Person? p2) 
    { 
        return p1 == null ? p2 != null : !p1.Equals(p2); 
    }
    public override int GetHashCode() 
    { 
        return this == null ? base.GetHashCode() : (name + surname + date.ToString()).GetHashCode(); 
    }
    public virtual object DeepCopy() 
    { 
        return new Person(this.Name, this.Surname, this.Date); 
    }
}
