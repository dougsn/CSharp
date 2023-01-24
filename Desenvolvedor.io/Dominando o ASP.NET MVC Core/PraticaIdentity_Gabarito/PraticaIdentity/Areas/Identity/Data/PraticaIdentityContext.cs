using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PraticaIdentity.Areas.Identity.Data;

public class PraticaIdentityContext : IdentityDbContext<IdentityUser>
{
    public PraticaIdentityContext(DbContextOptions<PraticaIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
