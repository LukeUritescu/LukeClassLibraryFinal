using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryFinal;
using ClassLibraryFinal.ShippingServices;
using Moq;
using System.Collections.Generic;

namespace UnitTestFinal
{
    [TestClass]
    public class UnitTestDeliveryService
    {
        IShippingVehicle vehicle;
        IDeliveryService delivery;

        public UnitTestDeliveryService()
        {
            
        }

        /// <summary>
        /// Tests defaults for Class
        /// </summary>
        [TestMethod]
        public void DeliveryService_UnclesTruckDefaults()
        {
            //Arrange
            double costPerRefuel = 200;
            vehicle = new Truck();
            delivery = new UnclesTruck(vehicle);
            //Act

            //Assert
            Assert.IsNotNull(delivery);
            Assert.IsNotNull(delivery.ShippingVehicle);
            Assert.AreEqual(delivery.CostPerRefuel, costPerRefuel);
        }

        [TestMethod]
        public void DeliveryService_AirExpressDefaults()
        {
            //Arrange
            double costPerRefuel = 2000;
            vehicle = new Plane();
            delivery = new AirExpress(vehicle);
            //Act

            //Assert
            Assert.IsNotNull(delivery);
            Assert.IsNotNull(delivery.ShippingVehicle);
            Assert.AreEqual(delivery.CostPerRefuel, costPerRefuel);
        }

        [TestMethod]
        public void DeliveryService_SnailServiceDefaults()
        {
            //Arrange
            double costPerRefuel = 2;
            vehicle = new ShippingSnail();
            delivery = new SnailService(vehicle);
            //Act

            //Assert
            Assert.IsNotNull(delivery);
            Assert.IsNotNull(delivery.ShippingVehicle);
            Assert.AreEqual(delivery.CostPerRefuel, costPerRefuel);
        }
        
        [TestMethod]
        public void TestShippingEuropeanSwallo()
        {
            var mockDeliveryService = new Mock<IDeliveryService>();
            var mockProduct = new Mock<IProduct>();
            var mockShippingLocation = new Mock<IShippingLocation>();

            //mockShippingVehicle.Setup(sv => sv.MaxDistancePerRefuel).Equals(200);
            //mockShippingVehicle.Setup(sv => sv.MaxWeight).Equals(1000);
            //mockShippingVehicle.Setup(sv => sv.TopSpeed).Equals(65);

            mockDeliveryService.Setup(s => s.CostPerRefuel).Equals(1);
            mockDeliveryService.Setup(s => s.ShippingVehicle).Equals(new Truck());

            mockShippingLocation.Setup(sl => sl.StartZipCode).Equals("101011");
            mockShippingLocation.Setup(sl => sl.DestinationZipCode).Equals("7088");

            mockProduct.Setup(p => p.Name).Equals("Warcraft Grunt");
            mockProduct.Setup(p => p.ShippingWeight).Equals(42);
            mockProduct.Setup(p => p.ShortDescription).Equals("Why you poking me again?");

            List<IProduct> products = new List<IProduct>();
            products.Add(mockProduct.Object);

            DefaultShippingService swallow = new DefaultShippingService(mockDeliveryService.Object, products, mockShippingLocation.Object);
            


            ////Assert
            Assert.IsInstanceOfType(swallow.DeliveryService, typeof(IDeliveryService));
            Assert.IsInstanceOfType(swallow.ShippingLocation, typeof(IShippingLocation));
        }
       
    }
}
