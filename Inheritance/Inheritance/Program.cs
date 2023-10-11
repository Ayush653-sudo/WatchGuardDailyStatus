namespace Inheritance
{

    class Vehicle
    {
        private readonly int RegistrationNo;
        private readonly int VehicleNo;
        private readonly string VehicleName;
        private readonly string VehicleCompany;
       public Vehicle(int ReNo,int VehicleNo,string VehicleName,string VType)
        {
            RegistrationNo = ReNo;
            VehicleNo = VehicleNo;
            VehicleName = VehicleName;
            VehicleCompany = VType;


        }
        public void print()
        {
            Console.WriteLine(RegistrationNo);
        }
    }
    class RtoOffice:Vehicle
    {
        String officer_Name;
        String office_Code;
        public RtoOffice(int ReNo, int VehicleNo, string VehicleName, string VType,String oName,String oCode):base( ReNo,  VehicleNo, VehicleName,VType)
        {
            officer_Name= oName;
            office_Code= oCode;
        }
        public void pri()
        {
            Console.WriteLine(office_Code);
        }
    }
    class Controller
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Registration No:");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Vehicle No:");
            int j = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Vehicle Name:");
            String k = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Company:");
            String l = Console.ReadLine();
         RtoOffice r1=new RtoOffice(i, j, k, l, "suresh", "234");
          
            // RtoOffice r2=new RtoOffice()
         //   Vehicle v1 = r1;
          //  v1.print();
            Vehicle v2 = new Vehicle(99, j, k, l);
            Vehicle v3 = r1;
          //  v2 = r1;
            RtoOffice r3 = (RtoOffice)v2;
            Console.WriteLine("dd");
          r3.print();
           // v3.print();

           // r3.
            

        }
    }
}
