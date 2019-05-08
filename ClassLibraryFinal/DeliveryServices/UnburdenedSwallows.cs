using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.DeliveryServices
{
    public class UnburdenedSwallows : DeliveryService
    {

        public UnburdenedSwallows(IShippingVehicle vehicle) : base(vehicle)
        {
            this.costPerRefuel = 50;
        }
    }
}
