using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationWebApi.Model
{
    [Table("tblMaterial")]
    public class RawMaterials:BaseModel
    {
        //Id	MaterialName
        //	UnitType	UnitQty	CreatedBy
        //		CreateDate	ModifiedBy	
        //		ModifiedDate	IsDeleted
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int UnitType { get; set; }
        public int UnitQty { get; set; }

    }
}
