using Microsoft.AspNetCore.Authorization;

namespace Side.Winder.Api.Security
{
    public class HasScopeRequirements : IAuthorizationRequirement
    {
        public string Issuer {get;}
        public string Scope {get;}

        public HasScopeRequirements(String scope, string issuer)
        {
            scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}