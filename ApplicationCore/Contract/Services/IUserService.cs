using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contract.Services;

public interface IUserService
{
    int AddUser(UserRequestModel model);
    int UpdateUser(UserRequestModel model, int id);
    int DeleteUser(int id);
    UserResponseModel GetUserById(int id);
    IEnumerable<UserResponseModel> GetAllUsers();
}