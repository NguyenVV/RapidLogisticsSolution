using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IEmployeeServices
    {
        EmployeeEntity Login(string userName, string password);
        int ChangePassword(EmployeeEntity employee, string newPassword);
        int ResetPassword(string email);
        int CreateOrUpdateEmployee(EmployeeEntity employee);
        int Delete(int employeeId);
        bool IsExist(string userName);
        List<EmployeeEntity> GetAll();
        void RefreshConnection();
        bool isConnection();
    }
}
