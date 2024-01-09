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
												CreateMap<ResponseDataDTO, ResponseData>().ReverseMap().ForMember(n => n.Title, otp => otp.MapFrom(x => x.title));
								}
				}
}
