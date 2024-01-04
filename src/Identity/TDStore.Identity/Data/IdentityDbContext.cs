using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TDStore.Identity.Data
{
    public class IdentityStoreDbContext : IdentityDbContext
    {
        public IdentityStoreDbContext(DbContextOptions<IdentityStoreDbContext> options) : base(options) { }
    }
}
