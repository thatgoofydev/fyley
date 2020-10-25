using System.Text.RegularExpressions;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Dossiers.Domain.Errors;

namespace Fyley.Components.Dossiers.Domain
{
    public class DossierName : SingleValueObject<string>
    {
        private static readonly Regex NameRegex = new Regex("^[a-zA-Z0-9]*$");
        
        public DossierName(string value) : base(value)
        {
            if (value.Length < 3) throw new DossierNameToShort();
            if (!NameRegex.IsMatch(value)) throw new InvalidDossierName();
        }
    }
}