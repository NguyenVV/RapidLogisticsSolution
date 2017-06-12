using System;

namespace BusinessEntities
{
    public class MasterAirwayBillEntity
    {
        int id;
        string masterAirwayBill;
        //DateTime dateCreated;
        DateTime dateArrived;

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

        public string MasterAirwayBill
        {
            get
            {
                return masterAirwayBill;
            }

            set
            {
                masterAirwayBill = value;
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

        public DateTime DateArrived
        {
            get
            {
                return dateArrived;
            }

            set
            {
                dateArrived = value;
            }
        }
    }
}
