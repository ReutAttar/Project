using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public String ID { get; set; }
        public String MyMotherID { get; set; }
        public String FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public bool SpecialNeeds { get; set; }
        public String Needs { get; set; }
        public bool Allergy { get; set; }
        public String MyAllergy { get; set; }
        public String MyNutrition { get; set; }
        public override string ToString()
        {
            string result ="";
            result += "My Mother ID: " + MyMotherID + "\n";
            result += "First Name: " + FirstName + "\n";
            result += "Birthday: " + Birthday.ToString("dd/MM/yyyy") + "\n";
            result += "Special Needs: " + (SpecialNeeds ? "TRUE" : "FALSE") + "\n";
            result += "My Needs: "+Needs+"\n";
            result+= "Allergy: "+ (Allergy ? "TRUE" : "FALSE") + "\n";
            result+= "I am allergy to: "+ MyAllergy + "\n";
            result+= "My Nutrition: "+ MyNutrition + "\n";
            return result;
        }

    }
}
