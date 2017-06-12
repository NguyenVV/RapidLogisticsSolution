using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;
using BusinessServices.Interfaces;

namespace BusinessServices
{
   
    public class ShipmentOutServices : IShipmentOutServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ShipmentOutServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string Create(ShipmentOutEntity shipmentOut)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentOutEntity, ShipmentOut>();
                var shipmentOutEntity = Mapper.Map<ShipmentOutEntity, ShipmentOut>(shipmentOut);
                _unitOfWork.ShipmentOutRepository.Insert(shipmentOutEntity);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return shipmentOutEntity.ShipmentId;
            }
        }

        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentOutRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }

        public IEnumerable<ShipmentOutEntity> GetByBoxId(int boxId)
        {
            var shipmentList = _unitOfWork.ShipmentOutRepository.GetMany(t => t.BoxIdRef == boxId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOut, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOut>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }

        public IEnumerable<ShipmentOutEntity> GetByDate(DateTime value)
        {
            var shipmentList = _unitOfWork.ShipmentOutRepository.GetMany(t => t.DateOut.Value.Date == value.Date);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOut, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOut>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }

        public IEnumerable<ShipmentOutEntity> GetByDateRange(DateTime start, DateTime end)
        {
            var masterList = _unitOfWork.ShipmentOutRepository.GetMany(t => t.DateOut.Value.Date >= start.Date && t.DateOut.Value.Date <= end.Date);
            if (masterList != null && masterList.Any())
            {
                Mapper.CreateMap<ShipmentOut, ShipmentOutEntity>();
                var boxInforListModel = Mapper.Map<List<ShipmentOut>, List<ShipmentOutEntity>>(masterList.ToList());
                return boxInforListModel;
            }
            return null;
        }

        public int GetTotalByMasterBill(int id)
        {
            return _unitOfWork.ShipmentOutRepository.GetMany(t => t.MasterBillId == id).Count();
        }

        public bool IsExist(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                var shipmentOutEntity = _unitOfWork.ShipmentOutRepository.Exists(shipmentId);
               
                scope.Complete();
                return shipmentOutEntity;
            }
        }
    }
}
