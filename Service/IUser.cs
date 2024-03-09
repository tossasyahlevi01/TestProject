using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Service
{
    public interface IUser
    {
        public Task<(bool Error, GeneralResponses GetUser)> listUser();
        public Task<(bool Error, GeneralResponses GetUser)> Logon(UserLogonDTO Entity);
        public Task<(bool Error, GeneralResponses GetUser)> GetDetailUser(string UserId);
        public Task<(bool Error, GeneralResponses GetUser)> InsertUser(UserDTO Entity);
        public Task<(bool Error, GeneralResponses GetUser)> UpdateUser(UserDTO Entity);

        public Task<(bool Error, GeneralResponses GetUser)> DeleteUser(string UserId);



    }
}
