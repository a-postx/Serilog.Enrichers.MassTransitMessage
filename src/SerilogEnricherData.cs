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
            {
                return messageContext;
            } 

            return null;
        }

        /// <summary>
        /// Extracts property data from the given <see cref="MessageContext"/>.
        /// </summary>
        /// <param name="pipe"></param>
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
                    MessageBusConversationId = context.ConversationId,
                    CorrelationId = context.CorrelationId,
                    MessageBusDestinationAddress = context.DestinationAddress,
                    MessageBusExpirationTime = context.ExpirationTime,
                    MessageBusFaultAddress = context.FaultAddress,
                    MessageBusInitiatorId = context.InitiatorId,
                    MessageBusMessageId = context.MessageId,
                    MessageBusRequestId = context.RequestId,
                    MessageBusResponseAddress = context.ResponseAddress,
                    MessageBusSourceAddress = context.SourceAddress,
                    MessageBusSentTime = context.SentTime
                };
            }
        }
    }
}
