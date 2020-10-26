namespace DDDCore.Infrastructure.CorrelationId
{
    public interface ICorrelationContextFactory
    {
        CorrelationContext CreateContext(string correlationId);
    }
}