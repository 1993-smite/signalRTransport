using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitCore.Core.Listeners
{
    public class RabbitMqListener: IDisposable
    {
		private readonly ConnectionFactory _factory;
		private IConnection _connection;
		private IModel _channel;
		private readonly string _queue;

		public RabbitMqListener(string queue)
        {
			_factory = ConnectionFactoryResolver.CreateByService();
			_queue = queue;

		}

		public event Action<string> Receiver;

		public void Listen(Action<string> receive)
        {
			_connection = _factory.CreateConnection();
			_channel = _connection.CreateModel();

			_channel.QueueDeclare(queue: _queue,
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body.ToArray();
				var message = Encoding.UTF8.GetString(body);

				Receiver?.Invoke(message);
				receive?.Invoke(message);
			};
			_channel.BasicConsume(queue: _queue,
								 autoAck: true,
								 consumer: consumer);
		}

		public void Dispose()
		{
			_channel.Close();
			_connection.Close();
		}


	}
}
