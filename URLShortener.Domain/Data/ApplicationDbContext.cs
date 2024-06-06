using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using URLShortener.Bussiness;
using URLShortener.Domain.Data.Configurations;
using URLShortener.Domain.Models;

namespace URLShortener.Domain.Data
{

    public class ApplicationDbContext: DbContext
    {
        private readonly AdminSeedData _adminSeedData;
        private readonly AboutMessageSeedData _aboutMessageSeedData;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,   IOptions<AdminSeedData> adminSeedDataOptions,
            IOptions<AboutMessageSeedData> aboutMessageSeedDataOptions) : base(options)
        {
            _adminSeedData = adminSeedDataOptions.Value;
            _aboutMessageSeedData = aboutMessageSeedDataOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration(_adminSeedData));
            modelBuilder.ApplyConfiguration(new AboutMessageEntityConfiguration(_aboutMessageSeedData));
            modelBuilder.ApplyConfiguration(new ShortenUrlEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<ShortenUrl> ShortenUrls { get; set; }
        public DbSet<AboutMessage> AboutMessages { get; set; }
    }
}