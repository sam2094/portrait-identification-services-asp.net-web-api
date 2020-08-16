using FaceRecognizer.Common.Resources;
using FaceRecognizer.Models.DTOs.UserDtos;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(LoginUserInputValidator))]
	public class LoginMobileUserInput : LogicInput
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public int Pin { get; set; }
	}

	public class LoginMobileUserOutput : LogicOutput
	{
		public LoginMobileUserDto User { get; set; }
	}

	public class LoginUserInputValidator : AbstractValidator<LoginMobileUserInput>
	{
		public LoginUserInputValidator()
		{
			RuleFor(t => t.Username)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.USERNAME))
				.Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, Resource.USERNAME, 2, 50));

			RuleFor(t => t.Password)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.PASSWORD));

			RuleFor(x => x.Pin)
				.NotNull()
				.WithMessage(string.Format(Resource.IS_REQUIRED, Resource.DOCUMENT_PİN))
				.GreaterThan(999)
				.WithMessage(string.Format(Resource.GREATER_THAN, Resource.DOCUMENT_PİN, 999))
				.LessThan(10000)
				.WithMessage(string.Format(Resource.LESS_THAN, Resource.DOCUMENT_PİN, 10000));

		}
	}
}
