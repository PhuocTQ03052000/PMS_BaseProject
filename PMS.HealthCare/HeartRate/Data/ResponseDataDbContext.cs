using Microsoft.EntityFrameworkCore;
using PMS.HealthCare.HeartRate.Data.Config;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Data
{
				public class ResponseDataDbContext: DbContext
				{
								public ResponseDataDbContext(DbContextOptions<ResponseDataDbContext> options) : base(options) { }

								#region DbSet
								public DbSet<ResponseData>? ResponseDatas { get; set; }
								#endregion DbSet

								protected override void OnModelCreating(ModelBuilder modelBuilder)
								{
												modelBuilder.ApplyConfiguration(new ResponseDataConfig());
								}
				}
}
