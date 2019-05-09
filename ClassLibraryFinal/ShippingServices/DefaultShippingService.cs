using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    /// <summary>
    /// Fake Shipping Service
    /// </summary>
    public class DefaultShippingService : IShippingService
    {

        public IShippingLocation ShippingLocation { get; protected set; }

        public uint ShippingDistance
        {
            get { return getShippingDistance(); }
        }

        protected uint getShippingDistance()
        {
            //terrible way to determine distance insn't real
            return (uint)Math.Abs(this.ShippingLocation.DestinationZipCode - this.ShippingLocation.StartZipCode);
        }
        public uint NumRefuels
        {
            get { return getNumRefuels(); }
        }

        private uint getNumRefuels()
        {
            return (uint)this.ShippingDistance / (uint)this.DeliveryService.ShippingVehicle.MaxDistancePerRefuel;
        }

        public IDeliveryService DeliveryService { get; set; }

        public List<IProduct> Products { get; set; }


        /// <summary>
        /// Used to caclulate the cost of shipping a list of products to a location using a delivery service
        /// </summary>
        /// <param name="Service"></param>
        /// <param name="Products"></param>
        /// <param name="Location"></param>
        public DefaultShippingService(IDeliveryService Service,  List<IProduct> Products, IShippingLocation Location)
        {
            DeliveryService = Service;
            this.Products = Products;
            ShippingLocation = Location;
            this.ShippingLocation.StartZipCode = 60605;
            this.ShippingLocation.DestinationZipCode = 60805;
        }

        public double ShippingCost(IShippingService shipService)
        {
            double shipCost = 0;
            shipCost = Math.Round(shipService.NumRefuels * this.DeliveryService.CostPerRefuel, 2);
            return shipCost;
        }
    }
}