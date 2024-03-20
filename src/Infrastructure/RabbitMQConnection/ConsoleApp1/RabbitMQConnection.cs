using RabbitMQ.Client;
using System;

public class RabbitMQConnection
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQConnection()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "amqps://mvozslgx:pqwFwHvHk1WBtns7TtEZ_Twvig-jF5Uj@kangaroo.rmq.cloudamqp.com/mvozslgx", // Имя хоста или IP-адрес сервера RabbitMQ
            Port = 5672, // Порт по умолчанию для AMQP
            UserName = "guest", // Имя пользователя по умолчанию
            Password = "guest" // Пароль по умолчанию
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "logQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public IModel GetChannel()
    {
        return _channel;
    }
}
