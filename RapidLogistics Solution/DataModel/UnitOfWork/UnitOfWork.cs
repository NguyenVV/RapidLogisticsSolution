#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;

#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly WebApiDbEntities _contextWebApi = null;
        private readonly RapidSolutionEntities _contextWinform = null;
        private GenericRepository<User> _userRepository;
        //private GenericRepository<Product> _productRepository;
        private GenericRepository<Token> _tokenRepository;
        private GenericRepository<Manifest> _manifestRepository;
        private GenericRepository<Business_profile> _businessProfileRepository;
        private GenericRepository<MasterBill> _masterBillRepository;
        private GenericRepository<BoxInfo> _boxInforRepository;
        private GenericRepository<ShipmentInfor> _shipmentRepository; 
        private GenericRepository<ShipmentOut> _shipmentOutRepository;
        private GenericRepository<ShipmentWaitToConfirm> _shipmentWaitConfirmedRepository;
        private GenericRepository<Employee> _employeeRepository;

        #endregion

        public UnitOfWork()
        {
            _contextWebApi = new WebApiDbEntities();
            _contextWinform = new RapidSolutionEntities();
        }

        #region Public Repository Creation properties...

        ///// <summary>
        ///// Get/Set Property for product repository.
        ///// </summary>
        //public GenericRepository<Product> ProductRepository
        //{
        //    get
        //    {
        //        if (this._productRepository == null)
        //            this._productRepository = new GenericRepository<Product>(_context);
        //        return _productRepository;
        //    }
        //}

        /// <summary>
        /// Get/Set Property for manifest repository.
        /// </summary>
        public GenericRepository<Manifest> ManifestRepository
        {
            get
            {
                if (this._manifestRepository == null)
                    this._manifestRepository = new GenericRepository<Manifest>(_contextWinform);
                return _manifestRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for business profile repository.
        /// </summary>
        public GenericRepository<Business_profile> BusinessProfileRepository
        {
            get
            {
                if (this._businessProfileRepository == null)
                    this._businessProfileRepository = new GenericRepository<Business_profile>(_contextWebApi);
                return _businessProfileRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_contextWebApi);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(_contextWebApi);
                return _tokenRepository;
            }
        }

        public GenericRepository<MasterBill> MasterBillRepository
        {
            get
            {
                if (this._masterBillRepository == null)
                    this._masterBillRepository = new GenericRepository<MasterBill>(_contextWinform);
                return _masterBillRepository;
            }
        }

        public GenericRepository<BoxInfo> BoxInforRepository
        {
            get
            {
                if (this._boxInforRepository == null)
                    this._boxInforRepository = new GenericRepository<BoxInfo>(_contextWinform);
                return _boxInforRepository;
            }
        }

        public GenericRepository<ShipmentInfor> ShipmentRepository
        {
            get
            {
                if (this._shipmentRepository == null)
                    this._shipmentRepository = new GenericRepository<ShipmentInfor>(_contextWinform);
                return _shipmentRepository;
            }
        }

        public GenericRepository<ShipmentOut> ShipmentOutRepository
        {
            get
            {
                if (this._shipmentOutRepository == null)
                    this._shipmentOutRepository = new GenericRepository<ShipmentOut>(_contextWinform);
                return _shipmentOutRepository;
            }
        }

        public GenericRepository<ShipmentWaitToConfirm> ShipmentWaitConfirmedRepository
        {
            get
            {
                if (this._shipmentWaitConfirmedRepository == null)
                    this._shipmentWaitConfirmedRepository = new GenericRepository<ShipmentWaitToConfirm>(_contextWinform);
                return _shipmentWaitConfirmedRepository;
            }
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new GenericRepository<Employee>(_contextWinform);
                return _employeeRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _contextWebApi.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }
        public void SaveWinform()
        {
            try
            {
                _contextWinform.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errorsWinform.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _contextWinform.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}