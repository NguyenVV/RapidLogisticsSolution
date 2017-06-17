using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices
{
    public class EmployeeServices : IEmployeeServices
    {
        public int ChangePassword(string userName, string password, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdateEmployee(EmployeeEntity employee)
        {
            throw new NotImplementedException();
        }

        public int Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public int Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public int ResetPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}
