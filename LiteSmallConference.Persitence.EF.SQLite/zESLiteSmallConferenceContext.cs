using LiteSmallConference.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LiteSmallConference.Persitence.EF.SQLite
{
    public class zESLiteSmallConferenceContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public zESLiteSmallConferenceContext(DbContextOptions
            <zESLiteSmallConferenceContext> options)
            : base(options)
        {

        }
    }
}
