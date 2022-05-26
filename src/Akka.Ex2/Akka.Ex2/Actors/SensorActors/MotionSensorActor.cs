using System;
using Akka.Actor;
using Akka.Ex2.Messages;
using Akka.Ex2.Messages.SensorValueRetrieved;

namespace Akka.Ex2.Actors.SensorActors
{
    public class MotionSensorActor : SensorActorBase
    {
        protected override void HandleReadSensorValueMessage(ReadSensorValue message)
        {
            Console.WriteLine($"Message of type {message.GetType()} received in actor {nameof(MotionSensorActor)}");
            Context.Parent.Tell(new MotionSensorValueRetrieved { Value = new Random().Next(100) > 95 ? 1 : 0 });
        }
    }
}