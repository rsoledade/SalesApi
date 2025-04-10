using System.Text.Json;
using SalesApi.Application.Interfaces;

namespace SalesApi.Application.Services
{
    public class ConsoleEventPublisher : IEventPublisher
    {
        public Task PublishAsync<TEvent>(TEvent @event)
        {
            var json = JsonSerializer.Serialize(@event, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine($"Event published: {typeof(TEvent).Name}\n{json}");
            return Task.CompletedTask;
        }
    }
}
