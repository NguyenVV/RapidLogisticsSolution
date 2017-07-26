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
        public int Create(List<ShipmentOutEntity> shipmentOutList)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentOutEntity, ShipmentOut>();
                var shipmentOutEntityList = Mapper.Map<List<ShipmentOutEntity>, List<ShipmentOut>>(shipmentOutList);
                int numberInsert = _unitOfWork.ShipmentOutRepository.Insert(shipmentOutEntityList);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return numberInsert;
            }
        }
        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentOutRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }
        public IEnumerable<ShipmentOutEntity> GetByBoxId(int boxId)
        {
            var shipmentList = _unitOfWork.ShipmentOutRepository.GetMany(t => t.BoxIdRef == boxId).OrderByDescending(t=>t.DateOut);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentOut, ShipmentOutEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentOut>, List<ShipmentOutEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }

            return null;
        }

        public IEnumerable<ShipmentEntity> GetByBoxIdToDisplay(int boxId)
        {
            var shipmentListId = _unitOfWork.ShipmentOutRepository.GetMany(t => t.BoxIdRef == boxId).OrderByDescending(t => t.DateOut).Select(p=>p.ShipmentId);
            if (shipmentListId != null && shipmentListId.Any())
            {
                var listShipment = _unitOfWork.ShipmentRepository.GetMany(t => shipmentListId.Contains(t.ShipmentId));
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentInfor>, List<ShipmentEntity>>(listShipment.ToList());
                return shipmentListModel;
            }

            return null;
        }

        public IEnumerable<ShipmentOutEntity> GetByMasterBillId(int masterBillId)
        {
            var shipmentList = _unitOfWork.ShipmentOutRepository.GetMany(t => t.MasterBillId == masterBillId).OrderByDescending(t => t.DateOut);
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

        public IEnumerable<MasterAirwayBillEntity> GetAllMasterBillByDate(DateTime value)
        {
            var list = _unitOfWork.ShipmentOutRepository.GetMany(t => t.DateOut.Value.Date == value.Date).Select(t => new MasterAirwayBillEntity { Id = (int)t.MasterBillId, MasterAirwayBill = t.MasterBillIdString });
            return list.GroupBy(t=>t.MasterAirwayBill).Select(y => y.First());
        }

        public IEnumerable<BoxInforEntity> GetAllBoxByMasterBill(int masterBillId)
        {
            var list = _unitOfWork.ShipmentOutRepository.GetMany(t => t.MasterBillId == masterBillId).Select(t => new BoxInforEntity { Id = (int)t.MasterBillId, BoxId = t.BoxIdString });
            return list.GroupBy(t => t.BoxId).Select(y => y.First());
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

        public ShipmentOutEntity GetByShipmentId(string shipId)
        {
            var shipment = _unitOfWork.ShipmentOutRepository.GetByID(shipId);
            if (shipment != null)
            {
                Mapper.CreateMap<ShipmentOut, ShipmentOutEntity>();
                var shipmentModel = Mapper.Map<ShipmentOut, ShipmentOutEntity>(shipment);
                return shipmentModel;
            }

            return null;
        }
    }
}
