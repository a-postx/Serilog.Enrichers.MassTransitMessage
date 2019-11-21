using System;

namespace Serilog.Enrichers.MassTransitMessage
{
    /// <summary>
    /// POCO for message parameters.
    /// </summary>
    internal class MessageBusMessageContext
    {
        internal Guid? MessageBusMessageId { get; set; }
        internal Guid? MessageBusRequestId { get; set; }
        internal Guid? CorrelationId { get; set; }
        internal Guid? MessageBusConversationId { get; set; }
        internal Guid? MessageBusInitiatorId { get; set; }
        internal Uri MessageBusSourceAddress { get; set; }
        internal Uri MessageBusDestinationAddress { get; set; }
        internal Uri MessageBusResponseAddress { get; set; }
        internal Uri MessageBusFaultAddress { get; set; }
        internal DateTime? MessageBusExpirationTime { get; set; }
        internal DateTime? MessageBusSentTime { get; set; }
    }
}