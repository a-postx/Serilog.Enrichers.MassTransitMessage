using GreenPipes;
using MassTransit;

namespace Serilog.Enrichers.MassTransitMessage
{
    /// <summary>
    /// Provides enrichment data.
    /// </summary>
    static class SerilogEnricherData
    {
        /// <summary>
        /// Gets the current enrichment data.
        /// </summary>
        public static MessageBusMessageContext Current => GetData();

        /// <summary>
        /// Gets the enrichment data.
        /// </summary>
        /// <returns></returns>
        static MessageBusMessageContext GetData()
        {
            PipeContext current = PipeContextStack.Current;
            MessageBusMessageContext messageContext = FromMessageContext(current);

            // only return if at least one property set
            if (messageContext != null)
                return messageContext;

            return null;
        }

        /// <summary>
        /// Extracts property data from the given <see cref="MessageContext"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        static MessageBusMessageContext FromMessageContext(PipeContext pipe)
        {
            var context = pipe?.GetPayload<MessageContext>();

            if (context == null)
            {
                return null;
            }
            else
            {
                return new MessageBusMessageContext
                {
                    ConversationId = context.ConversationId,
                    CorrelationId = context.CorrelationId,
                    DestinationAddress = context.DestinationAddress,
                    ExpirationTime = context.ExpirationTime,
                    FaultAddress = context.FaultAddress,
                    InitiatorId = context.InitiatorId,
                    MessageId = context.MessageId,
                    RequestId = context.RequestId,
                    ResponseAddress = context.ResponseAddress,
                    SourceAddress = context.SourceAddress,
                    SentTime = context.SentTime
                };
            } 
        }
    }
}
