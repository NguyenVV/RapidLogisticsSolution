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
    public class BoxOutServices : IBoxOutServices
    {
        private readonly UnitOfWork _unitOfWork;
        public BoxOutServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateBoxOut(BoxOutEntity boxOut)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<BoxOutEntity, BoxOut>();
                var boxOutService = Mapper.Map<BoxOutEntity, BoxOut>(boxOut);
                _unitOfWork.BoxOutRepository.Insert(boxOutService);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return boxOutService.Id;
            }
        }
        public BoxOutEntity GetByBoxId(int boxId)
        {
            var boxOutList = _unitOfWork.BoxOutRepository.Get(t => t.Id == boxId);
            if (boxOutList != null)
            {
                Mapper.CreateMap<BoxOut, BoxOutEntity>();
                var boxOutModel = Mapper.Map<BoxOut, BoxOutEntity>(boxOutList);
                return boxOutModel;
            }
            return null;
        }
        public BoxOutEntity GetByBoxCodeandAirWaybill(string boxId, int masterbillid)
        {
            var boxOutList = _unitOfWork.BoxOutRepository.Get(t => t.BoxId == boxId && t.MasterBillId == masterbillid);
            if (boxOutList != null)
            {
                Mapper.CreateMap<BoxOut, BoxOutEntity>();
                var boxOutModel = Mapper.Map<BoxOut, BoxOutEntity>(boxOutList);
                return boxOutModel;
            }
            return null;
        }
        public BoxOutEntity GetByBoxCode(string boxId)
        {
            var boxOutList = _unitOfWork.BoxOutRepository.Get(t => t.BoxId == boxId);
            if (boxOutList != null)
            {
                Mapper.CreateMap<BoxOut, BoxOutEntity>();
                var boxOutModel = Mapper.Map<BoxOut, BoxOutEntity>(boxOutList);
                return boxOutModel;
            }
            return null;
        }
        public IEnumerable<BoxOutEntity> GetAllBoxByMasterBill(int masterBillId)
        {
            var list = _unitOfWork.BoxOutRepository.GetMany(t => t.MasterBillId == masterBillId).Select(t => new BoxOutEntity { Id = (int)t.Id, MasterBillId = (int)t.MasterBillId, BoxId = t.BoxId });
            return list.OrderByDescending(t => t.Id).ToList();
        }
        public int CreateOrUpdateByQuery(int total, int id)
        {
          return  _unitOfWork.ShipmentOutRepository.ExecuteUpdateQuery(string.Format("Update BoxOut set ShipmentQuantity=" + total + " Where Id =" + id ));
        }
        public void Delete(int id)
        {
            _unitOfWork.BoxOutRepository.Delete(id);
            _unitOfWork.SaveWinform();
        }
    }
}
