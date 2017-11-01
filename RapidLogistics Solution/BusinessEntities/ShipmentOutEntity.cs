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
        int dateint;
        string boxIdString;
        string masterBillIdString;
        int employeeId, warehouseId;
        double weight;
        DateTime dateCreated;

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
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
        public int DateInt
        {
            get
            {
                return dateint;
            }

            set
            {
                dateint = value;
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
        public string DeclarationNo { get; set; }
        public string DateOfCompletion { get; set; }
        public string Tel { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }

        public string Original { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }

    }
    public class ShipmentExport
    {
        public string ShipmentId { get; set; }
        public int BoxIdRef { get; set; }
        public string BoxIdString { get; set; }
        public int MasterBillId { get; set; }
        public string MasterBillIdString { get; set; }
        public DateTime DateOut { get; set; }
        public double Weight { get; set; }
        public string DeclarationNo { get; set; }
        public string DateOfCompletion { get; set; }
        public string Content { get; set; }
    }

    public class ReportParameter
    {
        public string MasterAirWayBill  { get; set; }
        public string BoxId { get; set; }
        public int NumberOfParcel { get; set; }
        public int TotalBox { get; set; }
        public double TotalWeight { get; set; }
    }
}
