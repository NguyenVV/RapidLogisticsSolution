using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class ManifestEntity
    {
        private string masterAirWayBill,
            shipmentNo,
            flightNumber,
            flightDate,
            boxID,
            hsCode,
            contactName,
            tel,
            address,
            currency,
            content,
            original,
            destination,
            country,
            companyName;
        private int quantity;
        private double unitPrice, totalValue, weight;
        private DateTime creationDate;
    private string declarationNo;  
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
    public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        public double TotalValue
        {
            get
            {
                return totalValue;
            }

            set
            {
                totalValue = value;
            }
        }

        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                currency = value;
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

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }

            set
            {
                creationDate = value;
            }
        }
    
        public string HSCODE
        {
            get
            {
                return hsCode;
            }

            set
            {
                hsCode = value;
            }
        }
    
        public string BoxID
        {
            get
            {
                return boxID;
            }

            set
            {
                boxID = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

    public string MasterAirWayBill
    {
        get
        {
            return masterAirWayBill;
        }

        set
        {
            masterAirWayBill = value;
        }
    }

    public string ShipmentNo
    {
        get
        {
            return shipmentNo;
        }

        set
        {
            shipmentNo = value;
        }
    }

    public string FlightNumber
    {
        get
        {
            return flightNumber;
        }

        set
        {
            flightNumber = value;
        }
    }

    public string FlightDate
    {
        get
        {
            return flightDate;
        }

        set
        {
            flightDate = value;
        }
    }

    public string HsCode
    {
        get
        {
            return hsCode;
        }

        set
        {
            hsCode = value;
        }
    }

    public string ContactName
    {
        get
        {
            return contactName;
        }

        set
        {
            contactName = value;
        }
    }

    public string Tel
    {
        get
        {
            return tel;
        }

        set
        {
            tel = value;
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
   
    public string Original
    {
        get
        {
            return original;
        }

        set
        {
            original = value;
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

    public string CompanyName
    {
        get
        {
            return companyName;
        }

        set
        {
            companyName = value;
        }
    }

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
}
