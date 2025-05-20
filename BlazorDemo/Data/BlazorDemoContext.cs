using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorDemo.Models;

namespace BlazorDemo.Data
{
    public class BlazorDemoContext : DbContext
    {
        public BlazorDemoContext (DbContextOptions<BlazorDemoContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorDemo.Models.User> User { get; set; } = default!;
    }
}
