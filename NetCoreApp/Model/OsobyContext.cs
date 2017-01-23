using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp.Model
{
    public class OsobyContext : DbContext
    {
        public OsobyContext(DbContextOptions<OsobyContext> options) : base(options) { }

        public DbSet<Osoba> Osoba { get; set; }
    }
}
