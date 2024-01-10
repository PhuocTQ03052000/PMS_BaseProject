using AutoMapper;
using PMS.HealthCare.HeartRate.DTO;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.Configuration
{
				public class AutoMapperConfig : Profile
				{
								public AutoMapperConfig() 
								{
												// Config for differnt property name (Khác tên nhưng vẫn mapping được data)
												CreateMap<UserDTO, User>().ReverseMap().ForMember(n => n.FirstName, otp => otp.MapFrom(x => x.firstName));
								}
				}
}
