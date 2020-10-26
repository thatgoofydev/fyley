namespace DDDCore.Infrastructure.CorrelationId
{
    public class CorrelationContext
    {
        public string CorrelationId { get; }

        public CorrelationContext(string correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}