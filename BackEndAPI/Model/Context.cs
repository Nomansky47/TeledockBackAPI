using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace TeledockBackAPI.Model
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        [JsonIgnore]
        public DbSet<Client> Clients { get; set; }
        [JsonIgnore]
        public DbSet<Founder> Founders { get; set; }
    }
}
