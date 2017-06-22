using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IShipmentWaitToConfirmedServices
    {
        string Create(ShipmentWaitConfirmedEntity shipment);
        bool IsExist(string shipmentOutId);
        IEnumerable<ShipmentWaitConfirmedEntity> GetAll();
        void Delete(string shipmentId);
        void Delete(List<string> shipmentIdList);
    }
}
