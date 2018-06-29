using Microsoft.EntityFrameworkCore;



namespace RankApp.Data
{
    public class NavantagennyaContext : DbContext
    {
        public DbSet<Navantagennya> Navantagennyas { get; set; }
        public DbSet<NavchRob> NavchRobs { get; set; }
        public DbSet<MetodRob> MetodRobs { get; set; }
        public DbSet<NaukRob> NaukRobs { get; set; }
        public DbSet<OrgRob> OrgRobs { get; set; }
        public DbSet<NormatKilkistBalivOrgRob> NormatKilkistBalivOrgRobs { get; set; }
        public NavantagennyaContext(DbContextOptions<NavantagennyaContext> options)
            : base(options)
        {
        }
    }
}
