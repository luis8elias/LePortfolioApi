using Microsoft.EntityFrameworkCore;
using LePortfolioApi.Models;

namespace LePortfolioApi.Data
{
    public class EfContext : DbContext
    {
        public EfContext (DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<Link> Links { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;

        public DbSet<Skill> Skills { get; set; } = default!;


        public DbSet<ProjectImage> ProjectImages { get; set; } = default!;
        public DbSet<ProjectLink> ProjectLinks { get; set; } = default!;
        public DbSet<ProjectSkill> ProjectSkills { get; set; } = default!;

    }
}
