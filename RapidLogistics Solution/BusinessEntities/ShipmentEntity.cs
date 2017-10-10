using System;

namespace BusinessEntities
{
    public class ShipmentEntity
    {
        int id;
        string shipmentId;
        string sender;
        string receiver;
        string receiverTel;
        //float totalValue;
        string description;
        int boxId;
        DateTime dateCreated;
        int employeeId, warehouseId;
        string content,
            destination,
            address,
            country;
        int numberPackage;
        private string declarationNo;
        private string mawb;
        private string boxIdString;
        private DateTime? dateOfCompletion;
        private string consignee;
        public string DeclarationNo
        {
            get
            {
                return declarationNo;
            }

            set
            {
                declarationNo = value;
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
        public double? Weight { get; set; }

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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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

        public string Sender
        {
            get
            {
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        public string Receiver
        {
            get
            {
                return receiver;
            }

            set
            {
                receiver = value;
            }
        }

        public string ReceiverTel
        {
            get
            {
                return receiverTel;
            }

            set
            {
                receiverTel = value;
            }
        }

        //public float TotalValue
        //{
        //    get
        //    {
        //        return totalValue;
        //    }

        //    set
        //    {
        //        totalValue = value;
        //    }
        //}

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int BoxId
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

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }

            set
            {
                destination = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public int NumberPackage
        {
            get
            {
                return numberPackage;
            }

            set
            {
                numberPackage = value;
            }
        }

        public string Mawb
        {
            get
            {
                return mawb;
            }

            set
            {
                mawb = value;
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

        public DateTime? DateOfCompletion
        {
            get
            {
                return dateOfCompletion;
            }

            set
            {
                dateOfCompletion = value;
            }
        }

        public string Consignee
        {
            get
            {
                return consignee;
            }

            set
            {
                consignee = value;
            }
        }

        //public DateTime DateCreated
        //{
        //    get
        //    {
        //        return dateCreated;
        //    }

        //    set
        //    {
        //        dateCreated = value;
        //    }
        //}
    }

    public class ShipmentExport
    {
        public string ShipmentId { get; set; }
        public int BoxIdRef { get; set; }
        public string BoxIdString { get; set; }
        public int MasterBillId { get; set; }
        public string MasterBillIdString { get; set; }
        public DateTime DateOut { get; set; }
    }
}
