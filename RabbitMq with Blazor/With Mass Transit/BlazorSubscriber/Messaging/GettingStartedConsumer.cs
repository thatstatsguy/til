using Contracts;
using MassTransit;

namespace BlazorSubscriber.Messaging;

public class GettingStartedConsumer : IConsumer<GettingStarted>
{
    public Task Consume(ConsumeContext<GettingStarted> message)
    {
        Console.WriteLine($" [x] {message.Message.Value}");
        return Task.CompletedTask;
    }
}