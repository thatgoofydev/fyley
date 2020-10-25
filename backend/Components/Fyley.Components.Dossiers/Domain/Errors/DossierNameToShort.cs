using DDDCore.Domain.Errors;

namespace Fyley.Components.Dossiers.Domain.Errors
{
    public sealed class DossierNameToShort : DomainError
    {
        public DossierNameToShort() : base("A dossier name should be at least 3 characters.")
        { }
    }
}