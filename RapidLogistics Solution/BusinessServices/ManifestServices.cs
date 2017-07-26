using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.UnitOfWork;
using DataModel;
using AutoMapper;
using System.Transactions;
using BusinessServices.Interfaces;

namespace BusinessServices
{
    public class ManifestServices : IManifestServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ManifestServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CreateManifest(IEnumerable<ManifestEntity> manifestList)
        {
            using (var scope = new TransactionScope())
            {
                if (manifestList.Any())
                {
                    Mapper.CreateMap<ManifestEntity, Manifest>();
                    var manifestsModels = Mapper.Map<IEnumerable<ManifestEntity>, List<Manifest>>(manifestList.ToList());

                    foreach (var manifest in manifestsModels)
                    {
                        _unitOfWork.ManifestRepository.Insert(manifest);
                    }
                }
                
                _unitOfWork.Save();
                scope.Complete();
                return manifestList.Count();
            }
        }

        public int CreateManifest(ManifestEntity manifestEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<Manifest, ManifestEntity>();
                var manifest = Mapper.Map<ManifestEntity, Manifest>(manifestEntity);
                _unitOfWork.ManifestRepository.Insert(manifest);
                _unitOfWork.Save();
                scope.Complete();
                return manifest.Id;
            }
        }

        public bool DeleteManifestEntity(int manifestId)
        {
            var success = false;
            if (manifestId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var manifest = _unitOfWork.ManifestRepository.GetByID(manifestId);
                    if (manifest != null)
                    {
                        _unitOfWork.ManifestRepository.Delete(manifest);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<ManifestEntity> GetAllManifests()
        {
            var manifests = _unitOfWork.ManifestRepository.GetAll();
            if (manifests!=null && manifests.Any())
            {
                Mapper.CreateMap<Manifest, ManifestEntity>();
                var manifestsModel = Mapper.Map<List<Manifest>, List<ManifestEntity>>(manifests.ToList());
                return manifestsModel;
            }
            return null;
        }

        public ManifestEntity GetManifestById(int manifestId)
        {
            var manifest = _unitOfWork.ManifestRepository.GetByID(manifestId);
            if (manifest != null)
            {
                Mapper.CreateMap<Manifest, ManifestEntity>();
                var manifestModel = Mapper.Map<Manifest, ManifestEntity>(manifest);
                return manifestModel;
            }
            return null;
        }

        public ManifestEntity GetManifestByShipmentId(string shipmentId)
        {
            var manifest = _unitOfWork.ManifestRepository.GetFirst(t=>t.ShipmentNo.Equals(shipmentId,StringComparison.CurrentCultureIgnoreCase));
            if (manifest != null)
            {
                Mapper.CreateMap<Manifest, ManifestEntity>();
                var manifestModel = Mapper.Map<Manifest, ManifestEntity>(manifest);
                return manifestModel;
            }

            return null;
        }

        public bool UpdateManifestEntity(int manifestId, ManifestEntity manifestEntity)
        {
            var success = false;
            if (manifestEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var manifest = _unitOfWork.ManifestRepository.GetByID(manifestId);
                    if (manifest != null)
                    {
                        Manifest manifestNew = new Manifest();
                        manifestNew.MasterAirWayBill = manifestEntity.MasterAirWayBill;
                        manifestNew.Id = manifest.Id;
                        _unitOfWork.ManifestRepository.Update(manifest, manifestNew);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        

        public List<ManifestEntity> GetManifestByDateString(string date)
        {
            List<Manifest> manifest = _unitOfWork.ManifestRepository.GetMany(t => t.FlightDate.Equals(date)).ToList();
            if (manifest != null)
            {
                Mapper.CreateMap<Manifest, ManifestEntity>();
                var manifestModel = Mapper.Map<List<Manifest>, List<ManifestEntity>>(manifest);
                return manifestModel;
            }

            return null;
        }
    }
}
