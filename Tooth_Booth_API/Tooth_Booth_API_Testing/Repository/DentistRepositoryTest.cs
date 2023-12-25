using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tooth_Booth_API.Data;
using Tooth_Booth_API.Repository;
using Tooth_Booth_API_Testing.MockData;

namespace Tooth_Booth_API_Testing.Repository
{
    

    [TestClass]
    public class DentistRepositoryTest
    {

        Mock<ApiDBContext> ApiDBContext;
        DentistRepository dentistRepository;
        ApiDBContext dbContext;
        

        [TestInitialize]
        public void Initialize()
        {
            ApiDBContext = new Mock<ApiDBContext>();
            var options = new DbContextOptionsBuilder<ApiDBContext>().UseInMemoryDatabase(databaseName: "InMemoryDatabase").Options;
            dbContext = new ApiDBContext(options);
           


            dentistRepository = new DentistRepository(dbContext);
        }
        [TestMethod]
        public void GetAll_FetchAllDentist_ReturnListOfDentist()
        {
            var dentist = dentistRepository.GetAll();
            Assert.IsNotNull(dentist);
            Assert.AreEqual(dentist.Count(), 1);



        }
        [TestMethod]
        public void Add_AddDentistInMemory_ReturnVoid()
        {
            dentistRepository.Add(MockDentists.listOfDentist[0]);
            dbContext.SaveChanges();

            Assert.AreEqual(1, dbContext.Dentists.Count());

        }

        [TestMethod]
        public void Update_ValidDentist_ReturnVoid()
        {

            dentistRepository.Add(MockDentists.listOfDentist[0]);
            dbContext.SaveChanges();
            dentistRepository.Update(MockDentists.listOfDentist[0]);
            dbContext.SaveChanges();


        }
        [TestMethod]
        public void Delete_ValidId_ReturnVoid()
        {
            dentistRepository.Add(MockDentists.listOfDentist[0]);
            dbContext.SaveChanges();
            dentistRepository.Delete("ayush");
            dbContext.SaveChanges();
            Assert.AreEqual(0, dbContext.Dentists.Count());
        }


    }
}
