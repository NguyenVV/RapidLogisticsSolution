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
        int employeeId, warehouseId;
        DateTime dateCreated;

        public int WarehouseId
        {
            get
            {
                return warehouseId;
            }

            set
            {
                warehouseId = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return employeeId;
            }

            set
            {
                employeeId = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }

            set
            {
                dateCreated = value;
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
