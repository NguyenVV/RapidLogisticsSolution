using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.UnitOfWork;
using System.Transactions;
using DataModel;
using AutoMapper;

namespace BusinessServices
{
    public class BusinessProfileServices : IBusinessProfileServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public BusinessProfileServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateBusinessProfileEntity(BusinessProfileEntity businessProfileEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<BusinessProfileEntity, Business_profile>();
                var businessProfile = Mapper.Map<BusinessProfileEntity, Business_profile>(businessProfileEntity);
                //businessProfile.DateCreated = null;
                _unitOfWork.BusinessProfileRepository.Insert(businessProfile);
                _unitOfWork.Save();
                scope.Complete();
                return businessProfile.Id;
            }
        }

        public bool DeleteBusinessProfileEntity(int businessProfileEntityId)
        {
            var success = false;
            if (businessProfileEntityId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var businessProfile = _unitOfWork.BusinessProfileRepository.GetByID(businessProfileEntityId);
                    if (businessProfile != null)
                    {
                        _unitOfWork.BusinessProfileRepository.Delete(businessProfile);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<BusinessProfileEntity> GetAllBusinessProfileEntitys()
        {
            var businessProfiles = _unitOfWork.BusinessProfileRepository.GetAll();
            if (businessProfiles!=null && businessProfiles.Any())
            {
                Mapper.CreateMap<Business_profile, BusinessProfileEntity>();
                var businessProfilesModel = Mapper.Map<List<Business_profile>, List<BusinessProfileEntity>>(businessProfiles.ToList());
                return businessProfilesModel;
            }
            return null;
        }

        public BusinessProfileEntity GetBusinessProfileEntityById(int businessProfileId)
        {
            var businessProfile = _unitOfWork.BusinessProfileRepository.GetByID(businessProfileId);
            if (businessProfile != null)
            {
                Mapper.CreateMap<Business_profile, BusinessProfileEntity>();
                var businessProfileModel = Mapper.Map<Business_profile, BusinessProfileEntity>(businessProfile);
                return businessProfileModel;
            }
            return null;
        }

        public bool UpdateBusinessProfileEntity(int businessProfileEntityId, BusinessProfileEntity businessProfileEntity)
        {
            var success = false;
            if (businessProfileEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var businessProfile = _unitOfWork.BusinessProfileRepository.GetByID(businessProfileEntityId);
                    if (businessProfile != null)
                    {
                        businessProfile.Name = businessProfileEntity.Name;
                        _unitOfWork.BusinessProfileRepository.Update(businessProfile);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
