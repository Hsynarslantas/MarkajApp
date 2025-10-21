using System.Text.RegularExpressions;
using FootballApps.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApps.DataAccessLayer.Concrete
{
    public class FootballAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O65VQEH\\SQLEXPRESS;initial Catalog=FootballAppsDb;integrated Security=true;trust server certificate=true;");
        }
        public DbSet<Matchs> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerMatchStatistic> PlayerMatchStatistics { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<LatestNew> LatestNews { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactComment> ContactComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matchs>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matchs>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
