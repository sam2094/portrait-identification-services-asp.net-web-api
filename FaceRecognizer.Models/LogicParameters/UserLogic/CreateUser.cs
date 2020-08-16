using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.MobileControls.Adapters.XhtmlAdapters;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(CreateUserInputValidator))]
	public class CreateUserInput : LogicInput
	{
		public int BranchId { get; set; }
		public byte UserStatusId { get; set; }
		public byte RoleId { get; set; }
		public string DocumentNumber { get; set; }
		public string DocumentPin { get; set; }
		public Doctype DocType { get; set; }
		public string Contact { get; set; }
		public string Username { get; set; }
		public bool IsFaceRecognized { get; set; }
	}

	public class CreateUserOutput : LogicOutput { }

	public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
	{
		public CreateUserInputValidator()
		{
			RuleFor(t => t.Username)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.USERNAME))
				.Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, Resource.USERNAME, 2, 50));

			RuleFor(t => t.DocumentPin)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.DOCUMENT_PİN))
				.Length(5, 10).WithMessage(x => string.Format(Resource.LENGTH, Resource.DOCUMENT_PİN, 5, 10));

			RuleFor(t => t.DocumentNumber)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.DOCUMENT_NUMBER))
				.Length(5, 20).WithMessage(x => string.Format(Resource.LENGTH, Resource.DOCUMENT_NUMBER, 5, 20));

			RuleFor(t => t.Contact)
			   .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));
		}
	}
}
