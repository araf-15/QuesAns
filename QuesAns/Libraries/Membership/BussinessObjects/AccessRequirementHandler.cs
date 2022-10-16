using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Membership.BussinessObjects
{
    public class AccessRequirementHandler : AuthorizationHandler<AccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            var claim = context.User.FindFirst("FullName");
            var IsHRAccessor = context.User.FindFirst("IsHRAccess");

            if ((claim != null && !string.IsNullOrWhiteSpace(claim.Value)) &&
                (IsHRAccessor != null && !string.IsNullOrWhiteSpace(IsHRAccessor.Value)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
