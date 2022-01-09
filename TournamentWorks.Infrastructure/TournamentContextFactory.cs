using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentWorks.Infrastructure
{
    public class TournamentContextFactory : IDesignTimeDbContextFactory<TournamentContext>
    {
        public TournamentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tournament;Integrated Security=true;");

            return new TournamentContext(optionsBuilder.Options);
        }
    }
}
