namespace DDDCore.Infrastructure.CorrelationId
{
    public class CorrelationContextFactory : ICorrelationContextFactory
    {
        private readonly ICorrelationContextAccessor _accessor;

        public CorrelationContextFactory()
        {
            _accessor = null;
        }
        
        public CorrelationContextFactory(ICorrelationContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        public CorrelationContext CreateContext(string correlationId)
        {
            var context = new CorrelationContext(correlationId);
            if (_accessor != null)
            {
                _accessor.CorrelationContext = context;
            }
            return context;
        }
    }
}