using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public interface IBusinessProfileServices
    {
        BusinessProfileEntity GetBusinessProfileEntityById(int productId);
        IEnumerable<BusinessProfileEntity> GetAllBusinessProfileEntitys();
        int CreateBusinessProfileEntity(BusinessProfileEntity businessProfileEntity);
        bool UpdateBusinessProfileEntity(int businessProfileEntityId, BusinessProfileEntity businessProfileEntity);
        bool DeleteBusinessProfileEntity(int businessProfileEntityId);
    }
}
