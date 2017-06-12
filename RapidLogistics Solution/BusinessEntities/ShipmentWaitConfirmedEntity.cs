using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ShipmentWaitConfirmedEntity
    {
        string shipmentId;
        DateTime createdDate;

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

        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }

            set
            {
                createdDate = value;
            }
        }
    }
}
