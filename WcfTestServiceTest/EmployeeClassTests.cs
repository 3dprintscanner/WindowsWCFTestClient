using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWcfService;

namespace WcfTestServiceTest
{
    [TestClass]
    public class EmployeeClassTests
    {
        [TestMethod]
        public void ItShouldReturnAValidStringWhenGetDataIsCalled()
        {
            string testString = "TestName";
            TestWcfService.StaffService staffService = new TestWcfService.StaffService();

            String resultsString = staffService.GetData(testString);

            Assert.AreEqual(resultsString, "You entered: " + testString);
        }

        [TestMethod]
        public void ItShouldReturnAnErrorMessageWhenAnEmptyStringIsPassedToGetData()
        {
            string testString = "";
            TestWcfService.StaffService staffService = new TestWcfService.StaffService();

            String resultsString = staffService.GetData(testString);

            Assert.AreEqual(resultsString, "Please enter a valid name");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldReturnAnArgumentNullExceptionWhenANullObjectIsPassedToTheFunction()
        {
            TestWcfService.StaffService staff = new StaffService();
            String resultsString = staff.GetData(null);


        }

        [TestMethod]
        public void ItShouldReturnAValidEmployeeObjectWhenAValidIdIsPassed()
        {
            TestWcfService.StaffService staff = new StaffService();
            Employee employee = staff.GetLinqEmployeeData(1);

            Assert.IsInstanceOfType(employee,typeof(Employee));
        }

        [TestMethod]
        public void ItShouldReturnValidAttributesForAvalidDataBaseQuery()
        {
            TestWcfService.StaffService staff = new StaffService();
            Employee employee = staff.GetLinqEmployeeData(1);

            Employee firstEmployee = new Employee();
            firstEmployee.id = 1;
            firstEmployee.gender = "Gender";
            firstEmployee.name = "First Name";
            firstEmployee.dateOfBirth = new DateTime(2008, 11,11);

            Assert.AreEqual(employee.id,firstEmployee.id);
            Assert.AreEqual(employee.gender,firstEmployee.gender);
            Assert.AreEqual(employee.name, firstEmployee.name);
            Assert.AreEqual(employee.dateOfBirth, firstEmployee.dateOfBirth);
        }


    }
}
