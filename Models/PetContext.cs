using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<PetItem> PetItems { get; set; }
    }
}