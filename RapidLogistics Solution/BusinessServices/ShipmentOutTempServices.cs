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
    public class ShipmentOutTempServices : IShipmentOutTempServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ShipmentOutTempServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string Create(ShipmentOutEntity shipmentOut)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentOutEntity, ShipmentOutTemp>();
                var shipmentOutEntity = Mapper.Map<ShipmentOutEntity, ShipmentOutTemp>(shipmentOut);
                _unitOfWork.ShipmentOutTempRepository.Insert(shipmentOutEntity);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return shipmentOutEntity.ShipmentId;
            }
        }
        public int Create(List<ShipmentOutEntity> shipmentOutList)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentOutEntity, ShipmentOutTemp>();
                var shipmentOutEntityList = Mapper.Map<List<ShipmentOutEntity>, List<ShipmentOutTemp>>(shipmentOutList);
                int numberInsert = _unitOfWork.ShipmentOutTempRepository.Insert(shipmentOutEntityList);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return numberInsert;
            }
        }
        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentOutTempRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }
        public IEnumerable<ShipmentOutEntity> GetByBoxId(int boxId)
        {
            var shipmentList = _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.BoxIdRef == boxId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOutTemp, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOutTemp>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentEntity> GetByBoxIdToDisplay(int boxId)
        {
            var shipmentListId = _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.BoxIdRef == boxId).Select(p => p.ShipmentId);
            if (shipmentListId != null && shipmentListId.Any())
            {
                var listShipment = _unitOfWork.ShipmentRepository.GetMany(t => shipmentListId.Contains(t.ShipmentId));
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentInfor>, List<ShipmentEntity>>(listShipment.ToList());
                return shipmentListModel;
            }

            return null;
        }
        public IEnumerable<ShipmentOutEntity> GetByDate(DateTime value)
        {
            var shipmentList = _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.DateOut.Value.Date == value.Date);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOutTemp, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOutTemp>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentOutEntity> GetByDateRange(DateTime start, DateTime end)
        {
            var masterList = _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.DateOut.Value.Date >= start.Date && t.DateOut.Value.Date <= end.Date);
            if (masterList != null && masterList.Any())
            {
                Mapper.CreateMap<ShipmentOutTemp, ShipmentOutEntity>();
                var boxInforListModel = Mapper.Map<List<ShipmentOutTemp>, List<ShipmentOutEntity>>(masterList.ToList());
                return boxInforListModel;
            }
            return null;
        }
        public int GetTotalByMasterBill(int id)
        {
            return _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.MasterBillId == id).Count();
        }
        public bool IsExist(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                var shipmentOutEntity = _unitOfWork.ShipmentOutTempRepository.Exists(s => s.ShipmentId == shipmentId);

                scope.Complete();
                return shipmentOutEntity;
            }
        }
        public IEnumerable<ShipmentOutEntity> GetByBoxIdAndEmployeeId(int boxId, int employeeId)
        {
            var shipmentList = _unitOfWork.ShipmentOutTempRepository.GetMany(t => t.BoxIdRef == boxId && t.EmployeeId == employeeId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOutTemp, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOutTemp>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public void DeleteByEmployeeId(int employeeId)
        {
            _unitOfWork.ShipmentOutTempRepository.Delete(t=>t.EmployeeId == employeeId);
            _unitOfWork.SaveWinform();
        }
    }
}
