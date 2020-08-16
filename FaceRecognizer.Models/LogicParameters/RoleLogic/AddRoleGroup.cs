using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	[Validator(typeof(AddRoleGroupInputValidator))]
	public class AddRoleGroupInput : LogicInput
	{
		public string Name { get; set; }
		public int OrganizationId { get; set; }
	}

	public class AddRoleGroupOutput : LogicOutput { }

	public class AddRoleGroupInputValidator : AbstractValidator<AddRoleGroupInput>
	{
		public AddRoleGroupInputValidator()
		{
			RuleFor(t => t.Name)
				 .Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.NAME, 2, 100));
		}
	}
}
