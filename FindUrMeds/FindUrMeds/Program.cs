using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;

namespace FindUrMeds
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            

            string option;
            Person person = null;
            do
            {
                Console.Clear();
                option = Mainmenu();
                switch (option)
                {
                    case "1":
                        logIn();
                        break;
                    case "2":
                        person = regester();
                        break;
                    
                    case "3422":
                        loginsecret();
                        break;
                    case "0":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Unknown option!");
                        break;
                }


            } while (option != "0");
        }
        private static char userMenu()
        {
            
            Console.WriteLine("1. search for a medication");
            Console.WriteLine("0. Quit");
            Console.Write("Select: ");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return key;
        }
        private static string Mainmenu() 
        {
            Console.WriteLine("1. login");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("0. quit");
            Console.Write("Select: ");
            string key = Console.ReadLine();
            Console.WriteLine();
            return key;
        }
        
        public static void logIn()
        {
             
            Console.Write("enter your idnumber: ");
            string a = Console.ReadLine();
            if (a != "")
            {
                Person person = Data.perdat(a);
               Admin admin = Data.Adimindat(a);
             
                if (a == person.Id && a != admin.Idnumber)
                {
                    Console.Clear();
                    char options;
                    do
                    {

                        options = userMenu();
                        switch (options)
                        {
                            case '1':
                                Commends.MedecineSearch();
                                break;

                            case '0':
                                Console.WriteLine("bye");
                                break;
                            default:
                                Console.WriteLine("unkown option");
                                break;
                        }
                        Console.WriteLine("Hit [Any] key...");
                        Console.ReadKey();


                    } while (options != '0');
                }
                else if (a == admin.Idnumber) //&& a== person.Id||a == admin.Idnumber && a != person.Id)
                {
                    char options;
                    do
                    {
                        Console.Clear();
                        options = AdimMenu();
                        switch (options)
                        {
                            case '1':
                                Admin.createPhrmcy();
                                break;
                            case '2':
                                Admin.meds.Add(Admin.addmedication());
                                break;
                            case '3':
                                Commends.MedecineSearch();
                                break;

                            case '4':
                                Data.saveAdminToSql(Admin.addanAdmin());
                                break;
                            case '5':
                                Admin.deleteAnadmin();
                                break;
                            case '6':
                                ViewData();
                                break;
                            case '0':
                                Console.WriteLine("bye!");
                                break;
                            default:
                                Console.WriteLine("unkown option");
                                break;
                        }
                        Console.WriteLine("Hit [Any] key...");
                        Console.ReadKey();

                    } while (options != '0');
                }
                else
                {
                    Console.WriteLine($"Person with Idnumber: {a} is not registered");
                    Console.WriteLine("Do you want to regester");
                    Console.Write("enter ' yes ' or ' no' ");
                    string b = Console.ReadLine();
                    if (b == "Yes" || b == "yes")
                    {
                        regester();
                    }
                    else if (b == "no" || b == "No")
                    {
                        Console.WriteLine("okay thank you ");
                        Console.WriteLine("Hit [Any] key...");
                        Console.ReadKey();
                    }
                }
            }
            else 
            {
                Console.WriteLine("enter your id number or sign up");
            }

        }
        public static void loginsecret()
        {
           
            Random random= new Random();
            int A = random.Next(0,1000);
           
            Admin admin = new Admin(A.ToString(), "Davy");
            
            Console.Write($"{admin.Idnumber} enter your idnumber: ");
            string id = Console.ReadLine();
            if (id == admin.Idnumber)
            {
                char options;
                do
                {
                    Console.Clear();
                    options = AdimMenu();
                    switch (options)
                    {
                        case '1':
                            Admin.createPhrmcy();
                            break;
                        case '2':
                            Admin.meds.Add(Admin.addmedication());
                            break;
                        case '3':
                            Commends.MedecineSearch();
                            break;

                        case '4':
                            Data.saveAdminToSql(Admin.addanAdmin());
                            break;
                        case '5':
                            Admin.deleteAnadmin();
                            break;
                        case '6':
                            ViewData();
                            break;
                        case '0':
                            Console.WriteLine("bye!");
                            break;
                        default:
                            Console.WriteLine("unkown option");
                            break;
                    }
                    Console.WriteLine("Hit [Any] key...");
                    Console.ReadKey();

                } while (options != '0');
            }
            else
            {
                Console.WriteLine("your not registered");
            }
        }
        public static void ViewData()
        {
            char options;
            do
            {
                Console.Clear();
                options = DataProcessing();
                switch(options)
                {
                    case '1':
                        Commends.PharmacyData();
                        break;
                    case '2':
                        Commends.MedData();
                        break;
                    case '3':
                        Commends.PersData();
                        break;
                    case '4':                       
                        Commends.AdminData();
                        break;
                    case '5':                       
                        Commends.deleteperson();
                        break;
                    case '6':
                        Commends.deleteAmedication();
                        break;
                    case '7':
                        Commends.deleteAPharmacy();
                        break;
                    case '0':
                        Console.WriteLine("bye!");
                        break;
                    default:
                        Console.WriteLine("unkown option");
                        break;
                }
            }
            while (options != '0');
        }
        public static Person  load(string pname)
        {
            string filename = pname + ".text";
            string name=null;
            string surname=null;
            string id = null;
            string cellpN = null;
            string email = null;

            try 
            {
                StreamReader reader = new StreamReader(filename);
                 name = reader.ReadLine();
                 surname = reader.ReadLine();
                id = reader.ReadLine();
                cellpN = reader.ReadLine();
                email = reader.ReadLine();
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            
            return new Person(id, name, surname, cellpN, email);
            

        }
        static Person regester()
        {
            Console.WriteLine("enter your name: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("enter your surname: ");
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("enter your idnumber: ");
            Console.Write("Idnumber: ");
            string id = Console.ReadLine();
            Console.WriteLine("enter your cellPhoneNumber: ");
            Console.Write("CellPhoneNumber: ");
            string cellPhoneN = Console.ReadLine();
            Console.WriteLine("enter your Email: ");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Person per = new Person(id, name,surname,cellPhoneN,email);
            savetofile(per);
            Data.saveToSql(per);
            return per;


        }

        public static void savetofile(Person person)
        {  
            string filename = person.Name+ person.Surname+".text";
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(person.Name);
            writer.WriteLine(person.Surname);
            writer.WriteLine(person.Id);
            writer.WriteLine(person.Cellphonenumber);
            writer.Close();
                
        }
        private static char AdimMenu()
        {
 
            Console.WriteLine("1. create a pharmacy");
            Console.WriteLine("2. add medication to a Pharmacy");
            Console.WriteLine("3. search for a medication");
            Console.WriteLine("4. Add an Admin");
            Console.WriteLine("5. Delete an admin");
            Console.WriteLine("6. further commends");
            Console.WriteLine("0. back");
            Console.Write("Select: ");

            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return key;
        }
        private static char DataProcessing()
        {
            Console.WriteLine("1.pharmacy");
            Console.WriteLine("2.Medication");
            Console.WriteLine("3.Person");
            Console.WriteLine("4.Admin");    
            Console.WriteLine("5.Delete a Person");
            Console.WriteLine("6.Delete a Medication");
            Console.WriteLine("7.Delete a Pharmacy");
            Console.WriteLine("0. back");
            Console.Write("Select: ");

            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return key;
        }
    }
}
