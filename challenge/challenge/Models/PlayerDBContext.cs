using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions<PlayerDBContext> options) : base(options)
        {

        }
        public DbSet<Challenges> challenges { get; set; }
        public DbSet<Player> players { get; set; }
    }
                
}

