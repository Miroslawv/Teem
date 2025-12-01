using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        string name;
        string surname;
        DateTime date;
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
            get => this.name; 
            set => this.name = value; 
        }
        public string Surname
        {
            get => this.surname;
            set => this.surname = value;
        }
        public DateTime Date
        {
            get => this.date;
            set => this.date = value;
        }
        public int Date2
        {
            get => Date.Year;
            set => Date = new DateTime(value, Date.Month, Date.Day);
        }

        public override string ToString() => $"Имя: {Name}, Фамилия: {Surname}, Дата рождения: {Date.ToShortDateString()}";
        public virtual string ToShortString() => $"Имя: {Name}, Фамилия: {Surname}";
    }
}
