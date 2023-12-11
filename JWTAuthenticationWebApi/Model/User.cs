using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationWebApi.Model
{
    [Table("tblUser")]
    public class User:BaseModel
    {
        //Id,UserName,EmailId,MobileNo,	
        //CreatedBy,CreatedDate,ModifiedBy,
        //ModifiedDate,IsDeleted

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
    }

    
    public class UserLogInModel
    {
        //Id,UserName,EmailId,MobileNo,	
        //CreatedBy,CreatedDate,ModifiedBy,
        //ModifiedDate,IsDeleted

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
