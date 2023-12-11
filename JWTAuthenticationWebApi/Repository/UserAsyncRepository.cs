using JWTAuthenticationWebApi.Context;
using JWTAuthenticationWebApi.Model;
using JWTAuthenticationWebApi.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

namespace JWTAuthenticationWebApi.Repository
{
    public class UserAsyncRepository:IUserAsyncRepository
    {
        private readonly MyContext context;
        public UserAsyncRepository(MyContext context) 
        {
            this.context = context;
        }

        public async Task<int> AddNewUser(User user)
        {
              var query=await context.AddAsync(user);
             var result=await context.SaveChangesAsync();
           
            
            /*var parameters = new SqlParameter[]
            {
        new SqlParameter("@UserName",    user.UserName),
        new SqlParameter("@EmailId",      user.EmailId),
        new SqlParameter("@MobileNo",     user.MobileNo),
        new SqlParameter("@CreatedBy",   user.CreatedBy),
        new SqlParameter("@CreatedDate", user.CreatedDate),
        new SqlParameter("@ModifiedBy",    user.ModifiedBy),
        new SqlParameter("@ModifiedDate", user.ModifiedDate),
        new SqlParameter("@IsDeleted",    user.IsDeleted),
                // Add more parameters as needed
            };

            var result = await context.Database.ExecuteSqlRawAsync(@"EXEC AddNewEmployee @UserName,@EmailId,@MobileNo,
                                                                    @CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate,@IsDeleted", parameters);*/
            return result;
        }

        public Task<int> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLogInModel> UserLogInRepostory(UserLogInModel user)
        {


            var result = context.Users
                .Where(x => x.UserName == user.UserName && x.Password == user.Password)
                .Select(x => new UserLogInModel
                {
                    UserName = x.UserName,
                    Password = x.Password,
                    // Include other properties you want to retrieve
                })
                .FirstOrDefault();      

            return result;

        }
    }
}
