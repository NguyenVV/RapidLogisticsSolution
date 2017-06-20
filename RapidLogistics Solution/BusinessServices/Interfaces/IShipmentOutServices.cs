using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IShipmentOutServices
    {
        string Create(ShipmentOutEntity shipmentOut);
        int Create(List<ShipmentOutEntity> shipmentOutList);
        bool IsExist(string shipmentOutId);
        IEnumerable<ShipmentOutEntity> GetByBoxId(int boxId);
        void Delete(string shipmentId);
        int GetTotalByMasterBill(int id);
        IEnumerable<ShipmentOutEntity> GetByDate(DateTime value);
        IEnumerable<ShipmentOutEntity> GetByDateRange(DateTime value1, DateTime value2);
    }
}
