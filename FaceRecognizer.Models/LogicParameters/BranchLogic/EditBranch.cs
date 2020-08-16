using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.BranchLogic
{
	[Validator(typeof(EditBranchInputValidator))]
	public class EditBranchInput : LogicInput
	{
		public int BranchId { get; set; }
		public string PlaceName { get; set; }
		public string PlaceAddress { get; set; }
		public string ContactNumber { get; set; }
		public string Email { get; set; }
	}

	public class EditBranchOutput : LogicOutput
	{

	}
	public class EditBranchInputValidator : AbstractValidator<EditBranchInput>
	{
		public EditBranchInputValidator()
		{
			RuleFor(t => t.PlaceName)
			   .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.PLACE_NAME))
			   .Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, Resource.PLACE_NAME, 2, 50));

			RuleFor(t => t.PlaceAddress)
			   .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.PLACE_ADDRESS))
			   .Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, Resource.PLACE_ADDRESS, 2, 50));

			RuleFor(t => t.ContactNumber)
				 .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));

			RuleFor(t => t.Email).NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.EMAİL))
				.EmailAddress().WithMessage(Resource.EMAIL_IS_NOT_VALID);
		}
	}
}
