using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Context;

public class MyDbContext : IdentityDbContext
{
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
}