using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindUrMeds
{
    public  class Person
    {
        string id;
        string name;
        string surname;
        string cellphonenumber;
        string email;
        public Person()
        {

        }
        public Person(string id, string name, string surname, string cellphonenumber, string Email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Cellphonenumber = cellphonenumber;
            this.Email = Email;
        }

        public string Id { get { return id; } set { id = value;  } }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Cellphonenumber { get => cellphonenumber; set => cellphonenumber = value; }
        public string Email { get => email; set => email= value; }
        

        public override string ToString() 
        {
            String a = $" person's name:{this.Name}"+$"\n surname:{this.Surname}"+ $"\nperson'id: {this.id}"+$"\n person's cellephone number: {this.Cellphonenumber} ";
            return a;
        }
    }
}
