using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(PasswordChangeInputValidator))]
	public class PasswordChangeInput : LogicInput
	{
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
	}

	public class PasswordChangeOutput : LogicOutput { }

	public class PasswordChangeInputValidator : AbstractValidator<PasswordChangeInput>
	{
		public PasswordChangeInputValidator()
		{
			RuleFor(t => t.OldPassword)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.OLD_PASSWORD));

			RuleFor(t => t.NewPassword)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.PASSWORD))
				.MinimumLength(8).WithMessage(x => string.Format(Resource.MINIMUMLENGTH, Resource.PASSWORD, 8))
				.Matches("[A-Z]").WithMessage(x => Resource.UPPERCASE)
				.Matches("[a-z]").WithMessage(x => Resource.LOWERCASE)
				.Matches("[0-9]").WithMessage(x => Resource.ISDIGIT);
		}
	}
}
