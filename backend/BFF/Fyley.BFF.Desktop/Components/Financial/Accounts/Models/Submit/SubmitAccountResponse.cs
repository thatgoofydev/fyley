using System;
using JetBrains.Annotations;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit
{
    public class SubmitAccountResponse
    {
        [UsedImplicitly] public Guid Id {  get; }
        
        public SubmitAccountResponse(Guid id)
        {
            Id = id;
        }
    }
}