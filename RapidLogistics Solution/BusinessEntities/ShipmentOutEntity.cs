using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ShipmentOutEntity
    {
        string shipmentId;
        DateTime dateOut;
        int boxIdRef;
        int masterBillId;
        string boxIdString;
        string masterBillIdString;

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

        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }

            set
            {
                dateOut = value;
            }
        }

        public int BoxIdRef
        {
            get
            {
                return boxIdRef;
            }

            set
            {
                boxIdRef = value;
            }
        }

        public int MasterBillId
        {
            get
            {
                return masterBillId;
            }

            set
            {
                masterBillId = value;
            }
        }

        public string BoxIdString
        {
            get
            {
                return boxIdString;
            }

            set
            {
                boxIdString = value;
            }
        }

        public string MasterBillIdString
        {
            get
            {
                return masterBillIdString;
            }

            set
            {
                masterBillIdString = value;
            }
        }
    }
}
