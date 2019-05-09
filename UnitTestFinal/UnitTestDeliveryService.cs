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
        public void TestMock()
        {
            //Assign
            EuropeanSwallowFakeShippingService defaultMock;

            var mockDeliveryService = new Mock<IDeliveryService>();
            var mockProduct = new Mock<IProduct>();
            var mockListProduct = new Mock<List<IProduct>>();
            var mockShippingLocation = new Mock<IShippingLocation>();

            var mockShippingVehicle = new Mock<IShippingVehicle>();
            var mockMotorrVehicle = mockShippingVehicle.As<IMotorVehicle>();
            //Act
            mockShippingVehicle.Setup(sv => sv.MaxDistancePerRefuel).Equals(200);
            mockShippingVehicle.Setup(sv => sv.MaxWeight).Equals(1000);
            mockShippingVehicle.Setup(sv => sv.TopSpeed).Equals(65);

            mockDeliveryService.Setup(s => s.CostPerRefuel).Equals(1);
            mockDeliveryService.Setup(s => s.ShippingVehicle).Equals(mockShippingVehicle.Object);

            mockShippingLocation.Setup(sl => sl.StartZipCode).Equals("101011");
            mockShippingLocation.Setup(sl => sl.DestinationZipCode).Equals("7088");

            mockProduct.Setup(p => p.Name).Equals("Warcraft Grunt");
            mockProduct.Setup(p => p.ShippingWeight).Equals(42);
            mockProduct.Setup(p => p.ShortDescription).Equals("Why you poking me again?");

            mockListProduct.Object.Add(mockProduct.Object);

            defaultMock = new EuropeanSwallowFakeShippingService(mockDeliveryService.Object, mockListProduct.Object, mockShippingLocation.Object);

            //double cost;
            //cost = defaultMock.ShippingCost();

            ////Assert
            Assert.IsInstanceOfType(defaultMock.DeliveryService, typeof(IDeliveryService));
            Assert.IsInstanceOfType(defaultMock.ShippingLocation, typeof(IShippingLocation));
            Assert.IsInstanceOfType(defaultMock.Products, typeof(List<IProduct>));
           
        }
       
    }
}
