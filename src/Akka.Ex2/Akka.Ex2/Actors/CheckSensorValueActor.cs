using System;
using Akka.Actor;
using Akka.Ex2.Messages;
using Akka.Ex2.Messages.SensorValueRetrieved;

namespace Akka.Ex2.Actors
{
    public class CheckSensorValueActor : ReceiveActor
    {
        public CheckSensorValueActor()
        {
            Receive<AirQualitySensorValueRetrieved>(msg =>
            {
                if (msg.Value > 5)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = $"Your air quality sensor raised an alarm with value {msg.Value}." });
            });

            Receive<CarbonMonoxideSensorValueRetrieved>(msg =>
            {
                if (msg.Value > 27)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = $"Your carbon monoxide sensor raised an alarm with value {msg.Value}." });
            });

            Receive<GasSensorValueRetrieved>(msg =>
            {
                if (msg.Value > 0.9)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = $"Your gas sensor raised an alarm with value {msg.Value}." });
            });

            Receive<FloodSensorValueRetrieved>(msg =>
            {
                if (msg.Value > 7)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = $"Your flood sensor raised an alarm with value {msg.Value}." });
            });

            Receive<DoorSensorValueRetrieved>(msg =>
            {
                if (msg.HouseClosed && Math.Abs(msg.Value - 1) <= 0)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = "Your door sensor raised an alarm. Doors are opened while house is closed." });
            });

            Receive<MotionSensorValueRetrieved>(msg =>
            {
                if (msg.HouseClosed && Math.Abs(msg.Value - 1) <= 0)
                    Context.Parent.Tell(new RaiseAlarm
                    { Message = "Your motion sensor raised an alarm. Someone is in your house while it is closed." });
            });

            Receive<WindowSensorValueRetrieved>(msg =>
            {
                if (msg.HouseClosed && Math.Abs(msg.Value - 1) <= 0)
                    Context.Parent.Tell(new RaiseAlarm
                    {
                        Message =
                            "Your window sensor raised an alarm. The window in your house is opened while it is closed."
                    });
            });
        }
    }
}