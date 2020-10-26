namespace DDDCore.Infrastructure.CorrelationId
{
    public interface ICorrelationContextAccessor
    {
        CorrelationContext CorrelationContext { get; set; }
    }
}