using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class Plane : MotorVehicle
    {
        public Plane()
        {
            this.MaxDistancePerRefuel = 5000;
            this.MaxWeight = 1000;
            this.TopSpeed = 200;
        }
    }
}