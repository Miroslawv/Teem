using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        String name;
        String surname;
        DateTime date;

        public Person(string name, string surname, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
        }

        public Person()
        {
            this.name = "Имя";
            this.surname = "Фамилия";
            this.date= DateTime.Now;
        }

        public String Name
        {
            get 
            { 
                return this.name; 
            } 
            set 
            {
                this.name = value; 
            }
        }

        public String Surname
        {
            get
            {
                return this.surname;
            }
            set
            {
                this.surname = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public int Date2
        {
            get
            {
                return date.Year;
            }
            set
            {
                date = new DateTime(value, date.Month, date.Day);
            }

        }

        public override string ToString() => $"Имя: {Name}, Фамилия: {Surname}, Дата рождения: {Date.ToString("dd.MM.yyyy")}";

        public virtual void ToShortString()
        {
            Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}");
        }
    }
}
