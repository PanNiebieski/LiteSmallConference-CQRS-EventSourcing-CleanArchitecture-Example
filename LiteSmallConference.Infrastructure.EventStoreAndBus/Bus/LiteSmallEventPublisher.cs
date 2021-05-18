using GeekLemonConference.Infrastructure.EventStoreAndBus;
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.DomainEvents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GeekLemon.Infrastructure.Write.MongoDB.Bus
{
    public class LiteSmallEventPublisher : IEventPublisher
    {
        private readonly ConnectionFactory connectionFactory;

        public LiteSmallEventPublisher(IHostingEnvironment env/*, AMQPEventSubscriber aMQPEventSubscriber*/)
        {
            connectionFactory = new ConnectionFactory();

            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddEnvironmentVariables();

            builder.Build().GetSection("RabbitMqSetting").Bind(connectionFactory);
        }



        public void Publish<T>(T @event) where T : DomainEvent
        {
            using (IConnection conn = connectionFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    var queue = @event.WhatRabbitMQQueue();

                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null

                    );

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }


    }
}
