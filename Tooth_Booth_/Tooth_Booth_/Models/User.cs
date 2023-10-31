using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooth_Booth_.common;

namespace Tooth_Booth_.models
{
     
  


     class User
    {
        public string userName;
        public string password;
        public string emailAddress;
        public string phoneNumber;
        public UserType userType;

        public User(string username,string password,string emailAddress, string phoneNumber,UserType userType)
        {
            this.userName = username;
            this.password = password;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.userType = userType;
        }
       public User()
        {

        }
        public User(User user)
        {
            this.userName = user.userName;
            this.password = user.password;
            this.emailAddress = user.emailAddress;
            this.phoneNumber = user.phoneNumber;
            this.userType=user.userType;
                
        }
        
    }
}
