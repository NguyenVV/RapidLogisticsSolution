﻿using BusinessEntities;
using DataModel;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{
    public interface IShipmentServices
    {
        int Create(ShipmentEntity shipmentEntity);
        int Create(List<ShipmentEntity> shipmentList);
        ShipmentEntity GetByShipmentId(string shipmentId);
        string[] GetReferenceOfShipment(string shipmentId);
        ShipmentEntity GetByShipmentIdAndBoxId(string shipmentId, int boxId);
        IEnumerable<ShipmentEntity> GetByDate(string shipmentId);
        IEnumerable<ShipmentEntity> GetByBoxId(int boxId);
        bool Exists(string shipmentId);
        void Delete(int shipmentId);
        void Delete(string shipmentId);
        ReportDetailEntity SearchByShipmentId(string shipmentId);
        ShipmentEntity SearchByConditions(string shipmentId, string sotk, string sender, string receiver);
    }
}
