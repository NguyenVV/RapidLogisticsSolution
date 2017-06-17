using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IEmployeeServices
    {
        int Login(string userName, string password);
        int ChangePassword(string userName, string password, string newPassword);
        int ResetPassword(string email);
        int CreateOrUpdateEmployee(EmployeeEntity employee);
        int Delete(int employeeId);
    }
}
