using System;

namespace BusinessEntities
{
    public class BoxInforEntity
    {
        int id;
        string boxId;
        //DateTime dateCreated;
        int shipmentQuantity;
        int masterBillId;

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
