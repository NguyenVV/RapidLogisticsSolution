using BusinessEntities;
using System;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    public interface IBoxInforServices
    {
        int CreateBoxInfor(BoxInforEntity boxInfor);
        IEnumerable<BoxInforEntity> GetByMasterBill(int masterBillId);
        IEnumerable<BoxInforEntity> GetByDateArrived(DateTime dateArrived);
        BoxInforEntity GetByBoxId(string boxId);
        BoxInforEntity GetByBoxId(int boxId);
        int GetTotalByMasterBill(int masterBillId);
        int GetTotalShipmentByMasterBill(int masterBillId);
        int GetTotalCountByMasterId(int masterId);
        string GetBoxIdStringById(int id);
        int CreateOrUpdateByQuery(int total, int id);
        void Delete(int id);
    }
}
