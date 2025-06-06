﻿using JWTAuthenticationWebApi.Context;
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
            material.IsDeleted = false;
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

        public async Task<RawMaterials> GetRawMaterialsById(int Id)
        {
            var materls=await context.Materials.Where(x=>x.Id==Id && x.IsDeleted==false).FirstOrDefaultAsync();
            return materls;
        }

        public async Task<int> UpdateMaterial(RawMaterials material)
        {
            int result = 0;
            var find = await context.Materials.FindAsync(material.Id);
            if (find != null)
            {
                var query = context.Update(find);
               result=await context.SaveChangesAsync();
            }

            return result;
        }
    }
}
