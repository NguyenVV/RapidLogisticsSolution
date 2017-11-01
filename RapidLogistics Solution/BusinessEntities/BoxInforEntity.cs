using System;

namespace BusinessEntities
{
    public class BoxIdEntity
    {
        public string BoxId { get; set; }
    }    
        public class BoxInforEntity
    {
        int id;
        string boxId;
        DateTime dateCreated;
        int shipmentQuantity;
        int masterBillId;
        int employeeId;
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
        public int ShipmentQuantity
        {
            get
            {
                return shipmentQuantity;
            }

            set
            {
                shipmentQuantity = value;
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
    }

    
}
