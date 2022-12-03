using Pioneer_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Pioneer_Backend.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ProjectCollection> Projects { get; set; }
        public DbSet<RewardCollection> Rewards { get; set; }
    }
}
