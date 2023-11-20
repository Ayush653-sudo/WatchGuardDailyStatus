
using Tooth_Booth_.database;
using Tooth_Booth_.DatabaseHandler;
using Tooth_Booth_.models;

namespace Tooth_Booth_.test.DataBase.test
{
    [TestClass] 
    class AppointmentDBHandlerTest
    {
        [TestMethod]
        public void Update_ValidInput_true()
        {
            IDBHandler<Appointment> appointmentDBHandler = AppointmentDBHandler.handler;
        }
    }
}
