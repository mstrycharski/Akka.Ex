using System;
using Akka.Actor;
using Akka.Ex2.Actors;
using Akka.Ex2.Messages;

namespace Akka.Ex2.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            var houseA = system.ActorOf<HouseActor>("houseA");
            var houseB = system.ActorOf<HouseActor>("houseB");
            var houseC = system.ActorOf<HouseActor>("houseC");
            var houseD = system.ActorOf<HouseActor>("houseD");
            var houseE = system.ActorOf<HouseActor>("houseE");
            var houseF = system.ActorOf<HouseActor>("houseF");

            houseA.Tell(new RegisterSensor { Type = SensorType.Gas });
            houseA.Tell(new RegisterSensor { Type = SensorType.Flood });
            houseA.Tell(new RegisterSensor { Type = SensorType.Door });
            houseA.Tell(new RegisterSensor { Type = SensorType.Motion });
            houseA.Tell(new RegisterSensor { Type = SensorType.AirQuality });
            houseA.Tell(new RegisterSensor { Type = SensorType.Window });

            Console.ReadKey();
        }
    }
}
