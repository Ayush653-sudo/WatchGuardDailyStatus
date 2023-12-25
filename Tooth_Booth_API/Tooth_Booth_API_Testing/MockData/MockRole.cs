using System;
using System.Collections.Generic;
using System.Text;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API_Testing.MockData
{
    public class MockRole
    {
        public static List<Role> listOfRoles = new List<Role>()
        {
            new Role()
            {
              Id = 1,
              RoleName = "Test",

            }
         };
    }
}
