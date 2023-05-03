using LePortfolioApi.Data;
using LePortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LePortfolioApi.Seeders
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly EfContext _context;

        public DatabaseSeeder(EfContext context)
        {
            _context = context;
            context.Database.Migrate();
        }
        public void Run()
        {
            SeedSkills();
        }


        private void SeedSkills()
        {

            if (_context.Skills.Count() == 0) {

                var skill = new Skill() { 
                    Label = "Flutter",
                    Icon = "devicon-flutter-plain"
                };

                _context.Skills.Add(skill);
                _context.SaveChanges();

            }
        }
    }
}
