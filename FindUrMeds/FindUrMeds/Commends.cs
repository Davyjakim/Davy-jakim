using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FindUrMeds
{
    public class Commends
    {

        public static void MedecineSearch()
        {
            
            string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FindUrMedsdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection data = new SqlConnection(constring);
            using (data)
            {
                Console.WriteLine("enter a name of medication");
                Console.Write("Name: ");
                string a = Console.ReadLine();
                List<string> A = new List<string>();
                int B = 0;
               data.Open();
                SqlCommand cmd = new SqlCommand($"select PharmacyName from Medication where NameOfthemed = '{a}' ", data);
                SqlDataReader reader = cmd.ExecuteReader();
                // List<string> C = new List<string>();
                while (reader.Read())
                {
                    A.Add(reader["PharmacyName"].ToString());
                    // Console.WriteLine($"{A[i+1]}");
                    B = A.Count;
                }
                data.Close();
                Console.WriteLine($"they are {B} number of results");
                string ans = string.Empty;
                if (B != 0)
                {
                    Console.WriteLine("do you want to a list of Pharmacies with you medication");
                    Console.WriteLine("enter Yes Or No");
                    Console.Write("Answer: ");
                    ans += Console.ReadLine();
                    if (ans == "yes" || ans == "Yes" || ans == "no" || ans == "No")
                    {
                        do
                        {
                            if (ans == "Yes" || ans == "yes")
                            {
                                for (int i = 0; i < A.Count; i++)
                                {
                                    data.Open();    
                                    SqlCommand cm = new SqlCommand($"select PharmacyName, pharmacyLocation from Pharmacy where PharmacyName='{A[i]}' ", data);
                                    SqlDataReader read = cm.ExecuteReader();
                                    while (read.Read())
                                    {
                                        string[,] R = new string[2, A.Count];
                                        for (int c = 0; c < A.Count; c++)
                                        {
                                            R[0, c] = read["PharmacyName"].ToString();
                                            R[1, c] = read["pharmacyLocation"].ToString();
                                            Console.WriteLine($"{i + 1} pharmacy name: {R[0, c]}");
                                            Console.WriteLine($"{i + 1} Pharmacy location: {R[1, c]}");
                                            break;
                                        }
                                    }
                                    data.Close();
                                }
                                break;
                            }
                        } while (ans != "no" || ans != "No");
                    }
                    else
                    {
                        Console.WriteLine(" unknown answer");
                    }
                }
                else
                {
                    Console.WriteLine("no results fund ");
                }
            }
        }
        public static void PharmacyData()
        {
           // StringWriter stringWriter = new StringWriter();
            string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FindUrMedsdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection data = new SqlConnection(constring);
            using (data)
            {
                
                int c = 0;
                List<string> A = new List<string>();
                int B = 0;
                
                data.Open();
                SqlCommand cmd = new SqlCommand($"select * from Pharmacy", data);
                SqlDataReader reader = cmd.ExecuteReader();
                // List<string> C = new List<string>();
                while (reader.Read())
                {
                    A.Add(reader["pharmacyLocation"].ToString());

                    
                    
                    // Console.WriteLine($"{A[i+1]}");
                    B = A.Count;
                }
                data.Close();
                string[,] R = new string[A.Count, 3];
                data.Open();
                SqlCommand cmmd = new SqlCommand($"select * from Pharmacy", data);
                SqlDataReader read = cmmd.ExecuteReader();
                while (read.Read())
                {
                    
                    if (c < A.Count)
                    {
                        R[c, 0] = read["PharmacyId"].ToString();
                        R[c, 2] = read["pharmacyLocation"].ToString();
                        R[c, 1] = read["PharmacyName"].ToString();
                    }
                    c++;
                }
                data.Close();
                Console.WriteLine($"they are {B} number of PHarmacy");
                Console.ReadLine();
                Console.WriteLine("Pharmacy Data");
                string ans = string.Empty;
                if (B != 0)
                { 
                       for (int r = 0; r< A.Count; r++)
                       {
                         Console.Write($"({r + 1})");
                           for (int co = 0; co<2; co++)
                           {
                            Console.Write("|{0,14}", R[r, co]);
                           }
                            Console.Write("|       {0,14}", R[r, 2]);
                            Console.WriteLine();
                       }
                        Console.ReadLine();  
                      

                       
                    
                }
                else
                {
                    Console.WriteLine("no results fund ");
                }
                data.Close();
                
            }
        }
        public static void MedData()
        { 
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            using (data)
            {

                int c = 0;
                List<string> A = new List<string>();
                int B = 0;

                data.Open();
                SqlCommand cmd = new SqlCommand($"select * from Medication", data);
                SqlDataReader reader = cmd.ExecuteReader();
                // List<string> C = new List<string>();
                while (reader.Read())
                {
                    A.Add(reader["MedId"].ToString());



                    // Console.WriteLine($"{A[i+1]}");
                    B = A.Count;
                }
                data.Close();
                string[,] R = new string[A.Count, 4];
                data.Open();
                SqlCommand cmmd = new SqlCommand($"select * from Medication", data);
                SqlDataReader read = cmmd.ExecuteReader();
                while (read.Read())
                {

                    if (c < A.Count)
                    {
                        R[c, 0] = read["MedId"].ToString();
                        R[c, 1] = read["NameOfthemed"].ToString();
                        R[c, 2] = read["PharmacyName"].ToString();
                        R[c, 3] = read["expirationdate"].ToString();
                    }
                    c++;
                }
                data.Close();
                Console.WriteLine($"they are {B} numbers of medication");
                Console.ReadLine();
                Console.WriteLine("medication table Data");
                string ans = string.Empty;
                if (B != 0)
                {
                    for (int r = 0; r < A.Count; r++)
                    {
                        Console.Write($"{r + 1}.");
                        for (int co = 0; co < 3; co++)
                        {
                            Console.Write("|{0,14}", R[r, co]);
                        }
                        Console.Write("|     {0,14}", R[r, 3]);
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("no results fund ");
                }
                data.Close();
            }
        }
        public static void PersData()
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            using (data)
            {

                int c = 0;
                List<string> A = new List<string>();
                int B = 0;

                data.Open();
                SqlCommand cmd = new SqlCommand($"select * from Person", data);
                SqlDataReader reader = cmd.ExecuteReader();
                // List<string> C = new List<string>();
                while (reader.Read())
                {
                    A.Add(reader["Idperson"].ToString());
                    // Console.WriteLine($"{A[i+1]}");
                    B = A.Count;
                }
                data.Close();
                string[,] R = new string[A.Count, 5];
                data.Open();
                SqlCommand cmmd = new SqlCommand($"select * from Person", data);
                SqlDataReader read = cmmd.ExecuteReader();
                while (read.Read())
                {

                    if (c < A.Count)
                    {
                        R[c, 0] = read["Idperson"].ToString();
                        R[c, 1] = read["Idnumber"].ToString();
                        R[c, 2] = read["Name"].ToString();
                        R[c, 3] = read["Surname"].ToString();
                        R[c, 4] = read["Email"].ToString();
                    }
                    c++;
                }
                data.Close();
                Console.WriteLine($"they are {B} Persons in the database");
                Console.ReadLine();
                Console.WriteLine("person table Data");
                string ans = string.Empty;
                if (B != 0)
                {


                    for (int r = 0; r < A.Count; r++)
                    {
                        Console.Write($"({r + 1})");
                        for (int co = 0; co < 4 ; co++)
                        {
                            Console.Write("|{0,16}", R[r, co]);
                           
                        }
                        Console.Write("|     {0,16}", R[r, 4]);

                        Console.WriteLine();
                    }
                    Console.ReadLine();




                }
                else
                {
                    Console.WriteLine("no results fund ");
                }
                data.Close();

            }
        }
        public static void AdminData()
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            using (data)
            {

                int c = 0;
                List<string> A = new List<string>();
                int B = 0;

                data.Open();
                SqlCommand cmd = new SqlCommand($"select * from Admin", data);
                SqlDataReader reader = cmd.ExecuteReader();
                // List<string> C = new List<string>();
                while (reader.Read())
                {
                    A.Add(reader["Adminid"].ToString());
                    // Console.WriteLine($"{A[i+1]}");
                    B = A.Count;
                }
                data.Close();
                string[,] R = new string[A.Count, 2];
                data.Open();
                SqlCommand cmmd = new SqlCommand($"select * from Admin", data);
                SqlDataReader read = cmmd.ExecuteReader();
                while (read.Read())
                {

                    if (c < A.Count)
                    {
                        R[c, 0] = read["personId"].ToString();
                        R[c, 1] = read["Name"].ToString();
                         
                    }
                    c++;
                }
                data.Close();
                Console.WriteLine($"they are {B} admins in the database");
                Console.ReadLine();
                Console.WriteLine("Admin table Data");
                string ans = string.Empty;
                if (B != 0)
                {


                    for (int r = 0; r < A.Count; r++)
                    {
                        Console.Write($"({r + 1})");
                        for (int co = 0; co < 1; co++)
                        {
                            Console.Write("|{0,10}", R[r, co]);
                        }
                        Console.Write("|  {0}", R[r, 1]);
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("no results fund ");
                }
                data.Close();

            }
        }
        public static void deleteperson()
        {
            Console.WriteLine("enter the idnumber of the Person you want to delete");
            Console.Write("Idnumber: ");
            string idnumber = Console.ReadLine();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand($"Delete from Person where Idperson= '{idnumber}'", data);
            cmd.ExecuteNonQuery();
            data.Close();
        }
        public static void deleteAmedication()
        {
            Console.WriteLine("enter the idnumber of the Medication you want to delete");
            Console.Write("Idnumber: ");
            string idnumber = Console.ReadLine();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand($"Delete from Medication where MedId= '{idnumber}'", data);
            cmd.ExecuteNonQuery();
            data.Close();
        }
        public static void deleteAPharmacy()
        {
            Console.WriteLine("enter the idnumber of the Pharmacy you want to remove");
            Console.Write("Idnumber: ");
            string idnumber = Console.ReadLine();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand($"Delete from Pharmacy where PharmacyId= '{idnumber}'", data);
            cmd.ExecuteNonQuery();
            data.Close();
        }


    }
}
     
