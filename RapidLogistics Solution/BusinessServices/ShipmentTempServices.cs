using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class ShipmentTempServices:IShipmentTempServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ShipmentTempServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Create(List<ShipmentEntity> shipmentList)
        {
            using (var scope = new TransactionScope())
            {
                if (shipmentList.Any())
                {
                    Mapper.CreateMap<ShipmentEntity, ShipmentInforTemp>();
                    var shipmentListModel = Mapper.Map<List<ShipmentEntity>, List<ShipmentInforTemp>>(shipmentList);
                    int count = _unitOfWork.ShipmentTempRepository.Insert(shipmentListModel);
                    _unitOfWork.SaveWinform();
                    scope.Complete();

                    return count;
                }
            }

            return 0;
        }
        public int Create(ShipmentEntity shipmentEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentEntity, ShipmentInforTemp>();
                var shipmentDataModel = Mapper.Map<ShipmentEntity, ShipmentInforTemp>(shipmentEntity);
                _unitOfWork.ShipmentTempRepository.Insert(shipmentDataModel);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return shipmentDataModel.Id;
            }
        }
        public IEnumerable<ShipmentEntity> GetByBoxId(int boxId)
        {
            var shipmentList = _unitOfWork.ShipmentTempRepository.GetMany(t => t.BoxId == boxId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentInforTemp, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentInforTemp>, List<ShipmentEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentEntity> GetByBoxIdAndEmployeeId(int boxId, int employeeId)
        {
            var shipmentList = _unitOfWork.ShipmentTempRepository.GetMany(t => t.BoxId == boxId && t.EmployeeId == employeeId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentInforTemp, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentInforTemp>, List<ShipmentEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentEntity> GetByDate(string shipmentId)
        {
            throw new NotImplementedException();
        }
        public ShipmentEntity GetByShipmentId(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                ShipmentInforTemp shipmentDataModel = _unitOfWork.ShipmentTempRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
                if (shipmentDataModel == null)
                {
                    scope.Complete();
                    return null;
                }
                Mapper.CreateMap<ShipmentInforTemp, ShipmentEntity>();
                var shipmentData = Mapper.Map<ShipmentInforTemp, ShipmentEntity>(shipmentDataModel);
                scope.Complete();
                return shipmentData;
            }
        }
        public string[] GetReferenceOfShipment(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                string[] arr = new string[6];
                ShipmentInforTemp shipmentDataModel = _unitOfWork.ShipmentTempRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));

                if (shipmentDataModel != null)
                {
                    arr[0] = shipmentDataModel.Id.ToString();
                    arr[1] = shipmentDataModel.ShipmentId;
                    arr[2] = shipmentDataModel.BoxInfo.Id.ToString();
                    arr[3] = shipmentDataModel.BoxInfo.BoxId;
                    arr[4] = shipmentDataModel.BoxInfo.MasterBill.Id.ToString();
                    arr[5] = shipmentDataModel.BoxInfo.MasterBill.MasterAirWayBill;
                    scope.Complete();

                    return arr;
                }

                scope.Complete();
                return null;
            }
        }
        public bool Exists(string shipmentId)
        {
            return _unitOfWork.ShipmentTempRepository.Get(t => t.ShipmentId == shipmentId) == null ? false : true;
        }
        public void Delete(int shipmentId)
        {
            _unitOfWork.ShipmentTempRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }
        public ShipmentEntity GetByShipmentIdAndBoxId(string shipmentId, int boxId)
        {
            using (var scope = new TransactionScope())
            {
                ShipmentInforTemp shipmentDataModel = _unitOfWork.ShipmentTempRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase) && t.BoxId == boxId);
                if (shipmentDataModel == null)
                {
                    scope.Complete();
                    return null;
                }
                Mapper.CreateMap<ShipmentInforTemp, ShipmentEntity>();
                var shipmentData = Mapper.Map<ShipmentInforTemp, ShipmentEntity>(shipmentDataModel);
                scope.Complete();
                return shipmentData;
            }
        }
        public ReportDetailEntity SearchByShipmentId(string shipmentId)
        {
            ReportDetailEntity reportEntity = new ReportDetailEntity();
            var result = _unitOfWork.ShipmentTempRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
            if (result != null)
            {
                reportEntity.ShipmentId = result.ShipmentId;

                if (result.BoxInfo != null)
                {
                    reportEntity.BoxId = result.BoxInfo.BoxId;
                }
                else
                {
                    reportEntity.BoxId = string.Empty;
                }

                return reportEntity;
            }
            return null;
        }
        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentTempRepository.Delete(t => t.ShipmentId == shipmentId);
            _unitOfWork.SaveWinform();
        }
        public void DeleteByEmployeeId(int employeeId)
        {
            _unitOfWork.ShipmentTempRepository.Delete(t => t.EmployeeId == employeeId);
            _unitOfWork.SaveWinform();
        }
    }
}
