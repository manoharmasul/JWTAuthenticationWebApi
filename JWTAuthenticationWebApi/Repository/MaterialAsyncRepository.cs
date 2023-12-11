using JWTAuthenticationWebApi.Context;
using JWTAuthenticationWebApi.Model;
using JWTAuthenticationWebApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthenticationWebApi.Repository
{
    public class MaterialAsyncRepository: IMaterialAsyncRepository
    {
        private readonly MyContext context;
        public MaterialAsyncRepository(MyContext context)
        {
            this.context = context; 
        }

        public async Task<int> AddNewMaterial(RawMaterials material)
        {
            var query= context.AddAsync<RawMaterials>(material);
            var result=await context.SaveChangesAsync();    

            return result;  
        }

        public Task<int> DeleteMaterial(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RawMaterials>> GetAllRawMaterials()
        {
            var materials = context.Materials.Where(x => x.IsDeleted == false).ToListAsync();
            return materials;
        }

        public Task<RawMaterials> GetRawMaterialsById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMaterial(RawMaterials material)
        {
            throw new NotImplementedException();
        }
    }
}
