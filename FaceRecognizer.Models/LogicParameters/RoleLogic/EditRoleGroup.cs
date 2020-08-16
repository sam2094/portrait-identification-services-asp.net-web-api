using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic

{
	[Validator(typeof(EditRoleGroupInputValidator))]
	public class EditRoleGroupInput : LogicInput
	{
		public int RoleGroupId { get; set; }
		public string Name { get; set; }
	}

	public class EditRoleGroupOutput : LogicOutput { }

	public class EditRoleGroupInputValidator : AbstractValidator<EditRoleGroupInput>
	{
		public EditRoleGroupInputValidator()
		{
			RuleFor(t => t.Name)
				 .Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.NAME, 2, 100));
		}
	}

}
