using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IShipmentOutTempServices
    {
        string Create(ShipmentOutEntity shipmentOut);
        bool IsExist(string shipmentOutId);
        IEnumerable<ShipmentOutEntity> GetByBoxId(int boxId);
        IEnumerable<ShipmentEntity> GetByBoxIdToDisplay(int boxId);
        IEnumerable<ShipmentOutEntity> GetByBoxIdAndEmployeeId(int boxId, int employeeId);
        void Delete(string shipmentId);
        void DeleteByEmployeeId(int employeeId);
        int GetTotalByMasterBill(int id);
        IEnumerable<ShipmentOutEntity> GetByDate(DateTime value);
        IEnumerable<ShipmentOutEntity> GetByDateRange(DateTime value1, DateTime value2);
    }
}
