using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IWarehouseServices
    {
        WarehouseEntity GetById(int id);
        int CreateOrUpdate(WarehouseEntity entity);
        List<WarehouseEntity> GetAll();
    }
}
