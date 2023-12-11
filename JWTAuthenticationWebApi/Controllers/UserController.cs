using JWTAuthenticationWebApi.Model;
using JWTAuthenticationWebApi.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTAuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAsyncRepository userAsync;
        private IConfiguration _config;
        public UserController(IUserAsyncRepository userAsync, IConfiguration config)
        {
            this.userAsync = userAsync;
            _config = config;   
        }
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(User user)
        {
            BaseResponseModel baseResponse=new BaseResponseModel();
            try
            {
                var result = await userAsync.AddNewUser(user);



                if (result > 0)
                {
                    baseResponse.StatusMassage = $"User Added Successfully...!";
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"Something Is Worng Please Check..!";
                    return Ok(baseResponse);
                }
            }
            catch (Exception ex)
            {
                baseResponse.StatusMassage=ex.Message;
                return Ok(baseResponse);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> UserLogIn([FromBody] UserLogInModel loginRequest)
        {
            BaseResponseModel baseResponse=new BaseResponseModel();
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token
            var result=await userAsync.UserLogInRepostory(loginRequest);

            if(result!=null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                baseResponse.StatusMassage = $"User Log In Successfully....!";

                baseResponse.ResponseData=token;

                return Ok(baseResponse);

            }
            else
            {
                baseResponse.StatusMassage = $"User Log In faild..!";
                return Ok(baseResponse);
            }

    
        }
    }
}
