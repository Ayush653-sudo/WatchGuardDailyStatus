using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.Data;
using Tooth_Booth_API_Testing.MockData;
using Tooth_Booth_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tooth_Booth_API.Repository;
using System.Linq;

namespace Tooth_Booth_API_Testing.Repository
{
    [TestClass]
    public class ClinicRepositoryTest
    {

        Mock<ApiDBContext> ApiDBContext;
        ClinicRepository clinicRepository;
        ApiDBContext dbContext;
        bool flag = true;

       [TestInitialize]
        public void Initialize()
        {
           ApiDBContext = new Mock<ApiDBContext>();
           var options = new DbContextOptionsBuilder<ApiDBContext>().UseInMemoryDatabase(databaseName: "InMemoryDatabase").Options;
             dbContext = new ApiDBContext(options);
            //if (flag)
            //{
            //    dbContext.Clinics.Add(
            //        new Clinic()
            //        {
            //            ClinicId = 1,
            //            ClinicAdminId = "ayush",
            //            ClinicName = "RoomShoom",
            //            Description = "Very nice clinic",
            //            ClinicCity = "Noida",
            //            Isverified = false

            //        }



            //    );
            //    dbContext.SaveChanges();
            //    flag = false;
            //}
           

           clinicRepository = new ClinicRepository(dbContext);
        }
        [TestMethod]
        public void GetAll_FetchAllClinic_ReturnListOfClinic()
        {
            var clinics=clinicRepository.GetAll();
            Assert.IsNotNull(clinics);
            Assert.AreEqual(clinics.Count(), 0);

          

        }
        [TestMethod]
        public void Add_AddClincsInMemory_ReturnVoid()
        {
            clinicRepository.Add(MockClinics.listOfClinic[0]);
            dbContext.SaveChanges();
       
            Assert.AreEqual(1, dbContext.Clinics.Count());

        }
        [TestMethod]
        public void Update_ValidClinic_ReturnVoid()
        {

            clinicRepository.Add(MockClinics.listOfClinic[0]);
            dbContext.SaveChanges();
            clinicRepository.Update(MockClinics.listOfClinic[0]);
            dbContext.SaveChanges();

        }
        [TestMethod]
        public void Delete_ValidId_ReturnVoid()
        {
           
            clinicRepository.Delete(1);
            dbContext.SaveChanges();
            Assert.AreEqual(0, dbContext.Clinics.Count());
        }
       

    }
}
