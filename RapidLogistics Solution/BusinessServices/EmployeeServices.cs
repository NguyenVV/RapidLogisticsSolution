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
        public int ChangePassword(string userName, string password, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int CreateOrUpdateEmployee(EmployeeEntity employee)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<EmployeeEntity, Employee>();
                var employeeModel = Mapper.Map<EmployeeEntity, Employee>(employee);

                if (employee.Id > 0)
                {
                    _unitOfWork.EmployeeRepository.Update(employeeModel);
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
            var employee = _unitOfWork.EmployeeRepository.Get(t => t.UserName.Equals(userName,StringComparison.CurrentCultureIgnoreCase) && Decrypt(t.Pasword).Equals(password + "@123456789"));
            if (employee != null)
            {
                Mapper.CreateMap<Employee, EmployeeEntity>();
                var employeeModel = Mapper.Map<Employee, EmployeeEntity>(employee);
                return employeeModel;
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

        private string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText + "@123456789");
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        private string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
