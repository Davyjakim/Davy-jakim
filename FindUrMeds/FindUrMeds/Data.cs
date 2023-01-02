using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


namespace FindUrMeds
{
    
    //data storage and loading
    public class Data
    {
        public static string Connectionstring()

        {
            string Connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FindUrMedsdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           return Connectionstring;
        }

        public static void saveToSql(Person person)
        {
            Random random= new Random();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand("insert into Person values (@Idperson,@Idnumber,@Name,@Surname,@CellphoneNumber,@Email)", data);
            cmd.Parameters.AddWithValue("@idperson", random.Next(1, 101)); 
            cmd.Parameters.AddWithValue("@Idnumber", person.Id);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Surname", person.Surname);
            cmd.Parameters.AddWithValue("@CellphoneNumber", person.Cellphonenumber);
            cmd.Parameters.AddWithValue("@Email", person.Email);
            cmd.ExecuteNonQuery();

            data.Close();
        }
        public static void saveAdminToSql(Admin person)
        {
            Random random = new Random();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("insert into Admin values (@Adminid,@personId,@Name)", data);
                cmd.Parameters.AddWithValue("@Adminid", int.Parse(person.Idnumber));
                cmd.Parameters.AddWithValue("@personId", person.Idnumber);
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.ExecuteNonQuery();
            }catch(Exception ex) { Console.Write(ex.Message); }

            data.Close();
        }
        public static void saveMeToSql(Medications medi)
        {
            Random random = new Random();
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand("insert into Medication values (@MedId,@NameOfthemed,@expirationdate,@PharmacyName)", data);
            cmd.Parameters.AddWithValue("@MedId", medi.Id);
            cmd.Parameters.AddWithValue("@NameOfthemed", medi.Name);
            cmd.Parameters.AddWithValue("@expirationdate", medi.Expirationdate);
            cmd.Parameters.AddWithValue("@PharmacyName", medi.PharmacyName);

            cmd.ExecuteNonQuery();

            data.Close();
        }
        public static void savePhtosql(Pharmacy phar)
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            SqlCommand cmd = new SqlCommand("insert into Pharmacy values (@PharmacyId,@PharmacyName,@pharmacyLocation)", data);
            try
            {
                cmd.Parameters.AddWithValue("@PharmacyId", phar.Id);
                cmd.Parameters.AddWithValue("@PharmacyName", phar.PharmacyName);
                cmd.Parameters.AddWithValue("@pharmacyLocation", phar.Lacation1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            cmd.ExecuteNonQuery();

            data.Close();
        }
        
        
    
        public static Person perdat(string a)
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            string A = string.Empty, b = string.Empty, c = string.Empty, d = string.Empty, e = string.Empty, f = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand($"select Idnumber,Name,Surname,CellphoneNumber,Email from Person where idnumber={a}", data);
                SqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.Read())
                {
                    //f += reader["idperson"].ToString();
                    A += reader["Idnumber"].ToString();
                    b += reader["Name"].ToString();
                    c += reader["Surname"].ToString();
                    d += reader["CellphoneNumber"].ToString();
                    e += reader["Email"].ToString();

                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            data.Close();
            if (a == A)
            {
                return new Person(a, b, c, d, e);
            }
            else
            {

                //Console.WriteLine($"this {a} person is not an admin ");
                return new Person(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            }

        }
        public static Admin Adimindat(string a)
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();
            string A = string.Empty, b = string.Empty, c = string.Empty, d = string.Empty, e = string.Empty, f = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand($"select Adminid,Name from Admin where Adminid={a}", data);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //f += reader["idperson"].ToString();
                    A += reader["Adminid"].ToString();
                    b += reader["Name"].ToString();
                     

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            data.Close();
            if (a == A)
            {
                return new Admin(a, b);
            }
            else
            {

               // Console.WriteLine($"this {a} person is not registered ");
                return new Admin(string.Empty, string.Empty);
            }

        }
        public static void meddatat(string a)
        {
            SqlConnection data = new SqlConnection(Data.Connectionstring());
            data.Open();


            //f += reader["idperson"].ToString();
            try
            {
                SqlCommand cmd = new SqlCommand($"select NameOfthemed, exiparationdate from Medication where NameOfthemed={a}", data);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    List<string> A = new List<string>();
                    for (int i = 0; i < A.Capacity; i++)
                    {
                        A.Add(reader["NameOfthemed"].ToString());
                        Console.WriteLine($"{A[i]}");
                    }
                }
            }catch(Exception ex) { Console.WriteLine(ex.Message); }

            

            data.Close();
             

        }




    }
}
