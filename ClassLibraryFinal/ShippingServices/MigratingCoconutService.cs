using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.ShippingServices
{
    class MigratingCoconutService : DefaultShippingService
    {
        public MigratingCoconutService(IDeliveryService Service, List<IProduct> Products, IShippingLocation Location) : base(Service,Products, Location)
        {
            this.ShippingLocation.StartZipCode = 6500;
        }
    }
}
