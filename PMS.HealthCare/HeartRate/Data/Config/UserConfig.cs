using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(user => user.username).IsRequired().HasMaxLength(100);
            builder.Property(user => user.email).IsRequired().HasMaxLength(100);
												builder.Property(user => user.firstName).IsRequired().HasMaxLength(100);
												builder.Property(user => user.lastName).IsRequired().HasMaxLength(100);
												builder.Property(user => user.gender).IsRequired().HasMaxLength(100);
												builder.Property(user => user.image).IsRequired().HasMaxLength(100);
												builder.Property(user => user.token).IsRequired().HasMaxLength(100);

												builder.HasData(new List<User>()
            {
                new User()
                {
                    id = 1,
																				username = "Conan",
																				email = "conan@gmail.com",
                    firstName = "conan",
                    lastName = "shinichi",
                    gender = "Male",
                    image = "demo.jpg",
                    token = "123123"
                },
                new User()
                {
																				id = 2,
																				username = "Goku",
																				email = "goke@gmail.com",
																				firstName = "conan",
																				lastName = "Son",
																				gender = "Male",
																				image = "demo.jpg",
																				token = "123123"
																},
                new User()
                {
																				id = 3,
																				username = "Doremon",
																				email = "Doremon@gmail.com",
																				firstName = "Doremon",
																				lastName = "Nobita",
																				gender = "Female",
																				image = "demo.jpg",
																				token = "123123"
																}
            });
        }
    }
}
