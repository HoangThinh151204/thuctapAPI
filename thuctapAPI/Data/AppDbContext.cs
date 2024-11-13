using Microsoft.EntityFrameworkCore;
using thuctapAPI.Model;

namespace thuctapAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Di chuyển tất cả các cấu hình quan hệ vào đây
            // Cấu hình mối quan hệ giữa Account và Position (Một-nhiều)
            modelBuilder.Entity<Account>()
                .HasOne<Position>()
                .WithMany()
                .HasForeignKey(a => a.IdPosition);

            // Cấu hình mối quan hệ giữa Account và Role (Một-nhiều)
            modelBuilder.Entity<Account>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(a => a.IdRole);

            // Cấu hình mối quan hệ giữa Job và Warehouse (Một-nhiều)
            modelBuilder.Entity<Job>()
                .HasOne<Warehouse>()
                .WithMany()
                .HasForeignKey(j => j.IdWarehouse);

            // Cấu hình mối quan hệ giữa Job và Manager (Một-nhiều)
            modelBuilder.Entity<Job>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(j => j.IdJob)
                .OnDelete(DeleteBehavior.Restrict); // Ngăn chặn xóa theo cascade

            // Cấu hình mối quan hệ giữa Job và Creator (Một-nhiều)
            modelBuilder.Entity<Job>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(j => j.IdJob)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ nhiều-nhiều giữa Account và Area
            modelBuilder.Entity<AccountArea>()
                .HasKey(aa => new { aa.IdAcc, aa.IdArea }); // Khóa hợp nhất

            modelBuilder.Entity<AccountArea>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(aa => aa.IdAcc);

            modelBuilder.Entity<AccountArea>()
                .HasOne<Area>()
                .WithMany()
                .HasForeignKey(aa => aa.IdArea);

            // Cấu hình mối quan hệ nhiều-nhiều giữa Account và SurveyRequest
            modelBuilder.Entity<AccountSurveyRequest>()
                .HasKey(asr => new { asr.IdAcc, asr.IdSR }); // Khóa hợp nhất

            modelBuilder.Entity<AccountSurveyRequest>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(asr => asr.IdAcc);

            modelBuilder.Entity<AccountSurveyRequest>()
                .HasOne<SurveyRequest>()
                .WithMany()
                .HasForeignKey(asr => asr.IdSR);

            // Cấu hình mối quan hệ giữa Account và Visitor (Một-nhiều)
            modelBuilder.Entity<Visitor>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(v => v.IdAcc);

            modelBuilder.Entity<Visitor>()
                .HasOne<Warehouse>()
                .WithMany()
                .HasForeignKey(v => v.IdWS);

            // Cấu hình một-nhiều giữa Warehouse và Baseline
            modelBuilder.Entity<Baseline>()
                .HasOne<Warehouse>()
                .WithMany()
                .HasForeignKey(b => b.WarehouseId);

            // Cấu hình một-nhiều giữa Warehouse và Job
            modelBuilder.Entity<Job>()
                .HasOne<Warehouse>()
                .WithMany()
                .HasForeignKey(j => j.IdWarehouse);

            // Cấu hình nhiều-một giữa Job và JobImage
            modelBuilder.Entity<JobImage>()
                .HasOne<Job>()
                .WithMany()
                .HasForeignKey(ji => ji.IdJob);

            // Cấu hình mối quan hệ giữa Account và Notification (Nhiều-nhiều)
            modelBuilder.Entity<AccountNotification>()
                .HasKey(an => an.Id); // Khóa chính

            modelBuilder.Entity<AccountNotification>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(an => an.IdAcc);

            modelBuilder.Entity<AccountNotification>()
                .HasOne<Notification>()
                .WithMany()
                .HasForeignKey(an => an.IdNoti);

            // Cấu hình nhiều-một giữa SurveyRequest và SurveyArticle
            modelBuilder.Entity<SurveyArticle>()
                .HasOne<Article>()
                .WithMany()
                .HasForeignKey(sa => sa.IdArticle);

            // Cấu hình một-nhiều giữa Question và Answer
            modelBuilder.Entity<Answer>()
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(a => a.IdQuestion);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Baseline> Baselines { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobImage> JobImages { get; set; }
        public DbSet<Broadcast> Broadcasts { get; set; }
        public DbSet<BroadcastGroup> BroadcastGroups { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AccountNotification> AccountNotifications { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<SurveyRequest> SurveyRequests { get; set; }
        public DbSet<AccountSurveyRequest> AccountSurveyRequests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<SurveyArticle> SurveyArticles { get; set; }
        public DbSet<AccountArea> AccountAreas { get; set; }
        public DbSet<Area> Areas { get; set; }

    }
}
