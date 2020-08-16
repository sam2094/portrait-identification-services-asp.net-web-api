using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FaceRecognizer.Models.LogicParameters.UserStatusLogic;
using System.Threading.Tasks;

namespace FaceRecognizer.Services.Services.UserServices
{
    public interface IUserService
    {
        LogicResult<CreateUserOutput> CreateUser(CreateUserInput input);
        LogicResult<LoginMobileUserOutput> LoginMobileUser(LoginMobileUserInput input);
        LogicResult<LoginUserOutput> LoginUser(LoginUserInput input);
        LogicResult<LoginCheckOutput> LoginChecker(LoginCheckInput input);
        LogicResult<GetUsersOutput> GetUsers(GetUsersInput input);
        LogicResult<EditUserOutput> EditUser(EditUserInput input);
        LogicResult<GetUserByIdOutput> GetUserById(GetUserByIdInput input);
        LogicResult<PasswordChangeOutput> PasswordChange(PasswordChangeInput input);
        LogicResult<PasswordResetOutput> PasswordReset(PasswordResetInput input);
		LogicResult<GetUserStatusesOutput> GetUserStatuses();
		Task<LogicResult<UploadUserFileOutput>> UploadUserFileAsync(UploadUserFileRequestInput input);
		LogicResult<DownloadUserFileOutput> DownloadUserFile(DownloadUserFileInput input);
		LogicResult<GetUserFileTypesOutput> GetUserFileTypes();
	}
}
