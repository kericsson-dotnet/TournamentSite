using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TournamentSite.Data.Data;

    public class TournamentSiteContext : DbContext
    {
        public TournamentSiteContext (DbContextOptions<TournamentSiteContext> options)
            : base(options)
        {
        }

        public DbSet<TournamentSite.Core.Entities.Tournament> Tournament { get; set; } = default!;
        public DbSet<TournamentSite.Core.Entities.Game> Game { get; set; } = default!;
    }
