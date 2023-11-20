using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tooth_Booth_.common
{
     class PrintStatements
    {

        public static string userNamePrint="Please Enter userName: ";
        public static string erroruserNamePrint = "Your UserName Must Be Greate Than 5 and only alphanumeric is acceptable";
        public static string passwordPrint = "Enter Your Password: ";
        public static string errrorPasswordPrint = "\nYour Password Must Be Greate Than 5 Kindly Retry and must contain one upper case letter , special symbol and number";
        public static string emailAddressPrint = "\nEnter your EmailAddress: ";
        public static string erorEmailPrint = "Please Enter A valid Email";
        public static string phoneNumberPrint = "Enter your PhoneNumber: ";
        public static string errorPhoneNumberPrint = "Enter valid phone number";
        public static string clinicNamePrint = "Enter your clinicName: ";
        public static string errorClinicPrint = "Clinic Name Must Be Greate Than 5";
        public static string clinicDescriptionPrint = "Enter small Description of your clinic: ";
        public static string errorDescriptionPrint = "Description must contain Word more than 6 for description";
        public static string clinicCity = "Enter your clinic city: ";
        public static string errorClinicCityPrint = "CityName should contain more than 2 characters";
        public static string choiceCorrectlyPrint = "Enter Choice Correctly";
        public static string giveCorrectInput ="Give Correct Input";
        public static string novAilableClinicPrint ="No Clinic Available";
        public static string listOfClinicPrint ="Following are the list of all clinic registeed at our website";
        public static string userNameClinicEntry="Enter Username of Clinic Whose Entry You want to change";
        public static string fieldCantNull="Fields can't be null or empty";

        public static string enterUserNameCorrectly="Kindly ReTry and enter correct userName";
        public static string chooseOption="Enter Your Choice From Above Option";
        public static string clinicNameArrow = "ClinicName:       -> ";
        public static string descriptionArrow = "Description:      -> ";
        public static string deleted = "Deleted ";
        public static string clinicUserNameArrow="Clinic user Name: -> ";
        public static string clinicCityArrow="City:             -> ";
        public static string verifiedArrow="IsVerifired:      -> ";
        public static string changableFields = "You Could Only Change Following Fields:";
        public static string cityPrint="\n 1)City: ";
        public static string phoneNumberShow="\n 2)PhoneNumber : ";
        public static string description="\n 3)Description: " ;
        public static string verificationStatusShow="\n 4)Verification Status: ";
        public static string goToBack = "\n 5)To Go Back ";
        public static string numericEntryOnly="Please Enter numeric Term";
        public static string enterToChange="Enter 1 To Change Verification status else any other key";
         public static string updateSucessFully="----You have sucessfully updated the details-----";
        public static string someThingWentWrong = "SomeThing Went Wrong Please Try Again";
        public static string wantToChangeClinic="Enter Username of Clinic Whose Entry You want to change";
        public static string deleteClinicArrow="We Have Deleted Clininc:->";
        public static string sucessful="Sucessfully";
        public static string newAdminAdded = "New Admin Added SucessFully";
        public static string enterCityName = "Enter City Name Where You Want To Search Dentist";
        public static string  choiceEnter="Enter your choice-->";
        public static string noDentistAvaliable = "No Dentist are Available in this clinic!!!";
        public static string followingDentist="Following Dentist Are Available In These Clinic ";
        public static string dentistName="Dentist Name:  -->";
        public static string dentistspecialization = " Specialist In:  -->";
        public static string dentistNameForAppointment = "Write Name of That Dentist With Whome You Want To Book Your Appointment";
        public static string choosePaymentMethod = "Choose Your Payment Method";
        public static string forUpi="Press 1 If You Will Pay From UPI";
        public static string forCash = "Press 2 If You Want To Pay In Cash";
        public static string appointmentAdded = "Appointment Added Sucessfully!!!";
        public static string noAppointmentFound = "No Appointment Found!!!";
        public static string listOfAppointment = "Following are the list of your appointments";
        public static string dashedLine="----------------------------------------------------------";
        public static string appointId = "| Appointment Id:  -> ";
        public static string clinicName="| ClinicName:      ->";
        public static string whiteSpace = "     ";
        public static string doctorUsrName="| DoctorUserName:  ->";
        public static string prescription="| Prescription:    ->";
        public static string appointmentDate = "| Appointment Date:->";
        public static string patientUserName = "| PatientUserName: -> ";
        public static string cancleAppointmentId = "Enter Appoint Id To Cancle Make sure You could only cancle upcoming appoint";
        public static string appointmentEntryDeleted="Appointment Entry Deleted SucessFully!!!";
        public static string somethingWentWrong = "Something Went Wrong Please Try Again or No Appointment With Such Id  For the current data!!";
        public static string dentistAvailable="Press 1 IF you are available at ";
        public static string press2 = "\nElse Press 2 ";
        public static string attendanceMarked = "Your Attendance is Marked Sucessfully!!! ";
        public static string dateOfAppointment="Enter Date Whose Appointments You Want To See(eg:2023-10-30): ";
        public static string enterValidDate="Please Try Again And Enter a Valid Date: ";
        public static string enterAppoitmentID = "Enter Appointment Id Of Patient";
        public static string wantToAddMorePrescription="Do You Want To Add Prescription:Then Press 1 OtherWise Any Other Key To Go At Dashboard";
        public static string addIt = "Add IT:->";
        public static string maximumNumberOfAppointment="How many Maximum number of Appointment you could hold for the day";
        public static string updationSucess = "Updation Sucessfull!!!";
        public static string logOutSucessfull = "LogOut Sucessfull!!!";
        public static string welcome = "Welcome";
        public static string dentistUserNameToChange = "Enter Username of Dentist Whose Entry You want to change";
        public static string dashedEnterDetailOfDentist = "----------------------------Enter Detail Of Dentist--------------------------";
        public static string chooseDentistCategory="Choose Dentist Category.";
        public static string registerDentistSucessful = "You have registered dentist sucessfully!!";
        public static string tryAgain = "Please try again ";
        public static string frontScreenMenu = "Hi! Welcome to ToothBooth " +
           "\nPress 1 to Login"
           + "\nPress 2 to SignUp" +
            "\nPress 3 To Exit" +
           "\nEnter Your Choice-->\n";
        public static string superAdminMenu =
           "\nPress 1 To View List Of Available Clinic:" +
           "\nPress 2 Modify Any Detail of Clinic:"+
            "\nPress 3 To Delete Any Clinic Detail"+
           "\nPress 4 To Add New Admin"+
            "\nPress 5 To LogOut"+
           "\nEnter your choice-->\n";

        public static string patienMenu= "Press 1 To Book Appointments\n" +"Press 2 To View Record Of Previous Appointment\n" + "Press 3 To Cancle Upcoming Appointment\n" +
               "Press 4 To Logout\n";
        public static string dentistMenu = "Press 1 To View Appointments As per their dates\n" +
          "Press 2 To Mark your attendance for Today\n "
           + "Press 3 To Select Appoints By ID \n" +
           "Press 4 To Set Maximum Limit on Appointment For The Day\n" +
           "Press 5 To LogOut\n" +
            "Enter Your Choice--->\n";
        public static string clinicMenu= "Press 1 To Register A Newly Hired Dentist \n"+
          "Press 2 To Delete Any Dentist\n"
            +"Press 3 To View List of Available Dentist At Your Clinic\n"
           +"Press 4 To Logout\n";
        public static string registrationStartView = "press 1 to register as a Patient\n"
            + "Press 2 to register new clinic\n" +
      
            "Enter Your Choice\n";
        public static string dentistCategory = "Press 1 for GeneralDentist," +
                "\nPress 2 For Pedodontist," +
                "\nPress 3 for Orthodontist," +
                "\nPress 4 forPeriodontis," +
                "\nPress 5 forEndodontist," +
                "\nPress 6 forOralPathologists," +
                "\nPress 7 for Prosthodontist";





    }
}
