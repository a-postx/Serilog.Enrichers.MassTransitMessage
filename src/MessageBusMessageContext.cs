using System;

namespace Serilog.Enrichers.MassTransitMessage
{
    /// <summary>
    /// POCO for message parameters.
    /// </summary>
    internal class MessageBusMessageContext
    {
        internal Guid? MessageId { get; set; }
        internal Guid? RequestId { get; set; }
        internal Guid? CorrelationId { get; set; }
        internal Guid? ConversationId { get; set; }
        internal Guid? InitiatorId { get; set; }
        internal Uri SourceAddress { get; set; }
        internal Uri DestinationAddress { get; set; }
        internal Uri ResponseAddress { get; set; }
        internal Uri FaultAddress { get; set; }
        internal DateTime? SentTime { get; set; }
        internal DateTime? ExpirationTime { get; set; }
    }
}