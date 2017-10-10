using BusinessServices.Interfaces;
using System;
using System.Windows.Forms;
using SimpleInjector;
using BusinessServices;
using Jacksonsoft;

namespace RapidWarehouse
{
    static class Program
    {
        private static Container container;

        public static Container Container
        {
            get
            {
                return container;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Bootstrap();
                Application.Run(container.GetInstance<FormLogin>());
                //Application.Run(container.GetInstance<FormNhap>());
            }
            catch (Exception ex)
            {
                Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "static void Main()", ex);
                if (!(ex.Message.Contains("Cannot access a disposed object.") && ex.Message.Contains("FormLogin")))
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi xử lý chương trình !\nChúng tôi đã ghi nhận\nVui lòng thử lại sau!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            // Register your types, for instance:
            //container.Register<IGenericRepository, DataModel.GenericRepository.GenericRepository>(Lifestyle.Singleton);
            container.Register<IMasterBillServices, MasterBillServices>();
            container.Register<IBoxInforServices, BoxInforServices>();
            container.Register<IShipmentServices, ShipmentServices>();
            container.Register<IShipmentOutServices, ShipmentOutServices>();
            container.Register<IManifestServices, ManifestServices>();
            container.Register<IShipmentWaitToConfirmedServices, ShipmentWaitToConfirmedServices>();
            container.Register<IEmployeeServices, EmployeeServices>();
            container.Register<IShipmentTempServices, ShipmentTempServices>();
            container.Register<IShipmentOutTempServices, ShipmentOutTempServices>();
            container.Register<IWarehouseServices, WarehouseServices>();
            container.Register<FormLogin>();
            container.Register<FormNhap>();
            container.Register<FormHome>();
            container.Register<FormCreateEditEmployee>();
            container.Register<FormChangePassword>();
            container.Register<FormConfigDB>();
            container.Register<FormXuat>();
            container.Register<FormChoThongQuan>();
            container.Register<FormBaoCao>();
            container.Register<FormMangeWarehouses>();
            container.Register<FormHaiQuanView>();
            container.Register<FormXnDenMawb>();
            container.Register<WaitWindowGUI>();

            // Optionally verify the container.
            //container.Verify();
        }
    }
}
