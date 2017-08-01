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
    public class BoxInforServices : IBoxInforServices
    {
        private readonly UnitOfWork _unitOfWork;

        public BoxInforServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateBoxInfor(BoxInforEntity boxInfor)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<BoxInforEntity, BoxInfo>();
                var boxInforService = Mapper.Map<BoxInforEntity, BoxInfo>(boxInfor);
                _unitOfWork.BoxInforRepository.Insert(boxInforService);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return boxInforService.Id;
            }
        }

        public BoxInforEntity GetByBoxId(string boxId)
        {
            var boxInforList = _unitOfWork.BoxInforRepository.Get(t => t.BoxId == boxId);
            if (boxInforList != null)
            {
                Mapper.CreateMap<BoxInfo, BoxInforEntity>();
                var boxInforModel = Mapper.Map<BoxInfo, BoxInforEntity>(boxInforList);
                return boxInforModel;
            }
            return null;
        }

        public BoxInforEntity GetByBoxId(int boxId)
        {
            var boxInforList = _unitOfWork.BoxInforRepository.Get(t => t.Id == boxId);
            if (boxInforList != null)
            {
                Mapper.CreateMap<BoxInfo, BoxInforEntity>();
                var boxInforModel = Mapper.Map<BoxInfo, BoxInforEntity>(boxInforList);
                return boxInforModel;
            }
            return null;
        }

        public int GetTotalByMasterBill(int masterBillId)
        {
            return _unitOfWork.BoxInforRepository.GetMany(t => t.MasterBillId == masterBillId).GroupBy(b=>b.BoxId).Select(box=>box.First()).Count();
        }

        public int GetTotalShipmentByMasterBill(int masterBillId)
        {
            int total = 0;
            var list = _unitOfWork.BoxInforRepository.GetMany(t => t.MasterBillId == masterBillId);
            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    total += _unitOfWork.ShipmentRepository.GetMany(t => t.BoxId == item.Id).GroupBy(s=>s.ShipmentId).Select(sh=>sh.First()).Count();
                }
            }

            return total;
        }

        public IEnumerable<BoxInforEntity> GetByDateArrived(DateTime dateArrived)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoxInforEntity> GetByMasterBill(int masterBillId)
        {
            var boxInforList = _unitOfWork.BoxInforRepository.GetMany(t => t.MasterBillId == masterBillId).OrderByDescending(t => t.DateCreated);
            if (boxInforList != null && boxInforList.Any())
            {
                Mapper.CreateMap<BoxInfo, BoxInforEntity>();
                var boxInforListModel = Mapper.Map<List<BoxInfo>, List<BoxInforEntity>>(boxInforList.ToList());
                return boxInforListModel;
            }
            return null;
        }
        public int GetTotalCountByMasterId(int masterId)
        {
            return _unitOfWork.BoxInforRepository.GetMany(t => t.MasterBillId == masterId).Count();
        }
    }
}
