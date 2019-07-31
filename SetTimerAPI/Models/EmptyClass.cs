using Microsoft.EntityFrameworkCore;
using SetTimerAPI.Models;

namespace WorkoutApi.Models
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<WorkoutItem> TodoItems { get; set; }
        public object WorkoutItems { get; internal set; }
    }
}