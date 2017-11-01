using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.Interfaces
{
    public interface IMasterBillServices
    {
        int CreateMasterAirwayBill(MasterAirwayBillEntity masterAirwayBillEntity);
        IEnumerable<MasterAirwayBillEntity> GetAll();
        MasterAirwayBillEntity GetByMasterBillId(string masterId);
        MasterAirwayBillEntity GetByMasterBillId(int masterId);
        IEnumerable<MasterAirwayBillEntity> SearchByMasterBillId(string masterId);
        IEnumerable<MasterAirwayBillEntity> GetByDateArrived(DateTime dateArrived);
        IEnumerable<MasterAirwayBillEntity> GetAllMasterBills();
        bool Exists(string text);
        IEnumerable<MasterAirwayBillEntity> GetByDateRange(DateTime start, DateTime end);
    }
}
