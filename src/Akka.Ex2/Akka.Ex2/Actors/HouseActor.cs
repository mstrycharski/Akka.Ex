using System;
using Akka.Actor;
using Akka.Ex2.Actors.SensorActors;
using Akka.Ex2.Extensions;
using Akka.Ex2.Messages;
using Akka.Ex2.Messages.SensorValueRetrieved;

namespace Akka.Ex2.Actors
{
    public class HouseActor : ReceiveActor
    {
        private readonly HouseState _state = new HouseState();

        public HouseActor()
        {
            var configuration = new SensorsConfiguration();

            Receive<RegisterSensor>(msg =>
            {
                var child = msg.Type switch
                {
                    SensorType.AirQuality => Context.ActorOf(Props.Create(() => new AirQualitySensorActor())),
                    SensorType.CarbonMonoxide => Context.ActorOf(
                        Props.Create(() => new CarbonMonoxideSensorActor())),
                    SensorType.Gas => Context.ActorOf(Props.Create(() => new GasSensorActor())),
                    SensorType.Flood => Context.ActorOf(Props.Create(() => new FloodSensorActor())),
                    SensorType.Door => Context.ActorOf(Props.Create(() => new DoorSensorActor())),
                    SensorType.Motion => Context.ActorOf(Props.Create(() => new MotionSensorActor())),
                    SensorType.Window => Context.ActorOf(Props.Create(() => new WindowSensorActor())),
                    _ => throw new ArgumentOutOfRangeException()
                };

                Context.System.Scheduler.ScheduleTellRepeatedly(TimeSpan.Zero,
                    configuration.GetTimeInterval(msg.Type),
                    child,
                    new ReadSensorValue(),
                    Context.Self);
            });

            Receive<CloseHouse>(msg =>
            {
                _state.CloseTheHouse();

                Context
                    .GetOrCreate<CheckSensorValueActor>("checkTheSensorValue")
                    .Forward(msg);
            });

            Receive<SensorValueRetrieved>(msg =>
            {
                Console.WriteLine(
                    $"Message of type {msg.GetType()} handled in {nameof(HouseActor)} actor named {Context.Self.Path}. Sensor Value: {msg.Value}, Sensor Type: {msg.GetType().Name}");

                msg.HouseClosed = _state.IsClosed;

                Context
                    .GetOrCreate<CheckSensorValueActor>("checkTheSensorValue")
                    .Forward(msg);
            });

            Receive<RaiseAlarm>(msg =>
            {
                Context
                    .GetOrCreate<SendNotificationActor>("notifier")
                    .Forward(new SendNotification { Type = NotificationType.Sms, Message = msg.Message });
            });
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(5, TimeSpan.FromMinutes(1),
                ex => ex is DivideByZeroException ? Directive.Restart : Directive.Stop);
        }
    }
}