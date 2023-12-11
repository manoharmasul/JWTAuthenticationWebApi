using JWTAuthenticationWebApi.Model;

namespace JWTAuthenticationWebApi.Repository.Interface
{
    public interface IMaterialAsyncRepository
    {
        Task<int> AddNewMaterial(RawMaterials material);
        Task<int> UpdateMaterial(RawMaterials material);
        Task<List<RawMaterials>> GetAllRawMaterials();
        Task<RawMaterials> GetRawMaterialsById(int Id);
        Task<int> DeleteMaterial(int Id);
    }
}
