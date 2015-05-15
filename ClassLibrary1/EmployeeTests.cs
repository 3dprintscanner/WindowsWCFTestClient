using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using TestWcfService;
using Moq;


namespace EmployeeTests
{
    [TestFixture]
    public class EmployeeTests
    {
        private TestWcfService.StaffService staffService;
        private Mock<IEmployeeDataBaseService> mockDataBaseService;
            
        
        [Test]
        public void ItShouldReturnAnEmployeeObjectWhenCalledWithAValidId()
        {
            Mock<IEmployeeDataBaseService> mockDataBaseService = new Mock<IEmployeeDataBaseService>();

            Employee testEmployee = new Employee(1,"Test Name", "Male", DateTime.Now);
            mockDataBaseService.Setup(t => t.GetEmployeeById(It.IsAny<int>())).Returns(() => testEmployee);


            TestWcfService.StaffService staffService = new TestWcfService.StaffService(mockDataBaseService.Object);

            Assert.AreEqual(testEmployee, staffService.employeeDataBaseService.GetEmployeeById(1));
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ItShouldReturnAnIndexOutOfRangeExceptionWhenAnIdOutOfRangeIsGiven()
        {
            Mock<IEmployeeDataBaseService> mockDataBaseService = new Mock<IEmployeeDataBaseService>();

            mockDataBaseService.Setup(t => t.GetEmployeeById(4)).Throws(new IndexOutOfRangeException());

            TestWcfService.StaffService staffService = new TestWcfService.StaffService(mockDataBaseService.Object);

            staffService.employeeDataBaseService.GetEmployeeById(4);


        }
    }
}
