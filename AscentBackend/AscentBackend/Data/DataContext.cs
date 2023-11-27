using AscentBackend.Models;
using Microsoft.EntityFrameworkCore;
using Stream = AscentBackend.Models.Stream;

namespace AscentBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ascent;Trusted_Connection=True;TrustServerCertificate=true;");
            //optionsBuilder.UseSqlServer("Server=WILLIAMZHANB322\\SQLEXPRESS;Database=ascent;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AssessmentCenter> AssessmentCenters { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewPack> InterviewsPacks { get; set; }
        public DbSet<Stream> Streams { get; set; }

    }
}
