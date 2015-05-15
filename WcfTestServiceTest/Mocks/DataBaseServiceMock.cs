using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWcfService;

namespace WcfTestServiceTest.Mocks
{
    class DataBaseServiceMock : TestWcfService.IEmployeeService
    {

        public string GetData(string value)
        {
            throw new NotImplementedException();
        }

        public string GetMoreData(int value)
        {
            throw new NotImplementedException();
        }

        public void SaveEmployeeData(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeData(string id)
        {
            throw new NotImplementedException();
        }

        public Employee GetLinqEmployeeData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
