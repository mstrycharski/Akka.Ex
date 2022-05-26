namespace Akka.Ex2.Messages
{
    public class SendNotification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}