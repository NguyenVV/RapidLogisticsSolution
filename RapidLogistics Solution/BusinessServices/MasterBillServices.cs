using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;

namespace BusinessServices.Interfaces
{
    public class MasterBillServices : IMasterBillServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public MasterBillServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateMasterAirwayBill(MasterAirwayBillEntity masterAirwayBillEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<MasterAirwayBillEntity, MasterBill>();
                var masterBillService = Mapper.Map<MasterAirwayBillEntity, MasterBill>(masterAirwayBillEntity);
                _unitOfWork.MasterBillRepository.Insert(masterBillService);
                _unitOfWork.SaveWinform();
                scope.Complete();
                return masterBillService.Id;
            }
        }

        public IEnumerable<MasterAirwayBillEntity> GetAll()
        {
            var masterBillList = _unitOfWork.MasterBillRepository.GetAll();
            if (masterBillList != null && masterBillList.Any())
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var masterBillListModel = Mapper.Map<List<MasterBill>, List<MasterAirwayBillEntity>>(masterBillList.ToList());
                return masterBillListModel;
            }
            return null;
        }

        public IEnumerable<MasterAirwayBillEntity> GetByDateArrived(DateTime dateArrived)
        {
            var masterBillList = _unitOfWork.MasterBillRepository.GetMany(t => t.DateArrived.Value.ToString("yyyyMMdd").Equals(dateArrived.Date.ToString("yyyyMMdd"))).OrderByDescending(t=>t.DateArrived);
            if (masterBillList != null && masterBillList.Any())
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var masterBillListModel = Mapper.Map<List<MasterBill>, List<MasterAirwayBillEntity>>(masterBillList.ToList());
                return masterBillListModel;
            }
            return null;
        }

        public IEnumerable<MasterAirwayBillEntity> SearchByMasterBillId(string masterId)
        {
            var masterBillList = _unitOfWork.MasterBillRepository.GetMany(t=>t.MasterAirWayBill.Contains(masterId));
            if (masterBillList != null && masterBillList.Any())
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var masterBillListModel = Mapper.Map<List<MasterBill>, List<MasterAirwayBillEntity>>(masterBillList.ToList());
                return masterBillListModel;
            }
            return null;
        }

        public MasterAirwayBillEntity GetByMasterBillId(string masterId)
        {
            var masterBill = _unitOfWork.MasterBillRepository.Get(t => t.MasterAirWayBill == masterId);
            if (masterBill != null)
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var masterBillModel = Mapper.Map<MasterBill, MasterAirwayBillEntity>(masterBill);
                return masterBillModel;
            }
            return null;
        }

        public MasterAirwayBillEntity GetByMasterBillId(int masterId)
        {
            var masterBill = _unitOfWork.MasterBillRepository.Get(t => t.Id == masterId);
            if (masterBill != null)
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var masterBillModel = Mapper.Map<MasterBill, MasterAirwayBillEntity>(masterBill);
                return masterBillModel;
            }
            return null;
        }

        public bool Exists(string text)
        {
            var masterBill = _unitOfWork.MasterBillRepository.Get(t => t.MasterAirWayBill.Equals(text,StringComparison.CurrentCultureIgnoreCase));
            
            return masterBill != null;
        }
        
        public IEnumerable<MasterAirwayBillEntity> GetByDateRange(DateTime start, DateTime end)
        {
            var masterList = _unitOfWork.MasterBillRepository.GetMany(t => t.DateArrived.Value.Date>= start.Date && t.DateArrived.Value.Date <= end.Date);
            if (masterList != null && masterList.Any())
            {
                Mapper.CreateMap<MasterBill, MasterAirwayBillEntity>();
                var boxInforListModel = Mapper.Map<List<MasterBill>, List<MasterAirwayBillEntity>>(masterList.ToList());
                return boxInforListModel;
            }

            return null;
        }
    }
}
