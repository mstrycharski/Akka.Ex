using System;
using Akka.Actor;
using Akka.Ex2.Messages;
using Akka.Ex2.Messages.SensorValueRetrieved;

namespace Akka.Ex2.Actors.SensorActors
{
    public class CarbonMonoxideSensorActor : SensorActorBase
    {
        protected override void HandleReadSensorValueMessage(ReadSensorValue message)
        {
            Console.WriteLine($"Message of type {message.GetType()} received in actor {nameof(CarbonMonoxideSensorActor)}");
            Context.Parent.Tell(new CarbonMonoxideSensorValueRetrieved { Value = new Random().NextDouble() * 30 });
        }
    }
}