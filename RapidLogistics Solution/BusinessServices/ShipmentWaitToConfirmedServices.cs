using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.UnitOfWork;
using AutoMapper;
using System.Transactions;
using DataModel;

namespace BusinessServices
{
    public class ShipmentWaitToConfirmedServices : IShipmentWaitToConfirmedServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ShipmentWaitToConfirmedServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string Create(ShipmentWaitConfirmedEntity shipment)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentWaitConfirmedEntity, ShipmentWaitToConfirm>();
                var shipmentEntity = Mapper.Map<ShipmentWaitConfirmedEntity, ShipmentWaitToConfirm>(shipment);
                _unitOfWork.ShipmentWaitConfirmedRepository.Insert(shipmentEntity);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return shipmentEntity.ShipmentId;
            }
        }

        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentWaitConfirmedRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }

        public void Delete(List<string> shipmentIdList)
        {
            _unitOfWork.ShipmentWaitConfirmedRepository.Delete(t => shipmentIdList.Contains(t.ShipmentId));
            _unitOfWork.SaveWinform();
        }

        public IEnumerable<ShipmentWaitConfirmedEntity> GetAll()
        {
            var shipmentList = _unitOfWork.ShipmentWaitConfirmedRepository.GetAll();
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentWaitToConfirm, ShipmentWaitConfirmedEntity>();
                var shipmentListModel = Mapper.Map<List<ShipmentWaitToConfirm>, List<ShipmentWaitConfirmedEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }

        public bool IsExist(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                var shipmentEntity = _unitOfWork.ShipmentWaitConfirmedRepository.Exists(shipmentId);

                scope.Complete();
                return shipmentEntity;
            }
        }
    }
}
