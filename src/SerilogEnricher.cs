using Serilog.Core;
using Serilog.Events;
using System.Linq;
using System.Reflection;

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
                foreach (PropertyInfo prop in typeof(MessageBusMessageContext).GetProperties().ToList())
                {
                    if (prop != null && prop.CanRead)
                    {
                        logEvent.AddOrUpdateProperty(factory.CreateProperty(prop.Name, prop.GetValue(data), true));
                    }
                }
            }
        }
    }
}
