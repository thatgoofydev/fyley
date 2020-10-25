using DDDCore.Domain.Errors;

namespace Fyley.Components.Dossiers.Domain.Errors
{
    public class InvalidDossierName : DomainError
    {
        public InvalidDossierName()
            : base("Invalid dossier name. A dossiers name van only contain alphanumerical characters.")
        {
        }
    }
}