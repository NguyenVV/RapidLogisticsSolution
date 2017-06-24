using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using System.Security.Cryptography;
using DataModel.UnitOfWork;
using AutoMapper;
using DataModel;
using System.Transactions;

namespace BusinessServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeeServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int ChangePassword(EmployeeEntity employee, string newPassword)
        {
            employee.Pasword = Encrypt(newPassword);
            return CreateOrUpdateEmployee(employee);
        }

        public int CreateOrUpdateEmployee(EmployeeEntity employee)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<EmployeeEntity, Employee>();
                var employeeModel = Mapper.Map<EmployeeEntity, Employee>(employee);

                if (employee.Id > 0)
                {
                    var original = _unitOfWork.EmployeeRepository.GetByID(employee.Id);
                    employeeModel.Pasword = Encrypt(Decrypt(original.Pasword));
                    _unitOfWork.EmployeeRepository.Update(original, employeeModel);
                }
                else
                {
                    employeeModel.Pasword = Encrypt(employee.Pasword);
                    _unitOfWork.EmployeeRepository.Insert(employeeModel);
                }
                
                _unitOfWork.SaveWinform();
                scope.Complete();
                return employeeModel.Id;
            }
        }

        public int Delete(int employeeId)
        {
            throw new NotImplementedException();
        }

        public EmployeeEntity Login(string userName, string password)
        {
            var employee = _unitOfWork.EmployeeRepository.Get(t => t.UserName.Equals(userName,StringComparison.CurrentCultureIgnoreCase));
            if (employee != null)
            {
                string pass = Decrypt(employee.Pasword);
                if (pass.Equals(password + "@123456789"))
                {
                    Mapper.CreateMap<Employee, EmployeeEntity>();
                    var employeeModel = Mapper.Map<Employee, EmployeeEntity>(employee);
                    return employeeModel;
                }
            }
            return null;
        }

        public int ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string userName)
        {
            if (_unitOfWork.EmployeeRepository.Get(t => t.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                return true;
            }

            return false;
        }

        public List<EmployeeEntity> GetAll()
        {
            var employeeList = _unitOfWork.EmployeeRepository.GetAll();
            if (employeeList != null && employeeList.Any())
            {
                Mapper.CreateMap<Employee, EmployeeEntity>();
                var employeeListModel = Mapper.Map<List<Employee>, List<EmployeeEntity>>(employeeList.ToList());
                return employeeListModel;
            }
            return null;
        }

        private string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText + "@123456789");
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        private string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
