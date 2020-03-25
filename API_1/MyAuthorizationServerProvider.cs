using API.Models;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.FromResult(context.Validated());
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            Login login = new Login();
            login.LoginUser = context.UserName;
            login.Password= context.Password;
            login = login.LoginDetil();

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (login.Isvalid)
            {
                identity.AddClaim(new Claim("username", login.LoginUser));
                identity.AddClaim(new Claim("Role", login.Role));
                identity.AddClaim(new Claim("isValid", login.Isvalid.ToString()));

                if (login.Role=="Admin")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    identity.AddClaim(new Claim("IsSupperAdmin", "true"));

                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                    identity.AddClaim(new Claim("IsSupperAdmin", "false"));
                    context.Validated(identity);
                }
                context.Validated(identity);
            }
            else
            {
                ///context.s
                context.SetError("invalid_grant", "Invalid User");
                return;
            }
            
        }

        private bool ValidCredential(string userID, string pass)
        {
            return false;
        }
    }
}