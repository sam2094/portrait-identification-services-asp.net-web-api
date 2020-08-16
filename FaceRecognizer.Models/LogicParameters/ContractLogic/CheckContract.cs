using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	[Validator(typeof(CheckContractInputValidator))]
	public class CheckContractInput : LogicInput
	{
		public string DocumentPin { get; set; }
		public string PhoneNumber { get; set; }
		public int DocumentTypeId { get; set; }
	}

	public class CheckContractOutput : LogicOutput
	{
		public int ContractId { get; set; }
	}

	public class CheckContractInputValidator : AbstractValidator<CheckContractInput>
	{
		public CheckContractInputValidator()
		{
			RuleFor(t => t.DocumentPin)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.DOCUMENT_PİN))
				.Length(5, 10).WithMessage(x => string.Format(Resource.LENGTH, Resource.DOCUMENT_PİN, 5, 10));

			RuleFor(t => t.PhoneNumber)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));
		}
	}
}
