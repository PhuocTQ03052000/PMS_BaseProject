using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Data.Config
{
    public class ResponseDataConfig : IEntityTypeConfiguration<ResponseData>
    {
        public void Configure(EntityTypeBuilder<ResponseData> builder)
        {
            builder.ToTable("Spotify");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(n => n.title).IsRequired().HasMaxLength(100);
            builder.Property(n => n.completed).IsRequired().HasMaxLength(100);

            builder.HasData(new List<ResponseData>()
            {
                new ResponseData()
                {
                    id = 1,
                    title = "Conan",
                    completed = true
                },
                new ResponseData()
                {
                    id = 2,
                    title = "Bảy viên ngọc rồng",
																				completed = false
																},
                new ResponseData()
                {
                    id = 3,
                    title = "Shin Cậu Bé Bút Chì",
																				completed = true
																}
            });
        }
    }
}
