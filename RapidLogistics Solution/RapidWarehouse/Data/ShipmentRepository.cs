using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BusinessEntities;
namespace RapidWarehouse.Data
{
    class ShipmentRepository
    {
        public bool ShipmentExist(string shipmentno)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);
            string stringSQL = null;
            SqlCommand sqlCmd = null;
            try
            {
                stringSQL = "select count(*) from ShipmentOut where ShipmentId='" + shipmentno + "';";
                sqlCmd = new SqlCommand(stringSQL, myConnection);
                return (int)sqlCmd.ExecuteScalar() == 1;
            }
            catch
            { return false; }
        }
        public ShipmentEntity GetShipment(string ShipmentNo)
        {
            ShipmentEntity shipment = new ShipmentEntity();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from ShipmentInfo where ShipmentId='" + ShipmentNo + "';";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                //Id
                                //ShipmentId
                                //DateCreated
                                //Sender
                                //Receiver
                                //TelReceiver
                                //TotalValue
                                //Descrition
                                //BoxId
                                //Status
                                //EmployeeId
                                //WarehouseId
                                //IsSyncOms
                                //Weight
                                //DeclarationNo
                                //Country
                                //Address
                                //Consignee
                                //[Content]
                                //NumberPackage
                                //DateOfCompletion                      
                                shipment.Id = int.Parse(oReader["Id"].ToString());
                                shipment.ShipmentId = oReader["ShipmentId"].ToString();
                                shipment.DateCreated = DateTime.Parse(oReader["ShipmentId"].ToString());
                                shipment.Sender = oReader["Sender"].ToString();
                                shipment.Receiver = oReader["Receiver"].ToString();
                                shipment.ReceiverTel = oReader["TelReceiver"].ToString();
                                shipment.Description = oReader["Descrition"].ToString();
                                shipment.BoxId = int.Parse(oReader["BoxId"].ToString());
                                shipment.Weight = double.Parse(oReader["Weight"].ToString());
                                shipment.DeclarationNo = oReader["DeclarationNo"].ToString();
                                shipment.Consignee = oReader["Consignee"].ToString();
                                shipment.Address = oReader["Address"].ToString();
                                shipment.Content = oReader["Content"].ToString();
                            }
                            myConnection.Close();
                        }
                    }
                }
                return shipment;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<ShipmentExport> GetListShipmentByBoxId(int boxid)
        {
            ShipmentExport shipmentout = null;
            List<ShipmentExport> lstShipmentOut = new List<ShipmentExport>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from ShipmentOut where BoxIdRef=" + boxid + ";";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipmentout = new ShipmentExport();
                                shipmentout.ShipmentId = oReader["ShipmentId"].ToString();
                                shipmentout.BoxIdRef = int.Parse(oReader["BoxIdRef"].ToString());
                                shipmentout.BoxIdString = oReader["BoxIdString"].ToString();
                                shipmentout.MasterBillId = int.Parse(oReader["MasterBillId"].ToString());
                                shipmentout.MasterBillIdString = oReader["MasterBillIdString"].ToString();
                                shipmentout.DateOut = DateTime.Parse(oReader["DateOut"].ToString());
                                lstShipmentOut.Add(shipmentout);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstShipmentOut;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
