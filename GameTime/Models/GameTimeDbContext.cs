using Microsoft.EntityFrameworkCore;

namespace GameTime.Models
{
    public class GameTimeDbContext : DbContext
    {
        public GameTimeDbContext() {}
        public GameTimeDbContext(DbContextOptions<GameTimeDbContext> options) : base(options) { }

        public DbSet<tblUsers> tblUsers { get; set; }   
        public DbSet<tblGames> tblGames { get; set; }
        public DbSet<tblUserGames> tblUserGames { get; set; } 
        public DbSet<tblReviews> tblReviews { get; set; }
        public DbSet<tblUserList> tblUserList { get; set; }
        public DbSet<tblUserListItems> tblUserListItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBCS"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configure table relationships
            modelBuilder.Entity<tblUserGames>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGames)
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<tblUserGames>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<tblReviews>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<tblReviews>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<tblUserList>()
               .HasOne(l => l.User)
               .WithMany(u => u.Lists)
               .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<tblUserListItems>()
               .HasOne(i => i.UserList)
               .WithMany(l => l.Items)
               .HasForeignKey(i => i.UserListId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<tblUserListItems>()
            .HasOne(i => i.Game)
            .WithMany(l => l.ListItems)
            .HasForeignKey(i => i.GameId)
            .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
