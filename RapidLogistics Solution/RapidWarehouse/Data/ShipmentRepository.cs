using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BusinessEntities;
using System.Data;

namespace RapidWarehouse.Data
{
    class ShipmentRepository
    {
        #region Check ShipmentInfor exist
        public bool ShipmentExist(string shipmentno)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);
            string stringSQL = null;
            SqlCommand sqlCmd = null;
            try
            {
                stringSQL = "select count(*) from ShipmentInfor where ShipmentId='" + shipmentno + "';";
                sqlCmd = new SqlCommand(stringSQL, myConnection);
                myConnection.Open();
                int count = (int)sqlCmd.ExecuteScalar(); myConnection.Close();
                if (count == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Check ShipmentOut exist
        public bool ShipmentOutExist(string shipmentno)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);
            string stringSQL = null;
            SqlCommand sqlCmd = null;
            try
            {
                stringSQL = "select count(*) from ShipmentOut where ShipmentId='" + shipmentno + "';";
                sqlCmd = new SqlCommand(stringSQL, myConnection);
                myConnection.Open();
                int count = (int)sqlCmd.ExecuteScalar(); myConnection.Close();
                if (count == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Check Shipment exist
        public bool ShipmentExistByBoxId(int boxid)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);
            string stringSQL = null;
            SqlCommand sqlCmd = null;
            try
            {
                stringSQL = "select count(*) from ShipmentInfor where BoxId =" + boxid + ";";
                sqlCmd = new SqlCommand(stringSQL, myConnection);
                myConnection.Open();
                int count = (int)sqlCmd.ExecuteScalar(); myConnection.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Check BoxId exist
        public bool BoxIdExist(string boxid)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]);
            string stringSQL = null;
            SqlCommand sqlCmd = null;
            try
            {
                stringSQL = "select count(*) from Manifest where BoxId='" + boxid + "';";
                sqlCmd = new SqlCommand(stringSQL, myConnection);
                myConnection.Open();
                int count = (int)sqlCmd.ExecuteScalar(); myConnection.Close();
                if (count == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Get shipment
        public ShipmentEntity GetShipment(string ShipmentNo)
        {
            ShipmentEntity shipment = new ShipmentEntity();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from ShipmentInfor where ShipmentId='" + ShipmentNo + "';";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipment.Id = int.Parse(oReader["Id"].ToString());
                                shipment.ShipmentId = oReader["ShipmentId"].ToString();
                                shipment.DateCreated = DateTime.Parse(oReader["DateCreated"].ToString());
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
        #endregion

        #region Get Shipment OUT
        public ShipmentOutEntity GetShipmentOut(string ShipmentNo)
        {
            ShipmentOutEntity shipment = new ShipmentOutEntity();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from ShipmentOut where ShipmentId='" + ShipmentNo + "';";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipment.ShipmentId = oReader["ShipmentId"].ToString();
                                shipment.BoxIdRef = int.Parse(oReader["BoxIdRef"].ToString());
                                shipment.BoxIdString = oReader["BoxIdString"].ToString();
                                shipment.MasterBillId = int.Parse(oReader["MasterBillId"].ToString());
                                shipment.MasterBillIdString = oReader["MasterBillIdString"].ToString();
                                shipment.DateOut = DateTime.Parse(oReader["DateOut"].ToString());
                                shipment.DateCreated = DateTime.Parse(oReader["DateCreated"].ToString());
                                shipment.EmployeeId = int.Parse(oReader["EmployeeId"].ToString());
                                shipment.WarehouseId = int.Parse(oReader["WarehouseId"].ToString());
                                shipment.DeclarationNo = oReader["DeclarationNo"].ToString();
                                shipment.DateOfCompletion = oReader["DateOfCompletion"].ToString();
                                shipment.Weight = double.Parse(oReader["Weight"].ToString());
                                shipment.ContactName = oReader["ContactName"].ToString();
                                shipment.Tel = oReader["Tel"].ToString();
                                shipment.Address = oReader["Address"].ToString();
                                shipment.Content = oReader["Content"].ToString();
                                shipment.Quantity = int.Parse(oReader["Quantity"].ToString());
                                shipment.TotalValue = double.Parse(oReader["TotalValue"].ToString());
                                shipment.Original = oReader["Original"].ToString();
                                shipment.Destination = oReader["Destination"].ToString();
                                shipment.Country = oReader["Country"].ToString();
                                shipment.CompanyName = oReader["CompanyName"].ToString();
                                shipment.DateInt = int.Parse(oReader["DateInt"].ToString());
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
        #endregion

        #region Get ShipmentOut By Param
        public ShipmentOutEntity GetShipmentOutByParam(string shipment_id, string declaration_no, string contact_name, string sender)
        {
            ShipmentOutEntity shipment = new ShipmentOutEntity();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from ShipmentOut where ShipmentId='" + shipment_id + "' or DeclarationNo ='" + declaration_no + "' or ContactName ='" + contact_name + "' or CompanyName='" + sender + "'; ";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipment.ShipmentId = oReader["ShipmentId"].ToString();
                                shipment.BoxIdRef =int.Parse(oReader["BoxIdRef"].ToString());
                                shipment.BoxIdString = oReader["BoxIdString"].ToString();
                                shipment.MasterBillId = int.Parse(oReader["MasterBillId"].ToString());
                                shipment.MasterBillIdString = oReader["MasterBillIdString"].ToString();
                                shipment.DateCreated = DateTime.Parse(oReader["DateOut"].ToString());
                                shipment.EmployeeId = int.Parse(oReader["EmployeeId"].ToString());
                                shipment.WarehouseId = int.Parse(oReader["WarehouseId"].ToString());                                
                                shipment.DeclarationNo = oReader["DeclarationNo"].ToString();
                                shipment.DateOfCompletion = oReader["DateOfCompletion"].ToString();
                                shipment.Weight = double.Parse(oReader["Weight"].ToString());
                                shipment.ContactName = oReader["ContactName"].ToString();
                                shipment.Tel = oReader["Tel"].ToString();
                                shipment.Address = oReader["Address"].ToString();
                                shipment.Content = oReader["Content"].ToString();
                                shipment.Quantity = int.Parse(oReader["Quantity"].ToString());
                                shipment.TotalValue = double.Parse(oReader["TotalValue"].ToString());
                                shipment.Original = oReader["Original"].ToString();
                                shipment.Destination = oReader["Destination"].ToString();
                                shipment.Country = oReader["Country"].ToString();
                                shipment.CompanyName = oReader["CompanyName"].ToString();
                                shipment.DateInt = int.Parse(oReader["DateInt"].ToString());
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
        #endregion

        #region Get list shipment by boxid
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
                        string oString = "select * from ShipmentOut where BoxIdRef=" + boxid + " Order by Sequence DESC;";
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
                                shipmentout.Content = oReader["Content"].ToString();
                                if (string.IsNullOrEmpty(oReader["Weight"].ToString()))
                                    shipmentout.Weight = 0;
                                else
                                    shipmentout.Weight = double.Parse(oReader["Weight"].ToString());
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
        #endregion

        #region Get list manifest by Airwaybill
        public List<ManifestEntity> GetManifestByAirwaybill(string airwaybill)
        {
            ManifestEntity manifest = null;
            List<ManifestEntity> lstManifest = new List<ManifestEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from Manifest where MasterAirWayBill='" + airwaybill.Trim().ToUpper() + "'";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                manifest = new ManifestEntity();
                                manifest.MasterAirWayBill = oReader["MasterAirWayBill"].ToString();
                                manifest.ShipmentNo = oReader["ShipmentNo"].ToString();
                                manifest.FlightNumber = oReader["FlightNumber"].ToString();
                                manifest.FlightDate = oReader["FlightDate"].ToString();
                                manifest.BoxID = oReader["BoxID"].ToString();
                                manifest.HsCode = oReader["HSCode"].ToString();
                                manifest.ContactName = oReader["ContactName"].ToString();
                                manifest.Tel = oReader["Tel"].ToString();
                                manifest.Address = oReader["Address"].ToString();
                                manifest.Content = oReader["Content"].ToString();
                                manifest.Original = oReader["Original"].ToString();
                                manifest.Currency = oReader["Currency"].ToString();
                                manifest.Destination = oReader["Destination"].ToString();
                                manifest.CompanyName = oReader["CompanyName"].ToString();
                                manifest.Country = oReader["Country"].ToString();
                                manifest.CreationDate = DateTime.Parse(oReader["CreationDate"].ToString());
                                manifest.Quantity = int.Parse(oReader["Quantity"].ToString());
                                manifest.UnitPrice = float.Parse(oReader["UnitPrice"].ToString());
                                manifest.TotalValue = float.Parse(oReader["TotalValue"].ToString());
                                lstManifest.Add(manifest);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstManifest;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Get list manifest by BoxId
        public List<ManifestEntity> GetManifestByBoxId(string boxid)
        {
            ManifestEntity manifest = null;
            List<ManifestEntity> lstManifest = new List<ManifestEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from Manifest where BoxId='" + boxid.Trim().ToUpper() + "'";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                manifest = new ManifestEntity();
                                manifest.MasterAirWayBill = oReader["MasterAirWayBill"].ToString();
                                manifest.ShipmentNo = oReader["ShipmentNo"].ToString();
                                manifest.FlightNumber = oReader["FlightNumber"].ToString();
                                manifest.FlightDate = oReader["FlightDate"].ToString();
                                manifest.BoxID = oReader["BoxID"].ToString();
                                manifest.HsCode = oReader["HSCode"].ToString();
                                manifest.ContactName = oReader["ContactName"].ToString();
                                manifest.Tel = oReader["Tel"].ToString();
                                manifest.Address = oReader["Address"].ToString();
                                manifest.Content = oReader["Content"].ToString();
                                manifest.Original = oReader["Original"].ToString();
                                manifest.Currency = oReader["Currency"].ToString();
                                manifest.Destination = oReader["Destination"].ToString();
                                manifest.CompanyName = oReader["CompanyName"].ToString();
                                manifest.Country = oReader["Country"].ToString();
                                manifest.CreationDate = DateTime.Parse(oReader["CreationDate"].ToString());
                                manifest.Quantity = int.Parse(oReader["Quantity"].ToString());
                                manifest.Weight = double.Parse(oReader["Weight"].ToString());
                                manifest.UnitPrice = float.Parse(oReader["UnitPrice"].ToString());
                                manifest.TotalValue = float.Parse(oReader["TotalValue"].ToString());
                                lstManifest.Add(manifest);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstManifest;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Get list manifest by ShipmentNo
        public ManifestEntity GetManifestByShipmentNo(string shipmentno)
        {
            ManifestEntity manifest = null;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select top 1 * from Manifest where ShipmentNo ='" + shipmentno.Trim().ToUpper() + "' Order By Id Desc";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                manifest = new ManifestEntity();
                                manifest.MasterAirWayBill = oReader["MasterAirWayBill"].ToString();
                                manifest.ShipmentNo = oReader["ShipmentNo"].ToString();
                                manifest.FlightNumber = oReader["FlightNumber"].ToString();
                                manifest.FlightDate = oReader["FlightDate"].ToString();
                                manifest.BoxID = oReader["BoxID"].ToString();
                                manifest.HsCode = oReader["HSCode"].ToString();
                                manifest.ContactName = oReader["ContactName"].ToString();
                                manifest.Tel = oReader["Tel"].ToString();
                                manifest.Address = oReader["Address"].ToString();
                                manifest.Content = oReader["Content"].ToString();
                                manifest.Original = oReader["Original"].ToString();
                                manifest.Currency = oReader["Currency"].ToString();
                                manifest.Destination = oReader["Destination"].ToString();
                                manifest.CompanyName = oReader["CompanyName"].ToString();
                                manifest.Country = oReader["Country"].ToString();
                                manifest.CreationDate = DateTime.Parse(oReader["CreationDate"].ToString());
                                manifest.Quantity = int.Parse(oReader["Quantity"].ToString());
                                manifest.UnitPrice = float.Parse(oReader["UnitPrice"].ToString());
                                manifest.TotalValue = float.Parse(oReader["TotalValue"].ToString());
                                manifest.Weight = double.Parse(oReader["Weight"].ToString());
                            }
                            myConnection.Close();
                        }
                    }
                }
                return manifest;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Get list Boxid by Airwaybill from Manifest
        public List<BoxIdEntity> GetBoxIdByAirwaybill(string airwaybill)
        {
            BoxIdEntity boxid = null;
            List<BoxIdEntity> lstBoxid = new List<BoxIdEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select BoxId from Manifest where MasterAirWayBill='" + airwaybill.Trim().ToUpper() + "' Group by BoxId";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                boxid = new BoxIdEntity();
                                boxid.BoxId = oReader["boxid"].ToString();
                                lstBoxid.Add(boxid);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstBoxid;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Get list Boxid by Airwaybill from Manifest
        public List<BoxOutEntity> GetBoxIdByMasterBillid(int MasterBillid)
        {
            BoxOutEntity box = null;
            List<BoxOutEntity> lstBox = new List<BoxOutEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select Id, BoxId from BoxOut where MasterBillid =" + MasterBillid + " Order by DateCreated Desc;";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                box = new BoxOutEntity();
                                box.Id = int.Parse(oReader["Id"].ToString());
                                box.BoxId = oReader["BoxId"].ToString();
                                lstBox.Add(box);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstBox;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Get list Airwaybill by Date
        public List<MasterAirwayBillEntity> GetAirwaybillByDate(int dateint)
        {
            MasterAirwayBillEntity airwaybill = null;
            List<MasterAirwayBillEntity> lstShipmentOut = new List<MasterAirwayBillEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from MasterBill where DateInt = " + dateint + ";";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                airwaybill = new MasterAirwayBillEntity();
                                airwaybill.MasterAirwayBill = oReader["MasterAirwayBill"].ToString();
                                airwaybill.Id = int.Parse(oReader["Id"].ToString());
                                airwaybill.DateArrived = DateTime.Parse(oReader["DateArrived"].ToString());
                                airwaybill.DateInt = int.Parse(oReader["DateInt"].ToString());
                                airwaybill.EmployeeId = int.Parse(oReader["EmployeeId"].ToString());
                                airwaybill.DateCreated = DateTime.Parse(oReader["DateCreated"].ToString());
                                lstShipmentOut.Add(airwaybill);
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
        #endregion

        #region Get list Airwaybill
        public List<MasterAirwayBillEntity> GetAllAirwaybill()
        {
            MasterAirwayBillEntity airwaybill = null;
            List<MasterAirwayBillEntity> lstShipmentOut = new List<MasterAirwayBillEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "select * from MasterBill;";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                airwaybill = new MasterAirwayBillEntity();
                                airwaybill.MasterAirwayBill = oReader["MasterAirwayBill"].ToString();
                                airwaybill.Id = int.Parse(oReader["Id"].ToString());
                                airwaybill.DateArrived = DateTime.Parse(oReader["DateArrived"].ToString());
                                airwaybill.DateInt = int.Parse(oReader["DateInt"].ToString());
                                if (string.IsNullOrEmpty(oReader["EmployeeId"].ToString()))
                                    airwaybill.EmployeeId = 0;
                                else
                                    airwaybill.EmployeeId = int.Parse(oReader["EmployeeId"].ToString());
                                lstShipmentOut.Add(airwaybill);
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
        #endregion

        #region Convert date to int
        public int DateToInt(DateTime datetime)
        {
            try
            {
                string yyyy = datetime.Year.ToString();
                string mm = datetime.Month.ToString("00");
                string dd = datetime.Day.ToString("00");
                return Convert.ToInt32(yyyy + mm + dd);
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region CreateShipmentInfor
        public int CreateShipment(List<ShipmentEntity> lstShipment)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        SqlCommand myCommand = new SqlCommand("InsertShipmentInfor", connection, transaction);
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.Add(new SqlParameter("@ShipmentId", SqlDbType.VarChar, 100));
                        myCommand.Parameters.Add(new SqlParameter("@BoxId", SqlDbType.Int));
                        myCommand.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int));
                        myCommand.Parameters.Add(new SqlParameter("@WarehouseId", SqlDbType.Int));
                        myCommand.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Float));
                        myCommand.Parameters.Add(new SqlParameter("@Receiver", SqlDbType.NVarChar, 100));
                        myCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 100));
                        myCommand.Parameters.Add(new SqlParameter("@Consignee", SqlDbType.NVarChar, 100));
                        myCommand.Parameters.Add(new SqlParameter("@TelReceiver", SqlDbType.VarChar, 200));
                        myCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 1000));
                        myCommand.Parameters.Add(new SqlParameter("@Content", SqlDbType.NVarChar, 1000));
                        myCommand.Parameters.Add(new SqlParameter("@NumberPackage", SqlDbType.Int));
                        myCommand.Parameters.Add(new SqlParameter("@TotalValue", SqlDbType.Float));
                        myCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 100));
                        myCommand.Parameters.Add(new SqlParameter("@Sender", SqlDbType.NVarChar, 200));
                        myCommand.Parameters.Add(new SqlParameter("@ParamReturn", SqlDbType.Int));
                        foreach (ShipmentEntity shipment in lstShipment)
                        {
                            myCommand.Parameters["@ShipmentId"].Value = shipment.ShipmentId;
                            myCommand.Parameters["@BoxId"].Value = shipment.BoxId;   //// Boxid Int                      
                            myCommand.Parameters["@EmployeeId"].Value = shipment.EmployeeId;
                            myCommand.Parameters["@WarehouseId"].Value = shipment.WarehouseId;
                            myCommand.Parameters["@Weight"].Value = shipment.Weight;
                            myCommand.Parameters["@Receiver"].Value = (String.IsNullOrEmpty(shipment.Receiver)) ? "" : shipment.Receiver;
                            myCommand.Parameters["@Consignee"].Value = (String.IsNullOrEmpty(shipment.Consignee)) ? "" : shipment.Consignee;
                            myCommand.Parameters["@TelReceiver"].Value = (String.IsNullOrEmpty(shipment.ReceiverTel)) ? "" : shipment.ReceiverTel;
                            myCommand.Parameters["@Address"].Value = (String.IsNullOrEmpty(shipment.Address)) ? "" : shipment.Address;
                            myCommand.Parameters["@Content"].Value = (String.IsNullOrEmpty(shipment.Content)) ? "" : shipment.Content;
                            myCommand.Parameters["@Status"].Value = (String.IsNullOrEmpty(shipment.Status)) ? "" : shipment.Status;
                            myCommand.Parameters["@NumberPackage"].Value = shipment.NumberPackage;
                            myCommand.Parameters["@TotalValue"].Value = shipment.TotalValue;
                            myCommand.Parameters["@Country"].Value = shipment.Country;
                            myCommand.Parameters["@Sender"].Value = (String.IsNullOrEmpty(shipment.Sender)) ? "" : shipment.Sender;
                            myCommand.Parameters["@ParamReturn"].Direction = ParameterDirection.Output;
                            myCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        int _return = int.Parse(myCommand.Parameters["@ParamReturn"].Value.ToString());
                        if (_return > 0)
                        {
                            return lstShipment.Count;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }

            }

        }
        #endregion

        #region CreateShipmentOut
        public int CreateShipmentOut(ShipmentOutEntity shipment)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    SqlCommand myCommand = new SqlCommand("InsertShipmentOut", connection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add(new SqlParameter("@ShipmentId", SqlDbType.VarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@BoxIdRef", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@BoxIdString", SqlDbType.VarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@MasterBillIdString", SqlDbType.VarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@MasterBillId", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@DateOut", SqlDbType.DateTime));
                    myCommand.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@WarehouseId", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@IsSyncOms", SqlDbType.Bit));
                    myCommand.Parameters.Add(new SqlParameter("@DeclarationNo", SqlDbType.VarChar, 20));
                    myCommand.Parameters.Add(new SqlParameter("@DateOfCompletion", SqlDbType.VarChar, 20));
                    myCommand.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.NVarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@Tel", SqlDbType.VarChar, 200));
                    myCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 1000));
                    myCommand.Parameters.Add(new SqlParameter("@Content", SqlDbType.NVarChar, 1000));
                    myCommand.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@TotalValue", SqlDbType.Float));
                    myCommand.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Float));
                    myCommand.Parameters.Add(new SqlParameter("@Original", SqlDbType.NVarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@Destination", SqlDbType.NVarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 100));
                    myCommand.Parameters.Add(new SqlParameter("@DateInt", SqlDbType.Int));
                    myCommand.Parameters.Add(new SqlParameter("@ParamReturn", SqlDbType.Int));

                    myCommand.Parameters["@ShipmentId"].Value = shipment.ShipmentId;
                    myCommand.Parameters["@BoxIdRef"].Value = shipment.BoxIdRef;   //// Boxid Int                      
                    myCommand.Parameters["@BoxIdString"].Value = shipment.BoxIdString;
                    myCommand.Parameters["@MasterBillIdString"].Value = shipment.MasterBillIdString;
                    myCommand.Parameters["@MasterBillId"].Value = shipment.MasterBillId;
                    myCommand.Parameters["@DateOut"].Value = shipment.DateOut;
                    myCommand.Parameters["@EmployeeId"].Value = shipment.EmployeeId;
                    myCommand.Parameters["@WarehouseId"].Value = shipment.WarehouseId;
                    myCommand.Parameters["@IsSyncOms"].Value = 0;
                    myCommand.Parameters["@DeclarationNo"].Value = (String.IsNullOrEmpty(shipment.DeclarationNo)) ? "" : shipment.DeclarationNo; ;
                    myCommand.Parameters["@DateOfCompletion"].Value = (String.IsNullOrEmpty(shipment.DateOfCompletion)) ? "" : shipment.DateOfCompletion; ;
                    myCommand.Parameters["@Destination"].Value = (String.IsNullOrEmpty(shipment.Destination)) ? "" : shipment.Destination;
                    myCommand.Parameters["@Tel"].Value = (String.IsNullOrEmpty(shipment.Tel)) ? "" : shipment.Tel;
                    myCommand.Parameters["@ContactName"].Value = (String.IsNullOrEmpty(shipment.ContactName)) ? "" : shipment.ContactName;
                    myCommand.Parameters["@Address"].Value = (String.IsNullOrEmpty(shipment.Address)) ? "" : shipment.Address;
                    myCommand.Parameters["@Content"].Value = (String.IsNullOrEmpty(shipment.Content)) ? "" : shipment.Content;
                    myCommand.Parameters["@Quantity"].Value = shipment.Quantity;
                    myCommand.Parameters["@TotalValue"].Value = shipment.TotalValue;
                    myCommand.Parameters["@Weight"].Value = shipment.Weight;
                    myCommand.Parameters["@Original"].Value = (String.IsNullOrEmpty(shipment.Original)) ? "" : shipment.Original;
                    myCommand.Parameters["@Destination"].Value = (String.IsNullOrEmpty(shipment.Destination)) ? "" : shipment.Destination;
                    myCommand.Parameters["@CompanyName"].Value = (String.IsNullOrEmpty(shipment.CompanyName)) ? "" : shipment.CompanyName;
                    myCommand.Parameters["@Country"].Value = (String.IsNullOrEmpty(shipment.Country)) ? "" : shipment.Country; ;
                    myCommand.Parameters["@DateInt"].Value = shipment.DateInt;
                    myCommand.Parameters["@ParamReturn"].Direction = ParameterDirection.Output;
                    myCommand.ExecuteNonQuery();
                    int _return = int.Parse(myCommand.Parameters["@ParamReturn"].Value.ToString());
                    if (_return > 0)
                    {
                        return _return;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }

        }
        #endregion

        #region Reports
        #region Report Group By AirwaybillId
        public List<ReportParameter> ReportGroupByAirwaybillId(DateTime fromdate, DateTime todate, int Airwaybillid = 0)
        {
            string airwaybill_string = "";
            int fromdateint = 0;
            int todateint = 0;        
            if (fromdate != null)
                fromdateint = DateToInt(fromdate);
            if (todate != null)
                todateint = DateToInt(todate);
            if (Airwaybillid != 0)
                airwaybill_string = "and a.MasterBillId = " + Airwaybillid;
            ReportParameter shipment_report = null;
            List<ReportParameter> lstShipmentReport = new List<ReportParameter>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "Select a.MasterBillIdString, COUNT(Distinct a.BoxIdRef) as TotalBox, COUNT(a.ShipmentId) as NumberOfParcel, SUM(a.Weight) as TotalWeight from ShipmentOut a where a.dateint >= " + fromdateint + " and a.dateint <= " + todateint + airwaybill_string + "   group by a.MasterBillIdString";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipment_report = new ReportParameter();
                                shipment_report.MasterAirWayBill = oReader["MasterBillIdString"].ToString();
                                shipment_report.TotalBox = int.Parse(oReader["TotalBox"].ToString());
                                shipment_report.NumberOfParcel = int.Parse(oReader["NumberOfParcel"].ToString());
                                shipment_report.TotalWeight = double.Parse(oReader["TotalWeight"].ToString());
                                lstShipmentReport.Add(shipment_report);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstShipmentReport;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Report Group By BoxId
        public List<ReportParameter> ReportGroupByBoxId(DateTime fromdate, DateTime todate, int Airwaybillid =0, int Boxid =0)
        {
            string airwaybill_string = ""; string boxid_string = "";
            int fromdateint = 0;
            int todateint = 0;      
            if (fromdate != null)
                fromdateint = DateToInt(fromdate);
            if (todate != null)
                todateint = DateToInt(todate);
            if (Airwaybillid != 0)
                airwaybill_string = " and a.MasterBillId = " + Airwaybillid;
            if (Boxid != 0)
                boxid_string = " and a.BoxIdRef = " + Boxid;

            ReportParameter shipment_report = null;
            List<ReportParameter> lstShipmentReport = new List<ReportParameter>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        // string oString = "Select a.BoxIdString, a.MasterBillIdString, COUNT(a.ShipmentId) as NumberOfParcel, Sum(a.Weight) as Weight from ShipmentOut a where a.MasterBillId = " + Airwaybillid + " and a.dateint = " + dateint + " group by a.BoxIdString, a.MasterBillIdString ";
                        string oString = "Select a.BoxIdString, a.MasterBillIdString, COUNT(a.ShipmentId) as NumberOfParcel, Sum(a.Weight) as TotalWeight from ShipmentOut a where a.Dateint >= "+ fromdateint +" and Dateint <= "+ todateint + airwaybill_string + boxid_string + " group by a.BoxIdString, a.MasterBillIdString ";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while(oReader.Read())
                            {
                                shipment_report = new ReportParameter();
                                shipment_report.BoxId = oReader["BoxIdString"].ToString();
                                shipment_report.MasterAirWayBill = oReader["MasterBillIdString"].ToString();
                                shipment_report.NumberOfParcel = int.Parse(oReader["NumberOfParcel"].ToString());
                                shipment_report.TotalWeight = double.Parse(oReader["TotalWeight"].ToString());
                                lstShipmentReport.Add(shipment_report);
                            }
                            myConnection.Close();
                        }
                    }
                }
                return lstShipmentReport;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion        

        #region Report List Shipments by BoxId
        public List<ShipmentOutEntity> ReportShipmentsByBoxId(DateTime fromdate, DateTime todate, int Airwaybillid = 0, int Boxid =0)
        {
            string airwaybill_string = ""; string boxid_string = "";
            int fromdateint = 0;
            int todateint = 0;      
            if (fromdate != null)
                fromdateint = DateToInt(fromdate);
            if (todate != null)
                todateint = DateToInt(todate);
            if (Airwaybillid!=0)            
                airwaybill_string = " and a.MasterBillId = " + Airwaybillid;
            if (Boxid != 0)
                boxid_string = " and a.BoxIdRef = " + Boxid;
            ShipmentOutEntity shipmentOut = null;
            List<ShipmentOutEntity> lstShipmentOut = new List<ShipmentOutEntity>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["SqlConnectionString"]))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        string oString = "Select * from ShipmentOut a where a.dateint >= " + fromdateint + " and a.dateint <= " + todateint + airwaybill_string + boxid_string + " Order by Sequence DESC";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                shipmentOut = new ShipmentOutEntity();
                                shipmentOut.ShipmentId = oReader["ShipmentId"].ToString();
                                shipmentOut.BoxIdRef = int.Parse(oReader["BoxIdRef"].ToString());
                                shipmentOut.BoxIdString = oReader["BoxIdString"].ToString();
                                shipmentOut.MasterBillId = int.Parse(oReader["MasterBillId"].ToString());
                                shipmentOut.MasterBillIdString = oReader["MasterBillIdString"].ToString();
                                shipmentOut.DateCreated = DateTime.Parse(oReader["DateOut"].ToString());
                                shipmentOut.EmployeeId = int.Parse(oReader["EmployeeId"].ToString());
                                shipmentOut.WarehouseId = int.Parse(oReader["WarehouseId"].ToString());                                
                                shipmentOut.DeclarationNo = oReader["DeclarationNo"].ToString();
                                shipmentOut.DateOfCompletion = oReader["DateOfCompletion"].ToString();
                                shipmentOut.Weight = double.Parse(oReader["Weight"].ToString());
                                shipmentOut.ContactName = oReader["ContactName"].ToString();
                                shipmentOut.Tel = oReader["Tel"].ToString();
                                shipmentOut.Address = oReader["Address"].ToString();
                                shipmentOut.Content = oReader["Content"].ToString();
                                shipmentOut.Quantity = int.Parse(oReader["Quantity"].ToString());
                                shipmentOut.TotalValue = double.Parse(oReader["TotalValue"].ToString());
                                shipmentOut.Original = oReader["Original"].ToString();
                                shipmentOut.Destination = oReader["Destination"].ToString();
                                shipmentOut.Country = oReader["Country"].ToString();
                                shipmentOut.CompanyName = oReader["CompanyName"].ToString();
                                shipmentOut.DateInt = int.Parse(oReader["DateInt"].ToString());
                                lstShipmentOut.Add(shipmentOut);
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
        #endregion
        #endregion

    }
}
