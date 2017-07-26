using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    public interface IManifestServices
    {
        ManifestEntity GetManifestById(int manifestId);
        ManifestEntity GetManifestByShipmentId(string shipmentId);
        IEnumerable<ManifestEntity> GetAllManifests();
        int CreateManifest(ManifestEntity manifestEntity);
        int CreateManifest(IEnumerable<ManifestEntity> manifestList);
        bool UpdateManifestEntity(int manifestId, ManifestEntity manifestEntity);
        bool DeleteManifestEntity(int manifestId);
        List<ManifestEntity> GetManifestByDateString(string date);
    }
}
