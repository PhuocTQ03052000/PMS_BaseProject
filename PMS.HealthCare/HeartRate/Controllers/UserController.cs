using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.HealthCare.HeartRate.DTO;
using PMS.HealthCare.HeartRate.Models;
using System.Text;

namespace PMS.HealthCare.HeartRate.Controllers
{
				[Route("api/[controller]")]
				[ApiController]
				public class UserController : ControllerBase
				{
								private readonly HttpClient _httpClient;
								private readonly IMapper _mapper;

								public UserController(IMapper mapper)
								{
												_httpClient = new HttpClient();
												_mapper = mapper;
								}

								//[HttpGet]
								//[ProducesResponseType(StatusCodes.Status500InternalServerError)]
								//public async Task<ActionResult<ResponseData>> GetDataFromExternalApi()
								//{
								//				try
								//				{
								//								// get Api thông qua phương thức GetAsync của HttpClient
								//								var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");

								//								// kiểm tra trạng thái khi get API
								//								if (response.IsSuccessStatusCode)
								//								{
								//												// hiển thị data dưới dạng string json
								//												var responseData = await response.Content.ReadAsStringAsync();

								//												// convert sang object
								//												var obj = JsonConvert.DeserializeObject(responseData);

								//												// lấy data những trường cần hiển thị thông qua mapper
								//												var data = _mapper.Map<List<ResponseData>>(obj);

								//												// trả về kết quả
								//												return Ok(data);
								//								}
								//								else
								//								{
								//												return StatusCode((int)response.StatusCode, "Error calling external API");
								//								}
								//				}
								//				catch (Exception ex)
								//				{
								//								return StatusCode(500, "Internal server error");
								//				}
								//}

								[HttpGet]
								[Route("GetCurrentAuthUser")]
								[ProducesResponseType(StatusCodes.Status500InternalServerError)]
								public async Task<ActionResult<User>> GetCurrentAuthUser()
								{
												try
												{
																User user = await GetTokenUserLogin();
												
																_httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", user.token));
																// get Api thông qua phương thức GetAsync của HttpClient
																var response = await _httpClient.GetAsync("https://dummyjson.com/auth/me");
																
																// kiểm tra trạng thái khi get API
																if (response.IsSuccessStatusCode)
																{
																				// hiển thị data dưới dạng string json
																				var responseUserData = await response.Content.ReadAsStringAsync();

																				// convert sang object
																				var obj = JsonConvert.DeserializeObject(responseUserData);

																				// lấy data những trường cần hiển thị thông qua mapper
																				var data = _mapper.Map<User>(obj);

																				// trả về kết quả
																				return Ok(data);
																}
																else
																{
																				return StatusCode((int)response.StatusCode, "Error calling external API");
																}
												}
												catch (Exception ex)
												{
																return StatusCode(500, "Internal server error");
												}
								}

								[NonAction]
								public async Task<User> GetTokenUserLogin()
								{
												// URL call đến API đối tượng user cần đăng nhập
												var url = "https://dummyjson.com/auth/login";
												// Thông tin tên người dùng và mật khẩu
												var json = "{\"username\":\"kminchelle\",\"password\":\"0lelplR\"}";

												var data = new StringContent(json, Encoding.UTF8, "application/json");

												//get API trong qua phương thức PostAsync của HttpClient
												var response = await _httpClient.PostAsync(url, data);
												var userData = new User();
												// kiểm tra trạng thái khi get API
												if (response.IsSuccessStatusCode)
												{
																// hiển thị data dưới dạng string json
																var responseUserData = await response.Content.ReadAsStringAsync();

																// convert sang object
																var obj = JsonConvert.DeserializeObject(responseUserData);

																// lấy data những trường cần hiển thị thông qua mapper
																userData = _mapper.Map<User>(obj);

												}
												// trả về kết quả
												return userData;
								}
				}
}
