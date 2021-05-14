using LiteSmallConference.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LiteSmallConference.Persitence.EF.SQLite
{
    public class LiteSmallConferenceContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public LiteSmallConferenceContext(DbContextOptions
            <LiteSmallConferenceContext> options)
            : base(options)
        {

        }
    }

}
