using JWTAuthenticationWebApi.Model;
using JWTAuthenticationWebApi.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialsController : ControllerBase
    {
        private readonly IMaterialAsyncRepository materialAsync;
        public RawMaterialsController(IMaterialAsyncRepository materialAsync)
        {
            this.materialAsync = materialAsync;
        }
        [Authorize]
        [HttpPost("AddRawMaterials")]
        public async Task<IActionResult> AddRawMaterials(RawMaterials materials)
        {
            BaseResponseModel baseResponse = new BaseResponseModel();

           var result=await materialAsync.AddNewMaterial(materials);
            if(result>0)
            {
                baseResponse.StatusMassage = $"Material Added Successfully...!";
                baseResponse.ResponseData = result;
                return Ok(baseResponse);
            }
            else
            {
                baseResponse.StatusMassage = $"Something is wrong..!";
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetAllRawMaterials")]
        public async Task<IActionResult> GetAllRawMaterials()
        {
            BaseResponseModel baseResponse = new BaseResponseModel();

            var result = await materialAsync.GetAllRawMaterials();
            if (result.Count() > 0)
            {
                baseResponse.StatusMassage = $"Material Data Fetch Successfully...!";
                baseResponse.ResponseData = result;
                return Ok(baseResponse);
            }
            else
            {
                baseResponse.StatusMassage = $"Materials are not available..!";
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetRawMaterialsById")]
        public async Task<IActionResult> GetRawMaterialsById(int Id)
        {
            BaseResponseModel baseResponse = new BaseResponseModel();

            var result = await materialAsync.GetRawMaterialsById(Id);
            if (result!=null)
            {
                baseResponse.StatusMassage = $"Material Data Fetch Successfully...!";
                baseResponse.ResponseData = result;
                return Ok(baseResponse);
            }
            else
            {
                baseResponse.StatusMassage = $"Materials are not available..! with Id {Id}";
                return Ok(baseResponse);
            }
        }
        [HttpPut("UpdateMaterials")]
        public async Task<IActionResult> UpdateMaterials(RawMaterials materials)
        {
            BaseResponseModel baseResponse=new BaseResponseModel();
            var result=await materialAsync.UpdateMaterial(materials);
           if(result>0)
           {
                baseResponse.StatusMassage = $"Material updated successfully....!";
                baseResponse.ResponseData = result;
                return Ok(baseResponse);
           }
           else
           {
                baseResponse.StatusMassage = $"Something is wrong....!";
                return Ok(baseResponse);
           }
        }
    }
}
