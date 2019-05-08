using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.Vehicles
{
    public class EuropeanSwallow : MotorVehicle
    {
        public EuropeanSwallow() : base()
        {
            this.MaxDistancePerRefuel = 50;
            this.MaxWeight = 1500;
            this.TopSpeed = 350;
        }
    }
}
