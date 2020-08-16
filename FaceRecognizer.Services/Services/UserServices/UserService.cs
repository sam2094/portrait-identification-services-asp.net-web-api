using FaceRecognizer.BusinessLogic.Logic.UserLogic;
using FaceRecognizer.Models;
using FaceRecognizer.Models.LogicParameters.UserLogic;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Common.FileManager;
using FaceRecognizer.Common.ConfigManager;
using FaceRecognizer.Models.LogicParameters.UserStatusLogic;
using FaceRecognizer.BusinessLogic.Logic.UserStatusLogic;
using System.Threading.Tasks;
using FaceRecognizer.BusinessLogic.Logic.ContractLogic;

namespace FaceRecognizer.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitofWork _uow;
        private readonly IFileOperations _fileOperations;
        private readonly IConfigOperations _configOperation;

        public UserService(
            IUnitofWork uow,
            IFileOperations fileOperations,
            IConfigOperations configOperation
            )
        {
            _uow = uow;
            _fileOperations = fileOperations;
            _configOperation = configOperation;
        }

        public LogicResult<CreateUserOutput> CreateUser(CreateUserInput input)
            => new CreateUser(_uow, nameof(CreateUser)).Execute(parameters: input);

        public LogicResult<EditUserOutput> EditUser(EditUserInput input)
            => new EditUser(_uow, nameof(EditUser)).Execute(parameters: input);

        public LogicResult<GetUsersOutput> GetUsers(GetUsersInput input)
            => new GetUsers(_uow, nameof(GetUsers)).Execute(parameters: input);

        public LogicResult<LoginMobileUserOutput> LoginMobileUser(LoginMobileUserInput input)
            => new LoginMobileUser(_uow, nameof(LoginMobileUser)).Execute(parameters: input);

        public LogicResult<LoginUserOutput> LoginUser(LoginUserInput input)
            => new LoginUser(_uow, nameof(LoginUser)).Execute(parameters: input);

        public LogicResult<LoginCheckOutput> LoginChecker(LoginCheckInput input)
            => new LoginCheck(_uow, nameof(LoginChecker)).Execute(parameters: input);

		public LogicResult<GetUserByIdOutput> GetUserById(GetUserByIdInput input)
	        => new GetUserById(_uow, _fileOperations, _configOperation, nameof(GetUserById)).Execute(parameters: input);

		public LogicResult<PasswordChangeOutput> PasswordChange(PasswordChangeInput input)
            => new PasswordChange(_uow, nameof(PasswordChange)).Execute(parameters: input);

        public LogicResult<PasswordResetOutput> PasswordReset(PasswordResetInput input)
            => new PasswordReset(_uow, nameof(PasswordReset)).Execute(parameters: input);

		public LogicResult<GetUserStatusesOutput> GetUserStatuses()
		   => new GetUserStatuses(_uow, nameof(GetUserStatuses)).Execute();

		public async Task<LogicResult<UploadUserFileOutput>> UploadUserFileAsync(UploadUserFileRequestInput input)
		=> await new UploadUserFile(_uow, nameof(UploadUserFileAsync)).ExecuteAsync(parameters: input);

		public LogicResult<DownloadUserFileOutput> DownloadUserFile(DownloadUserFileInput input)
		=> new DownloadUserFile(_uow, nameof(DownloadUserFile)).Execute(parameters: input);

		public LogicResult<GetUserFileTypesOutput> GetUserFileTypes()
		 => new GetUserFileTypes(_uow, nameof(GetUserFileTypes)).Execute();
    }
}
