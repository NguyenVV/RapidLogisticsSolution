using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using BusinessEntities;
using DataModel.UnitOfWork;
using AutoMapper;
using System.Transactions;
using DataModel;
using System.Linq;

namespace BusinessServices
{
    public class WarehouseServices : IWarehouseServices
    {
        private readonly UnitOfWork _unitOfWork;

        public WarehouseServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CreateOrUpdate(WarehouseEntity entity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<WarehouseEntity, Warehouse>();
                var warehouseDataModel = Mapper.Map<WarehouseEntity, Warehouse>(entity);
                if(entity.Id > 0)
                {
                    var original = _unitOfWork.WarehouseRepository.GetByID(entity.Id);
                    _unitOfWork.WarehouseRepository.Update(original, warehouseDataModel);
                }
                else
                {
                    _unitOfWork.WarehouseRepository.Insert(warehouseDataModel);
                }
                
                _unitOfWork.SaveWinform();
                scope.Complete();
                return warehouseDataModel.Id;
            }
        }

        public List<WarehouseEntity> GetAll()
        {
            var warehouseList = _unitOfWork.WarehouseRepository.GetAll();
            if (warehouseList != null && warehouseList.Any())
            {
                Mapper.CreateMap<Warehouse, WarehouseEntity>();
                var warehoustListModel = Mapper.Map<List<Warehouse>, List<WarehouseEntity>>(warehouseList.ToList());
                return warehoustListModel;
            }
            return null;
        }

        public WarehouseEntity GetById(int id)
        {
            using (var scope = new TransactionScope())
            {
                var entity = _unitOfWork.WarehouseRepository.GetByID(id);
                if (entity != null)
                {
                    Mapper.CreateMap<Warehouse, WarehouseEntity>();
                    var warehouseEntity = Mapper.Map<Warehouse, WarehouseEntity>(entity);

                    return warehouseEntity;
                }

                return null;
            }
        }
    }
}
