using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreCandidates.Domain.Entities;

namespace StoreCandidates.Infra
{
    public class StoreCandidatesContext : DbContext
    {
        private readonly string connectionString;

        public StoreCandidatesContext(DbContextOptions<StoreCandidatesContext> options, IConfiguration configuration) : base(options)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Candidate>()
            //modelBuilder.Entity<Job>()

            modelBuilder.Entity<CandidatePerJob>().HasKey(sc => new { sc.CandidateId, sc.JobId });

        }

        public DbSet<Job> Job { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidatePerJob> CandidatePerJob { get; set; }
    }
}
