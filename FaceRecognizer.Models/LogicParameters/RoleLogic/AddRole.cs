using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	[Validator(typeof(AddRoleInputValidator))]
	public class AddRoleInput : LogicInput
	{
		public int RoleGroupId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Level { get; set; }
		public List<int> ClaimIds { get; set; }
	}

	public class AddRoleOutput : LogicOutput { }

	public class AddRoleInputValidator : AbstractValidator<AddRoleInput>
	{
		public AddRoleInputValidator()
		{
			RuleFor(t => t.Name)
				 .Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.NAME, 2, 100));

			RuleFor(t => t.Description)
				.Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.DESCRIPTION, 2, 250));
		}
	}
}
