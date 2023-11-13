

namespace Tooth_Booth_.models
{
   
  public class Clinic   
    {

       public List<String> listOFClinicAdmin;
       public string clinicName;  
       public string description;
       public string clinicCity;
       public bool isverified;
        public Clinic() : base()
        {
        }
        public Clinic(string adminUsername,string clinicName,string description, string clinicCity) 
         
        { 
         
         this.listOFClinicAdmin = new List<String>();
         listOFClinicAdmin.Add(adminUsername);
         this.clinicName = clinicName;
         this.description = description;
         this.clinicCity= clinicCity;
         this.isverified = false;
         
        }





    }
}
