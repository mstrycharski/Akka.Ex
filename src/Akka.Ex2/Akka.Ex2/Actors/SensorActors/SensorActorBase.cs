using System;
using Akka.Actor;
using Akka.Ex2.Messages;

namespace Akka.Ex2.Actors.SensorActors
{
    public abstract class SensorActorBase : ReceiveActor
    {
        protected SensorActorBase()
        {
            Receive<ReadSensorValue>(HandleReadSensorValueMessage);
        }

        protected abstract void HandleReadSensorValueMessage(ReadSensorValue message);
    }
}