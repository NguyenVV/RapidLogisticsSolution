using System.ComponentModel.Composition;
using Resolver;
using BusinessServices.Interfaces;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            //registerComponent.RegisterType<IProductServices, ProductServices>();
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
            registerComponent.RegisterType<IManifestServices, ManifestServices>();
            registerComponent.RegisterType<IBusinessProfileServices, BusinessProfileServices>();
            registerComponent.RegisterType<IMasterBillServices, MasterBillServices>();
            registerComponent.RegisterType<IBoxInforServices, BoxInforServices>();
            registerComponent.RegisterType<IShipmentServices, ShipmentServices>();
            registerComponent.RegisterType<IShipmentOutServices, ShipmentOutServices>();
        }
    }
}
