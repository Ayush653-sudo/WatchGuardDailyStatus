using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tooth_Booth_.common
{

    public enum PaymentType
    {
        UPI=1,
        Cash
    };
    public enum DentistCategory
    {
        GeneralDentist=1,
        Pedodontist,
        Orthodontist,
        Periodontis,
        Endodontist,
        OralPathologists,
        Prosthodontist
    }

    public enum EditClinic
    {
        Email=1,
        PhoneNumber,
        Description,
        VerificationStatus,
        GoBack
    };
    public enum PatientDashboardE
    {
        BookAppointment=1,
        ViewPreviousAppointments,
        CancleAppointment,
        Logout,


    };
    enum UserType
    {
        SuperAdmin ,
        clinicAdmin,
        Dentist,
        Patient
    };

    public enum SelectAuth
    {
        LogIn=1,
        SignUp,
        Exit
    };
    public enum SelectSuperAdminStarter
    {
        ListOfClinic=1,
        ModifyClinic,
        DeleteClinic,
        AddAdmin,
        LogOut,
    };
    public enum DentistStarter
    {
        ViewAppointment=1,
        MarkAttendance,
        SelectAppointment,
        MaxAppointments,
        LogOut,

    };

    public enum ClinicStarter
    {
        RegisterDentist=1,
        DeleteDentist,
        ListOfDentist,
        LogOut

    };

    enum Registrationstarter
    {
        PatientRegistration=1,
        ClinicRegistration,
        GoBack
    }
    enum Attendance
    {
        Present=1,
        Absent
    };

    public class Common
    { 

        public static  Regex hasnumber = new Regex(@"^([0]|\+91)?[789]\d{9}$");
        public static Regex hNumber = new Regex(@"[0-9]+");
        public static Regex hasUpperChar = new Regex(@"[A-Z]+");
        public static Regex hasMinimum5Chars = new Regex(@".{5,}");
        public static Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        public static string emailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        public static Regex hasOnlyAlphaNumeric = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
        public  static  void FrontScreenSelectMenu()
        {
            Console.WriteLine("Hi! Welcome to ToothBooth ");
            Console.WriteLine("Press 1 to Login");
            Console.WriteLine("Press 2 to SignUp");
            Console.WriteLine("Press 3 To Exit");
            Console.WriteLine("Enter Your Choice-->");
            Console.WriteLine();
        }

        public static void SuperAdminStartView()
        {
            Console.WriteLine("Press 1 To View List Of Available Clinic:");
            Console.WriteLine("Press 2 Modify Any Detail of Clinic:");
            Console.WriteLine("Press 3 To Delete Any Clinic Detail");
            Console.WriteLine("Press 4 To Add New Admin");
            Console.WriteLine("Press 5 To LogOut");
            Console.WriteLine("Enter your choice-->");
            Console.WriteLine();
        }

        public static void DentistStartView()
        {
            Console.WriteLine("Press 1 To View Appointments As per their dates");
            Console.WriteLine("Press 2 To Mark your attendance for Today ");
            Console.WriteLine("Press 3 To Select Appoints By ID ");
            Console.WriteLine("Press 4 To Set Maximum Limit on Appointment For The Day");
            Console.WriteLine("Press 5 To LogOut");
            Console.WriteLine("Enter Your Choice--->");
            Console.WriteLine();
        }
        public static void ClinicStartView()
        {
            Console.WriteLine("Press 1 To Register A Newly Hired Dentist ");
            Console.WriteLine("Press 2 To Delete Any Dentist");
            Console.WriteLine("Press 3 To View List of Available Dentist At Your Clinic");
            Console.WriteLine("Press 4 To Logout");
            Console.WriteLine();
        }
        public static void PatientStartView()
        {
            Console.WriteLine("Press 1 To Book Appointments");
            Console.WriteLine("Press 2 To View Record Of Previous Appointment");
            Console.WriteLine("Press 3 To Cancle Upcoming Appointment");
            Console.WriteLine("Press 4 To Logout");
            Console.WriteLine();
        }

        public static void RegistrationStartView()
        {
            Console.WriteLine("press 1 to register as a Patient");
            Console.WriteLine("Press 2 to register new clinic");
            Console.WriteLine("Press 3 To Go Back");
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine();
        }
        public static bool NullCheck(String s)
        {
            if (String.IsNullOrEmpty(s))
                return true;
            else
                return false;
        }

        public static bool CheckLength(string s,int length)
        {
            if (s.Length < length)
                return true;
            else
                return false;

        }

        public static bool CheckEmail(string s)
        {
            return Regex.IsMatch(s, Common.emailRegex, RegexOptions.IgnoreCase);
        }
        public static int CountWords(String s)
        {
            return s.Split(" ").Count();
        }

        public static void ClinicCommon()
        {
            Console.WriteLine("Press 1 for GeneralDentist," +
                "\nPress 2 For Pedodontist," +
                "\nPress 3 for Orthodontist," +
                "\nPress 4 forPeriodontis," +
                "\nPress 5 forEndodontist," +
                "\nPress 6 forOralPathologists," +
                "\nPress 7 for Prosthodontist");
        }
    }
    
}
