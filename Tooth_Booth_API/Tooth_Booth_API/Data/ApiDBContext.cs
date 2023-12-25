using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Data
{
    public class ApiDBContext:IdentityDbContext
    {

        public DbSet<Dentist> Dentists {  get; set; }
        public DbSet<Appointment>Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        

        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        


    }
}
