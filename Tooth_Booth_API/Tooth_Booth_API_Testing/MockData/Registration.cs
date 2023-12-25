using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Tooth_Booth_API.DTO.Auth;

namespace Tooth_Booth_API_Testing.MockData
{
    public static class Registration
    {
        public static List<RegistrationDTO> registrationDTO = new List<RegistrationDTO>()
        {
            new RegistrationDTO()
            {
           UserName="ayush",
         Password ="Ayush@12",
         EmailAddress ="ayushsinght70@gmail.com",
         PhoneNumber="9636653732"
            },
            new RegistrationDTO(){
         UserName="arpit",
         Password ="Ayush@12",
         EmailAddress ="ayushsinght70@gmail.com",
         PhoneNumber="9636653732"
            }
        };

        public static List<UserLoginDTO> listOfUserLogin = new List<UserLoginDTO>()
        {
            new UserLoginDTO()
            {
                UserName="ayush",
                Password="ausijs@g44"

            }
        };
        public static List<IdentityUser> listOfIdentity = new List<IdentityUser>()
        {
            new IdentityUser()
            {
                UserName="ayush",
                Email="ayushsinght70@gamil.com",
                PhoneNumber="9636653732"
            }
        };

    }
}
