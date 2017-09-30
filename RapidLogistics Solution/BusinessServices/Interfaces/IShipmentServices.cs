using BusinessEntities;
using DataModel;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    public interface IShipmentServices
    {
        int CreateOrUpdate(ShipmentEntity shipmentEntity);
        int CreateOrUpdateByQuery(ShipmentEntity shipmentEntity);
        int CreateOrUpdate(IEnumerable<ShipmentEntity> shipmentList);
        int CreateOrUpdateByQuery(List<ShipmentEntity> shipmentList);
        ShipmentEntity GetByShipmentId(string shipmentId);
        string[] GetReferenceOfShipment(string shipmentId);
        ShipmentEntity GetByShipmentIdAndBoxId(string shipmentId, int boxId);
        IEnumerable<ShipmentEntity> GetByDate(string shipmentId);
        IEnumerable<ShipmentEntity> GetByMasterBillId(int masterBillId);
        IEnumerable<ShipmentEntity> GetByBoxId(int boxId);
        int GetTotalShipmentByMasterBill(int masterBillId);
        bool Exists(string shipmentId);
        void Delete(int shipmentId);
        void Delete(string shipmentId);
        ReportDetailEntity SearchByShipmentId(string shipmentId);
        ShipmentEntity SearchByConditions(string shipmentId, string sotk, string sender, string receiver);
        string GetDeclarationNo(string shipmentId);
        string GetDateOfCompletion(string shipmentId);
        bool IsExistByShipmentIdAndBoxId(string shipmentId, int boxId);
    }
}
