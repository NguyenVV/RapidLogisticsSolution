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
}
