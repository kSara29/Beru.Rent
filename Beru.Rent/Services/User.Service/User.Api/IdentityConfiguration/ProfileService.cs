using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace User.Api.IdentityConfiguration;

public class ProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}