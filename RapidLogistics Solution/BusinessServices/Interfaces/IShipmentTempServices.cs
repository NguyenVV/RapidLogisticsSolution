using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IShipmentTempServices
    {
        int Create(ShipmentEntity shipmentEntity);
        int Create(List<ShipmentEntity> shipmentList);
        ShipmentEntity GetByShipmentId(string shipmentId);
        string[] GetReferenceOfShipment(string shipmentId);
        ShipmentEntity GetByShipmentIdAndBoxId(string shipmentId, int boxId);
        IEnumerable<ShipmentEntity> GetByDate(string shipmentId);
        IEnumerable<ShipmentEntity> GetByBoxId(int boxId);
        IEnumerable<ShipmentEntity> GetByBoxIdAndEmployeeId(int boxId, int employeeId);
        bool Exists(string shipmentId);
        void Delete(int shipmentId);
        void Delete(string shipmentId);
        void DeleteByEmployeeId(int employeeId);
    }
}
