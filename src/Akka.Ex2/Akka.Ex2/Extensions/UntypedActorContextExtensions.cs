using Akka.Actor;

namespace Akka.Ex2.Extensions
{
    internal static class UntypedActorContextExtensions
    {
        public static IActorRef GetOrCreate<TActor>(this IUntypedActorContext context, string actorName)
            where TActor : ActorBase, new()
        {
            var actor = context.Child(actorName);
            return actor.IsNobody() ? context.ActorOf(Props.Create(() => new TActor()), actorName) : actor;
        }
    }
}