using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IManifestServices
    {
        ManifestEntity GetManifestById(int manifestId);
        IEnumerable<ManifestEntity> GetAllManifests();
        int CreateManifest(ManifestEntity manifestEntity);
        int CreateManifest(IEnumerable<ManifestEntity> manifestList);
        bool UpdateManifestEntity(int manifestId, ManifestEntity manifestEntity);
        bool DeleteManifestEntity(int manifestId);
        List<ManifestEntity> GetManifestByDateString(string date);
    }
}
