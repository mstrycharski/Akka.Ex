namespace Akka.Ex2.Messages.SensorValueRetrieved
{
    public abstract class SensorValueRetrieved
    {
        public double Value { get; set; }
        public bool HouseClosed { get; set; }

    }
}