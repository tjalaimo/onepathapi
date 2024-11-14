using Microsoft.EntityFrameworkCore;
using onepathapi.Models;

namespace onepathapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AccessCode> AccessCodes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<NetworkUser> NetworkUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageThread> MessageThreads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NetworkUser>()
                .HasKey(nu => new { nu.NetworkId, nu.UserId });

            modelBuilder.Entity<PostLike>()
                .HasKey(pl => new { pl.PostId, pl.LikedByUserId });

            modelBuilder.Entity<MessageThread>()
                .HasIndex(mt => new { mt.InitiatorUserId, mt.RecipientUserId }).IsUnique();
        }
    }
}
