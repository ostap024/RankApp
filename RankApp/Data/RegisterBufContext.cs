using Microsoft.EntityFrameworkCore;



namespace RankApp.Data
{
    public class RegisterBufContext : DbContext
    {
        public DbSet<RegisterBuf> RegisterBufs { get; set; }
        public RegisterBufContext(DbContextOptions<RegisterBufContext> options)
            : base(options)
        {
        }
    }
}