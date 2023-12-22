using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BlazorCourseContext:DbContext
    {
        public BlazorCourseContext(DbContextOptions<BlazorCourseContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
