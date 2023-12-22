using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataAccess.Data
{
    public class BlazorEducationContext:DbContext
    {
        public BlazorEducationContext(DbContextOptions<BlazorEducationContext> options):base (options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
