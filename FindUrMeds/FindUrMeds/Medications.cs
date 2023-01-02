using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindUrMeds
{
    public class Medications
    {
        string name;
        DateTime expirationdate;
        int id;
        string pharmacyname;

       public Medications()
        {
           

        }

        public Medications(int Id, string Name, DateTime Expirationdate, string PharmacyName)
        {
            this.Id = Id;
            this.Name = Name;
            this.Expirationdate = Expirationdate;
            this.PharmacyName = PharmacyName;
        }

        public string Name { get => name; set => name = value; }
        public DateTime Expirationdate { get => expirationdate; set => expirationdate = value; }
        public int Id { get => id; set => id = value; }
        public string PharmacyName { get=> pharmacyname; set => pharmacyname = value;}
    }
}
