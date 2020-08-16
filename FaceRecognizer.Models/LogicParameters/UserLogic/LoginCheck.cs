using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(LoginCheckInputValidator))]
	public class LoginCheckInput : LogicInput
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class LoginCheckOutput : LogicOutput { }

	public class LoginCheckInputValidator : AbstractValidator<LoginCheckInput>
	{
		public LoginCheckInputValidator()
		{
			RuleFor(t => t.Username)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.USERNAME))
				.Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, Resource.USERNAME, 2, 50));

			RuleFor(t => t.Password)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.PASSWORD));
		}
	}
}