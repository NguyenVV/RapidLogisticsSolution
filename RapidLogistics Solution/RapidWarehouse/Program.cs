using BusinessServices.Interfaces;
using System;
using System.Windows.Forms;
using SimpleInjector;
using BusinessServices;

namespace RapidWarehouse
{
    static class Program
    {
        private static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<FormNhap>());
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
            container.Register<FormNhap>();
            //container.Register<FormXuat>();

            // Optionally verify the container.
            //container.Verify();
        }
    }
}
