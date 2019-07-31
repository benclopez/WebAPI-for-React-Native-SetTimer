using Microsoft.EntityFrameworkCore;
using SetTimerAPI.Models;

namespace SetTimerApi.Models
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<WorkoutItem> WorkoutItems { get; set; }
    }
}