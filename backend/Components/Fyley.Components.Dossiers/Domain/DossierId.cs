using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Components.Dossiers.Domain
{
    public class DossierId : Identifier
    {
        private const string AggregateName = "Dossier";
        
        public DossierId(Guid value) : base(AggregateName, value)
        { }
    }
}