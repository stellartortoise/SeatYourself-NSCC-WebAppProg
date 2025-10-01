using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeatYourself.Models;

namespace SeatYourself.Data
{
    public class SeatYourselfContext : DbContext
    {
        public SeatYourselfContext (DbContextOptions<SeatYourselfContext> options)
            : base(options)
        {
        }

        public DbSet<SeatYourself.Models.Occasion> Occasion { get; set; } = default!;
        public DbSet<SeatYourself.Models.Ticket> Ticket { get; set; } = default!;
    }
}
