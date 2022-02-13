using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitCore.Core.Listeners
{
	public class RabbitMqListenerService : BackgroundService
	{
		protected IConnection _connection;
		protected IModel _channel;

		public RabbitMqListenerService(string queue = null)
		{
			// Не забудьте вынести значения "localhost" и "MyQueue"
			// в файл конфигурации
			var factory = ConnectionFactoryResolver.CreateByService();
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.QueueDeclare(queue: queue ?? "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
		}

		public event Action<string> Receiver;

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (ch, ea) =>
			{
				var content = Encoding.UTF8.GetString(ea.Body.ToArray());

				Receiver?.Invoke(content);

				_channel.BasicAck(ea.DeliveryTag, false);
			};

			_channel.BasicConsume("MyQueue", false, consumer);

			return Task.CompletedTask;
		}

		public override void Dispose()
		{
			_channel.Close();
			_connection.Close();
			base.Dispose();
		}
	}
}
