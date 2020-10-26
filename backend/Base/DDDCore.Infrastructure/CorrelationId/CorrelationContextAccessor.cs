namespace DDDCore.Infrastructure.CorrelationId
{
    public class CorrelationContextAccessor : ICorrelationContextAccessor
    {
        public CorrelationContext CorrelationContext { get; set; }
    }
}