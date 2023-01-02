using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Security.Policy;

namespace FindUrMeds
{
    public class Admin
    {

        string name;
        static string idnumber;


        static public List<Medications> meds = new List<Medications>();
        public Admin()
        {

        }
        public Admin(string idnumber, string name)
        {
            Name = name;
            Idnumber = idnumber;
        }

        public string Name { get => name; set => name = value; }
        public string Idnumber { get => idnumber; set => idnumber = value; }

        public static void createPhrmcy()
        {

            Console.WriteLine("enter your name of the pharmacy: ");
            Console.Write("Name: ");
            string Pharmacyname = Console.ReadLine();
            Console.WriteLine("enter the lacation of the pharmacy: ");
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.WriteLine($"give this {Pharmacyname} and idnumber");
            Console.Write("Id: ");
            string id = Console.ReadLine();

            Pharmacy pharm = new Pharmacy(id, Pharmacyname, location);
            Data.savePhtosql(pharm);
            //Console.WriteLine($"do you wanna add medicition to {Pharmacyname} right now or later ");
            //Console.Write("type 'n' for now and 'l' for later ");
            //string resp = Console.ReadLine();

            //if(resp== "n"||resp == "N")
            //{
            //    //get the medication from the data base by it  name
            //    p.Add(Admin.addmedication());   
            //}
            //else if(resp== "l"|| resp=="L")
            //{
            // //save a 
            //}
        }
        public static Admin addanAdmin()
        {
            Admin admin;
            Console.WriteLine("enter the idnumber of the Person you want to make an adim");
            Console.Write("Idnumber: ");
            string idnumber = Console.ReadLine();
            Person person = Data.perdat(idnumber);
            if (idnumber == person.Id)
            {
                admin = new Admin( person.Id, person.Name);
                Console.WriteLine($"{person.Name} {person.Surname} is now an admin");
            }
            else
            {
                Console.WriteLine($"person with id number = {idnumber} does not exist");
                admin = new Admin(string.Empty, string.Empty);
            }


            return admin;
        }
        public static void deleteAnadmin()
        {
            Console.WriteLine("enter the idnumber of the Person you want to remove From adims");
            Console.Write("Idnumber: ");
            string idnumber = Console.ReadLine();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            try
            {
              
                data.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Admin where Adminid= '{idnumber}'", data);
                cmd.ExecuteNonQuery();
                data.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
           
        }
    
        public static Medications addmedication()
        {
            Medications d= new Medications();


            Console.WriteLine("enter the name of the medication in full: ");
           Console.Write("name: ");
            string name = Console.ReadLine();

            try
            { 
           Console.WriteLine("enter the expiration date of the medication");
           Console.Write("enter the year of expiration: ");
            int year = int.Parse(Console.ReadLine());
           Console.Write("enter the month of expiration as a number: ");
            int month = int.Parse(Console.ReadLine());
           Console.Write("enter the day of expiration: ");
            int day = int.Parse(Console.ReadLine());
            //option chose whether you the id youself or let the computer choose a random id between a range u provided
            Console.WriteLine("Give this medication an idnumber");
            Console.Write("Id number: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("what is the name of the pharmancy where this Med'{name}' is at");
            Console.Write("Name: ");
            string PharmacyName= Console.ReadLine();
             d = new Medications() ;

                d.Id = id;
                d.Name = name;
                d.Expirationdate = new DateTime(year, month, day);
                d.PharmacyName = PharmacyName;
                Data.saveMeToSql(d);                
            }catch
            (Exception e)
            { Console.WriteLine(e.Message); }
            return d;
        }

    }
}
