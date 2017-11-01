using BusinessEntities;
using System;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    public interface IBoxOutServices
    {
        int CreateBoxOut(BoxOutEntity boxOut);
        BoxOutEntity GetByBoxId(int boxId);
        BoxOutEntity GetByBoxCode(string boxId);
        IEnumerable<BoxOutEntity> GetAllBoxByMasterBill(int masterBillId);
        int CreateOrUpdateByQuery(int total, int id);
        void Delete(int id);
        BoxOutEntity GetByBoxCodeandAirWaybill(string boxId, int masterbillid);
    }
}
