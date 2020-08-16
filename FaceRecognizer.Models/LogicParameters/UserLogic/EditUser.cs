using FaceRecognizer.Common.Resources;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using System.Web.UI.MobileControls.Adapters.XhtmlAdapters;

namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(EditUserInputValidator))]
	public class EditUserInput : LogicInput
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public string DocumentNumber { get; set; }
		public string DocumentPin { get; set; }
		public Doctype DocType { get; set; }
		public string Contact { get; set; }
		public byte UserStatusId { get; set; }
	}
	public class EditUserOutput : LogicOutput { }

	public class EditUserInputValidator : AbstractValidator<EditUserInput>
	{
		public EditUserInputValidator()
		{
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
