using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindUrMeds
{
    public class Pharmacy
    {
        string id;
        string pharmacyName;
        string Lacation;
         

        public Pharmacy(string id, string pharmacyName, string lacation1 )
        {
            Id = id;
            PharmacyName = pharmacyName;
            Lacation1 = lacation1;
        }
       

        public  string Id { get => id; set => id = value; }
        public  int Medid { get { return int.Parse(id); } set { int.Parse(id); } } 
        public string PharmacyName { get => pharmacyName; set => pharmacyName = value; }
        public string Lacation1 { get => Lacation; set => Lacation = value; }
        
    }
}
