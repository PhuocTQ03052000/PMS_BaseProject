using Microsoft.EntityFrameworkCore;
using PMS.HealthCare.HeartRate.Data.Config;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Data
{
				public class UserDbContext: DbContext
				{
								public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

								#region DbSet
								public DbSet<User>? Users { get; set; }
								#endregion DbSet

								protected override void OnModelCreating(ModelBuilder modelBuilder)
								{
												modelBuilder.ApplyConfiguration(new UserConfig());
								}
				}
}
