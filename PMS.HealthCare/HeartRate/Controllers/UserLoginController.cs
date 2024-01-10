using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PMS.HealthCare.HeartRate.Data;
using PMS.HealthCare.HeartRate.Models;

namespace PMS.HealthCare.HeartRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
								private readonly HttpClient _httpClient;
								private readonly IMapper _mapper;
								private static string _token;

								public UserLoginController(IMapper mapper)
        {
												_httpClient = new HttpClient();
												_mapper = mapper;
								}

        [HttpPost]
        [Route("/login-user", Name = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> LoginUser()
        {
            try
            {
                // Tạo đối tượng JSON chứa tên người dùng và mật khẩu
                var requestBody = new
                {
                    username = "kminchelle",
                    password = "0lelplR"
                };

                // Chuyển đổi đối tượng JSON thành chuỗi JSON
                string jsonBody = JsonConvert.SerializeObject(requestBody);

                // Tạo đối tượng StringContent với chuỗi JSON
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST với nội dung phần thân
                var response = await _httpClient.PostAsync("https://dummyjson.com/auth/login", content);

                // kiểm tra trạng thái khi get API
                if (response.IsSuccessStatusCode)
                {
                    // hiển thị data dưới dạng string json
                    var responseData = await response.Content.ReadAsStringAsync();

                    // convert sang object
                    var obj = JsonConvert.DeserializeObject<User>(responseData);

                    _token = obj?.token;

                    return Ok(obj);

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

        [HttpGet]
        [Route("/auth-user", Name = "GetCurrentAuthUser")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetCurrentAuthUser()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _token));

                // get Api thông qua phương thức GetAsync của HttpClient
                var response = await _httpClient.GetAsync("https://dummyjson.com/auth/me");

                // kiểm tra trạng thái khi get API
                if (response.IsSuccessStatusCode)
                {
                    // hiển thị data dưới dạng string json
                    var responseData = await response.Content.ReadAsStringAsync();

                    // convert sang object
                    var obj = JsonConvert.DeserializeObject<User>(responseData);

                    // trả về kết quả
                    return Ok(obj);
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

								[HttpPost]
								[Route("/form-data", Name = "ProcessFormData")]
								public async Task<IActionResult> ProcessFormData([FromForm] User user)
								{
												try
												{
																var username = user.username;
																var password = user.password;

																// Tạo chuỗi x-www-form-urlencoded
																var formContent = new FormUrlEncodedContent(new[]
																{
																				new KeyValuePair<string, string>("username", username),
																				new KeyValuePair<string, string>("password", password)
																});

																// Gửi yêu cầu POST với nội dung phần thân
																var response = await _httpClient.PostAsync("https://dummyjson.com/auth/login", formContent);

																// Kiểm tra trạng thái khi gọi API
																if (response.IsSuccessStatusCode)
																{
																				// Hiển thị dữ liệu dưới dạng chuỗi JSON
																				var responseData = await response.Content.ReadAsStringAsync();

																				// Chuyển đổi sang đối tượng
																				var obj = JsonConvert.DeserializeObject<User>(responseData);

																				// Trả về kết quả
																				return CreatedAtRoute("GetCurrentAuthUser", new { token = obj?.token }, obj);
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
