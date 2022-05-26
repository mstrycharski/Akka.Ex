using System;
using Akka.Actor;
using Akka.Ex2.Messages;

namespace Akka.Ex2.Actors
{
    public class SendNotificationActor : ReceiveActor
    {
        public SendNotificationActor()
        {
            Receive<SendNotification>(msg =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"---> Send notification {msg.Message}, type: {msg.Type}.");
                Console.ResetColor();
            });
        }
    }
}