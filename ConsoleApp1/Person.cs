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


    }
}
