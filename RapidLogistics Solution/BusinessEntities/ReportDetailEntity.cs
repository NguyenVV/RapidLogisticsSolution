using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ReportDetailEntity
    {
        string shipmentId, masterId, boxId;
        int totalShipment;

        public string BoxId
        {
            get
            {
                return boxId;
            }

            set
            {
                boxId = value;
            }
        }

        public string MasterId
        {
            get
            {
                return masterId;
            }

            set
            {
                masterId = value;
            }
        }

        public string ShipmentId
        {
            get
            {
                return shipmentId;
            }

            set
            {
                shipmentId = value;
            }
        }

        public int TotalShipment
        {
            get
            {
                return totalShipment;
            }

            set
            {
                totalShipment = value;
            }
        }
    }
}
