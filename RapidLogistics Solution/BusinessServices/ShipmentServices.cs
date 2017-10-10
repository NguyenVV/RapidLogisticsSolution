using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;
using BusinessServices.Interfaces;
using System.Text;

namespace BusinessServices
{
    public class ShipmentServices : IShipmentServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ShipmentServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateOrUpdate(IEnumerable<ShipmentEntity> shipmentList)
        {
            if (shipmentList != null && shipmentList.Any())
            {
                using (var scope = new TransactionScope())
                {
                    Mapper.CreateMap<ShipmentEntity, ShipmentInfor>();
                    var shipmentListModel = Mapper.Map<IEnumerable<ShipmentEntity>, IEnumerable<ShipmentInfor>>(shipmentList).ToList();
                    int count = 0;
                    count = _unitOfWork.ShipmentRepository.Insert(shipmentListModel);
                    _unitOfWork.SaveWinform();
                    scope.Complete();

                    return count;
                }
            }

            return 0;
        }

        private static bool IsEquals(ShipmentInfor first, ShipmentInfor second)
        {
            if (first == null && second == null)
                return true;
            if (first == null || second == null)
                return false;
            if (String.Equals(first.Address, second.Address) && first.BoxId == second.BoxId && String.Equals(first.Consignee, second.Consignee) && String.Equals(first.Content, second.Content)
                && String.Equals(first.Country, second.Country) && String.Equals(first.DateOfCompletion, second.DateOfCompletion)
                && String.Equals(first.DeclarationNo, second.DeclarationNo) && String.Equals(first.Descrition, second.Descrition) && first.EmployeeId == second.EmployeeId
                && first.Id == second.Id && first.NumberPackage == second.NumberPackage && String.Equals(first.Receiver, second.Receiver) && String.Equals(first.Sender, second.Sender)
                && String.Equals(first.ShipmentId, second.ShipmentId) && String.Equals(first.Status, second.Status) && String.Equals(first.TelReceiver, second.TelReceiver) && first.TotalValue == second.TotalValue
                && first.WarehouseId == second.WarehouseId && first.Weight == second.Weight && first.IsSyncOms == second.IsSyncOms)
                return true;

            return false;
        }

        public int CreateOrUpdate(ShipmentEntity shipmentEntity)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<ShipmentEntity, ShipmentInfor>();
                var shipmentDataModel = Mapper.Map<ShipmentEntity, ShipmentInfor>(shipmentEntity);
                var original = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId == shipmentDataModel.ShipmentId);
                if (original != null)
                {
                    shipmentDataModel.Id = original.Id;
                    shipmentDataModel.DateCreated = original.DateCreated;
                    _unitOfWork.ShipmentRepository.Update(original, shipmentDataModel);
                }
                else
                {
                    _unitOfWork.ShipmentRepository.Insert(shipmentDataModel);
                }

                _unitOfWork.SaveWinform();
                scope.Complete();
                return shipmentDataModel.Id;
            }
        }
        public int CreateOrUpdateByQuery(ShipmentEntity shipmentEntity)
        {
            try
            {
                return _unitOfWork.ShipmentRepository.ExecuteUpdateQuery(string.Format("INSERT [dbo].[ShipmentInfor] ([ShipmentId], [Sender], [Receiver], [TelReceiver], [TotalValue], [Descrition], [BoxId], [Status], [EmployeeId], [WarehouseId], [IsSyncOms], [Weight], [DeclarationNo], [Country], [Address], [Consignee], [Content], [NumberPackage], [DateOfCompletion]) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', {6}, N'{7}', {8}, {9}, N'{10}', N'{11}', N'{12}', N'{13}',N'{14}', N'{15}', N'{16}', {17}, N'{18}')", shipmentEntity.ShipmentId, shipmentEntity.Sender, shipmentEntity.Receiver, shipmentEntity.ReceiverTel, null, shipmentEntity.Description, shipmentEntity.BoxId, null, shipmentEntity.EmployeeId, shipmentEntity.WarehouseId, null, shipmentEntity.Weight, shipmentEntity.DeclarationNo, shipmentEntity.Country, shipmentEntity.Address, shipmentEntity.Consignee, shipmentEntity.Content, shipmentEntity.NumberPackage, shipmentEntity.DateOfCompletion));
            }
            catch
            {
                return _unitOfWork.ShipmentRepository.ExecuteUpdateQuery(string.Format("Update [dbo].[ShipmentInfor] set [ShipmentId]=N'{0}', [Sender]=N'{1}', [Receiver]=N'{2}', [TelReceiver]=N'{3}', [TotalValue]={4}, [Descrition]=N'{5}', [BoxId]={6}, [Status]=N'{7}', [EmployeeId]={8}, [WarehouseId]={9}, [IsSyncOms]=N'{10}', [Weight]={11}, [DeclarationNo]=N'{12}', [Country]=N'{13}', [Address]=N'{14}', [Consignee]=N'{15}', [Content]=N'{16}', [NumberPackage]={17}, [DateOfCompletion]=N'{18}' where  Id = {19})", shipmentEntity.ShipmentId, shipmentEntity.Sender, shipmentEntity.Receiver, shipmentEntity.ReceiverTel, null, shipmentEntity.Description, shipmentEntity.BoxId, null, shipmentEntity.EmployeeId, shipmentEntity.WarehouseId, null, shipmentEntity.Weight, shipmentEntity.DeclarationNo, shipmentEntity.Country, shipmentEntity.Address, shipmentEntity.Consignee, shipmentEntity.Content, shipmentEntity.NumberPackage, shipmentEntity.DateOfCompletion, shipmentEntity.Id));
            }
        }

        public int CreateOrUpdateByQuery(List<ShipmentEntity> shipmentList)
        {
                StringBuilder data = new StringBuilder();
            try
            {
                foreach(ShipmentEntity shipmentEntity in shipmentList)
                {
                    data.Append(string.Format("INSERT [dbo].[ShipmentInfor] ([ShipmentId], [Sender], [Receiver], [TelReceiver], [TotalValue], [Descrition], [BoxId], [Status], [EmployeeId], [WarehouseId], [IsSyncOms], [Weight], [DeclarationNo], [Country], [Address], [Consignee], [Content], [NumberPackage], [DateOfCompletion]) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', {6}, N'{7}', {8}, {9}, N'{10}', {11}, N'{12}', N'{13}',N'{14}', N'{15}', N'{16}', {17}, N'{18}')", shipmentEntity.ShipmentId, shipmentEntity.Sender, shipmentEntity.Receiver, shipmentEntity.ReceiverTel, null, shipmentEntity.Description, shipmentEntity.BoxId, null, shipmentEntity.EmployeeId, shipmentEntity.WarehouseId, null, shipmentEntity.Weight, shipmentEntity.DeclarationNo, shipmentEntity.Country, shipmentEntity.Address, shipmentEntity.Consignee, shipmentEntity.Content, shipmentEntity.NumberPackage, shipmentEntity.DateOfCompletion));
                }
            }
            catch
            {
                foreach (ShipmentEntity shipmentEntity in shipmentList)
                {
                    data.Append(string.Format("Update [dbo].[ShipmentInfor] set [ShipmentId]=N'{0}', [Sender]=N'{1}', [Receiver]=N'{2}', [TelReceiver]=N'{3}', [TotalValue]={4}, [Descrition]=N'{5}', [BoxId]={6}, [Status]=N'{7}', [EmployeeId]={8}, [WarehouseId]={9}, [IsSyncOms]=N'{10}', [Weight]={11}, [DeclarationNo]=N'{12}', [Country]=N'{13}', [Address]=N'{14}', [Consignee]=N'{15}', [Content]=N'{16}', [NumberPackage]={17}, [DateOfCompletion]=N'{18}' where  Id = {19})", shipmentEntity.ShipmentId, shipmentEntity.Sender, shipmentEntity.Receiver, shipmentEntity.ReceiverTel, null, shipmentEntity.Description, shipmentEntity.BoxId, null, shipmentEntity.EmployeeId, shipmentEntity.WarehouseId, null, shipmentEntity.Weight, shipmentEntity.DeclarationNo, shipmentEntity.Country, shipmentEntity.Address, shipmentEntity.Consignee, shipmentEntity.Content, shipmentEntity.NumberPackage, shipmentEntity.DateOfCompletion, shipmentEntity.Id));
                }
            }

            return _unitOfWork.ShipmentRepository.ExecuteUpdateQuery(data.ToString());
        }
        public IEnumerable<ShipmentEntity> GetByMasterBillId(int masterBillId)
        {
            var shipmentList = _unitOfWork.ShipmentRepository.GetMany(t => t.BoxInfo.MasterBillId == masterBillId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<IEnumerable<ShipmentInfor>, IEnumerable<ShipmentEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentEntity> GetByBoxId(int boxId)
        {
            var shipmentList = _unitOfWork.ShipmentRepository.GetMany(t => t.BoxId == boxId);
            if (shipmentList != null && shipmentList.Any())
            {
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentListModel = Mapper.Map<IEnumerable<ShipmentInfor>, IEnumerable<ShipmentEntity>>(shipmentList.ToList());
                return shipmentListModel;
            }
            return null;
        }
        public IEnumerable<ShipmentEntity> GetByDate(string shipmentId)
        {
            throw new NotImplementedException();
        }
        public ShipmentEntity GetByShipmentId(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                ShipmentInfor shipmentDataModel = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
                if (shipmentDataModel == null)
                {
                    scope.Complete();
                    return null;
                }
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentData = Mapper.Map<ShipmentInfor, ShipmentEntity>(shipmentDataModel);
                shipmentData.Mawb = shipmentDataModel.BoxInfo.MasterBill.MasterAirWayBill;
                shipmentData.BoxIdString = shipmentDataModel.BoxInfo.BoxId;
                scope.Complete();
                return shipmentData;
            }
        }
        public int GetTotalShipmentByMasterBill(int masterBillId)
        {
            int total = 0;
            var list = _unitOfWork.ShipmentRepository.GetMany(t => t.BoxInfo != null && t.BoxInfo.MasterBillId == masterBillId);
            if (list != null && list.Any())
            {
                total = list.Count();
            }

            return total;
        }
        public string GetDeclarationNo(string shipmentId)
        {
            string query = @"SELECT TOP 30
            a.[Msgxml].value('(/Root/ShipmentID)[1]', 'VARCHAR(MAX)') AS 'ShipmentNo',
            a.[Msgxml].value('(/Root/Declaration/DeclarationNo)[1]', 'VARCHAR(MAX)') AS 'SOTK'
            FROM    (SELECT CAST(Msgxml AS XML) AS xmlMsgxml FROM CPN_OutputMSG where ShipmentID='" + shipmentId + @"') s
            CROSS APPLY xmlMsgxml.nodes('/') a ( Msgxml )";
            var list = _unitOfWork.ShipmentRepository.ExecuteSelectQueryFromECUS5VNACCS(query);

            if (list != null && list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in list.Rows)
                {
                    string result = Convert.ToString(row["SOTK"]);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public string GetDateOfCompletion(string shipmentId)
        {
            string query = @"SELECT TOP 30
            a.[Msgxml].value('(/Root/Declaration/DateOfCompletion)[1]', 'VARCHAR(MAX)') AS 'DateOfCompletion',
            a.[Msgxml].value('(/Root/Declaration/TimeCompletion)[1]', 'VARCHAR(MAX)') AS 'TimeCompletion'
            FROM    (SELECT CAST(Msgxml AS XML) AS xmlMsgxml FROM CPN_OutputMSG where ShipmentID='" + shipmentId + @"') s
            CROSS APPLY xmlMsgxml.nodes('/') a ( Msgxml )";
            var list = _unitOfWork.ShipmentRepository.ExecuteSelectQueryFromECUS5VNACCS(query);

            if (list != null && list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in list.Rows)
                {
                    string resultDate = Convert.ToString(row["DateOfCompletion"]);

                    if (!string.IsNullOrEmpty(resultDate))
                    {
                        string fromTimeString = "";
                        if (row["TimeCompletion"] != null)
                        {
                            int resultTime = Convert.ToInt32(row["TimeCompletion"]);
                            TimeSpan result = TimeSpan.FromHours(resultTime);
                            fromTimeString = result.ToString("hh':'mm");
                        }
                        return resultDate + " " + fromTimeString;
                    }
                }
            }

            return null;
        }
        public ShipmentEntity SearchByConditions(string shipmentId, string sotk, string sender, string receiver)
        {
            if (string.IsNullOrEmpty(shipmentId) && string.IsNullOrEmpty(sotk) && string.IsNullOrEmpty(sender) && string.IsNullOrEmpty(receiver))
                return null;

            using (var scope = new TransactionScope())
            {
                var result = _unitOfWork.ShipmentRepository.GetAll();

                if (!string.IsNullOrEmpty(shipmentId))
                {
                    result = result.Where(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
                }
                if (!string.IsNullOrEmpty(sotk))
                {
                    result = result.Where(t => sotk.Equals(t.DeclarationNo, StringComparison.CurrentCultureIgnoreCase));
                }
                if (!string.IsNullOrEmpty(sender))
                {
                    result = result.Where(t => sender.Equals(t.Sender, StringComparison.CurrentCultureIgnoreCase));
                }
                if (!string.IsNullOrEmpty(receiver))
                {
                    result = result.Where(t => receiver.Equals(t.Receiver, StringComparison.CurrentCultureIgnoreCase));
                }

                var shipmentDataModel = result == null ? null : result.First();

                if (shipmentDataModel == null)
                {
                    scope.Complete();
                    return null;
                }

                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentData = Mapper.Map<ShipmentInfor, ShipmentEntity>(shipmentDataModel);
                shipmentData.Mawb = shipmentDataModel.BoxInfo.MasterBill.MasterAirWayBill;
                shipmentData.BoxIdString = shipmentDataModel.BoxInfo.BoxId;
                scope.Complete();
                return shipmentData;
            }
        }

        public string[] GetReferenceOfShipment(string shipmentId)
        {
            using (var scope = new TransactionScope())
            {
                string[] arr = new string[6];
                ShipmentInfor shipmentDataModel = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));

                if (shipmentDataModel != null)
                {
                    arr[0] = shipmentDataModel.Id.ToString();
                    arr[1] = shipmentDataModel.ShipmentId;
                    arr[2] = shipmentDataModel.BoxInfo.Id.ToString();
                    arr[3] = shipmentDataModel.BoxInfo.BoxId;
                    arr[4] = shipmentDataModel.BoxInfo.MasterBill.Id.ToString();
                    arr[5] = shipmentDataModel.BoxInfo.MasterBill.MasterAirWayBill;
                    scope.Complete();

                    return arr;
                }

                scope.Complete();
                return null;
            }
        }
        public bool Exists(string shipmentId)
        {
            return _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId == shipmentId) == null ? false : true;
        }
        public void Delete(int shipmentId)
        {
            _unitOfWork.ShipmentRepository.Delete(shipmentId);
            _unitOfWork.SaveWinform();
        }
        public ShipmentEntity GetByShipmentIdAndBoxId(string shipmentId, int boxId)
        {
            using (var scope = new TransactionScope())
            {
                // ShipmentInfor shipmentDataModel = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase) && t.BoxId == boxId);
                ShipmentInfor shipmentDataModel = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
                if (shipmentDataModel == null)
                {
                    scope.Complete();
                    return null;
                }
                Mapper.CreateMap<ShipmentInfor, ShipmentEntity>();
                var shipmentData = Mapper.Map<ShipmentInfor, ShipmentEntity>(shipmentDataModel);
                scope.Complete();
                return shipmentData;
            }
        }
        public bool IsExistByShipmentIdAndBoxId(string shipmentId, int boxId)
        {
            using (var scope = new TransactionScope())
            {
                bool shipmentDataModel = _unitOfWork.ShipmentRepository.Exists(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase) && t.BoxId == boxId);
                
                scope.Complete();
                return shipmentDataModel;
            }
        }
        public ReportDetailEntity SearchByShipmentId(string shipmentId)
        {
            ReportDetailEntity reportEntity = new ReportDetailEntity();
            var result = _unitOfWork.ShipmentRepository.Get(t => t.ShipmentId.Equals(shipmentId, StringComparison.CurrentCultureIgnoreCase));
            if (result != null)
            {
                reportEntity.ShipmentId = result.ShipmentId;

                if (result.BoxInfo != null)
                {
                    reportEntity.BoxId = result.BoxInfo.BoxId;
                }
                else
                {
                    reportEntity.BoxId = string.Empty;
                }

                return reportEntity;
            }
            return null;
        }
        public void Delete(string shipmentId)
        {
            _unitOfWork.ShipmentRepository.Delete(t => t.ShipmentId == shipmentId);
            _unitOfWork.SaveWinform();
        }
    }
}
