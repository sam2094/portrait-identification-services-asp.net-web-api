using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System.Web.UI.MobileControls.Adapters.XhtmlAdapters;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	[Validator(typeof(AddContractInputValidator))]
	public class AddContractInput : LogicInput
	{
		public byte DocumentTypeId { get; set; }
		public byte OperationTypeId { get; set; }
		public byte TarifId { get; set; }
		public byte CitizenshipId { get; set; }
		public int BranchId { get; set; }
		public string DocumentPin { get; set; }
		public string DocumentNumber { get; set; }
		public Doctype DocType { get; set; }
		public string Phone { get; set; }
		public string DeliveryAddress { get; set; }
		public string Contact { get; set; }
		public string Email { get; set; }
		public long IMSI { get; set; }
		public long ICCID { get; set; }
		public bool IsSendEmail { get; set; }
		public bool IsSendAddress { get; set; }
		public bool IsExplanatoryContracts { get; set; }
		public bool IsRefrainAdvertising { get; set; }
	}

	public class AddContractOutput : LogicOutput
	{
		public int ContractId { get; set; }
	}

	public class AddContractInputValidator : AbstractValidator<AddContractInput>
	{
		public AddContractInputValidator()
		{
			RuleFor(t => t.DocumentPin)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.DOCUMENT_PİN))
				.Length(5, 10).WithMessage(x => string.Format(Resource.LENGTH, Resource.DOCUMENT_PİN, 5, 10));

			RuleFor(t => t.DocumentNumber)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.DOCUMENT_NUMBER))
				.Length(5, 20).WithMessage(x => string.Format(Resource.LENGTH, Resource.DOCUMENT_NUMBER, 5, 20));

			RuleFor(t => t.DeliveryAddress)
				.Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.DELIVERY_ADDRESS, 2, 150));

			RuleFor(t => t.Email).NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.EMAİL))
				.EmailAddress().WithMessage(Resource.EMAIL_IS_NOT_VALID);

			RuleFor(t => t.Contact)
			   .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));

			RuleFor(t => t.Phone)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));
		}
	}
}
