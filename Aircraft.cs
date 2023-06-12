using System;
using System.Dynamic;
using spatial;
using flightmanagementcomputer;

namespace aircraft
{
    public class Aircraft
    {
        private string Manufacturer { get; }
        private string Model { get;  }
        private int Id = 0; 
        private double heading = 0d;
        private double speedK = 0d;       
        private double altitude = 0d;
        private FMC fmc  = null;

        public Aircraft(string manufacturer, string model, int id)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Id = id;
        }

        public int getId()
        {
            return Id;
        }

        override public string ToString()
        {
            return $"manuf={Manufacturer} model={Model} ID={Id} " + 
            $" heading={heading} speed={speedK}";
        }

        public void setFMC(FMC f) => fmc = f;
        

        public FMC getFMC() => fmc;
        
 
        public Position getCurrentPosition() =>  fmc.getCurrentPosition();
        
        public void setSpeed(double sp)
        {
            speedK = sp;
            fmc.changeEvent(new VVector(speedK, heading, DateTime.UtcNow));
        }

        

        public double getSpeed() => speedK;

        public void setHeading(double head)
        {
            heading = head;
            fmc.changeEvent(new VVector(speedK, heading, DateTime.UtcNow));
        }
        public double getHeading() => heading;

        public void setHeadingAndSpeed(double headng, double speedKnots)
        {
            heading = headng;
            speedK = speedKnots;
            fmc.changeEvent(new VVector(speedK, heading, DateTime.UtcNow));
            //Console.WriteLine("UTCNow:" + DateTime.UtcNow);
        }

        public void setAltitude(double feet)
        {
            altitude = feet;
            fmc.setAltitude(feet); //FMC converts feet to NM
        }

        public double getAltitude() => altitude;
    }
}
