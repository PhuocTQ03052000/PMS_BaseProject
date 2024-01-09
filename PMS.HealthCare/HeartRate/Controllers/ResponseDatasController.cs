using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Controllers
{
				[Route("api/[controller]")]
				[ApiController]
				public class ResponseDatasController : ControllerBase
				{
								private readonly HttpClient _httpClient;
								private readonly IMapper _mapper;

								public ResponseDatasController(IMapper mapper)
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
								[ProducesResponseType(StatusCodes.Status500InternalServerError)]
								public async Task<ActionResult<ResponseData>> GetCurrentAuthUser()
								{
												try
												{
																var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTUsInVzZXJuYW1lIjoia21pbmNoZWxsZSIsImVtYWlsIjoia21pbmNoZWxsZUBxcS5jb20iLCJmaXJzdE5hbWUiOiJKZWFubmUiLCJsYXN0TmFtZSI6IkhhbHZvcnNvbiIsImdlbmRlciI6ImZlbWFsZSIsImltYWdlIjoiaHR0cHM6Ly9yb2JvaGFzaC5vcmcvSmVhbm5lLnBuZz9zZXQ9c2V0NCIsImlhdCI6MTcwNDc5OTUyNiwiZXhwIjoxNzA0ODAzMTI2fQ.aeGfHeyG198VgEhmCZfFduzoPXrMZLklAZcfvfYEsM4";
																_httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
																// get Api thông qua phương thức GetAsync của HttpClient
																var response = await _httpClient.GetAsync("https://dummyjson.com/auth/me");
																

																

																// kiểm tra trạng thái khi get API
																if (response.IsSuccessStatusCode)
																{
																				// hiển thị data dưới dạng string json
																				var responseData = await response.Content.ReadAsStringAsync();

																				var item = new ResponseData();

																				//// convert sang object
																				//var obj = JsonConvert.DeserializeObject(responseData);

																				//// lấy data những trường cần hiển thị thông qua mapper
																				//var data = _mapper.Map<List<ResponseData>>(obj);

																				// trả về kết quả
																				return Ok(item);
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
				}
}
