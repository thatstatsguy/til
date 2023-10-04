namespace BlazorSubscriber.Messaging;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMqSubscriber : IHostedService
{
    private IModel channel = null;
    private IConnection connection = null;
    // private EventingBasicConsumer consumer = null;
    
    private void Run()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        connection = factory.CreateConnection();
        channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

        // declare a server-named queue
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queue: queueName,
            exchange: "logs",
            routingKey: string.Empty);

        Console.WriteLine(" [*] Waiting for logs.");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] {message}");
        };
        channel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: consumer);

            
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Run();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        this.channel.Dispose();
        this.connection.Dispose();
        //https://stackoverflow.com/questions/50831664/using-rabbitmq-in-asp-net-core-ihostedservice
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }
}