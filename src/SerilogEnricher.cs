using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.MassTransitMessage
{
    /// <summary>
    /// Enriches Serilog data with Mass Transit data.
    /// </summary>
    public class SerilogEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)
        {
            MessageBusMessageContext data = SerilogEnricherData.Current;

            if (data != null)
            {
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusMessageId), data.MessageBusMessageId?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusRequestId), data.MessageBusRequestId?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.CorrelationId), data.CorrelationId?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusConversationId), data.MessageBusConversationId?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusInitiatorId), data.MessageBusInitiatorId?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusSourceAddress), data.MessageBusSourceAddress?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusDestinationAddress), data.MessageBusDestinationAddress?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusResponseAddress), data.MessageBusResponseAddress?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusFaultAddress), data.MessageBusFaultAddress?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusSentTime), data.MessageBusSentTime?.ToString(), true));
                logEvent.AddPropertyIfAbsent(factory.CreateProperty(nameof(data.MessageBusExpirationTime), data.MessageBusExpirationTime?.ToString(), true));
            }
        }
    }
}
