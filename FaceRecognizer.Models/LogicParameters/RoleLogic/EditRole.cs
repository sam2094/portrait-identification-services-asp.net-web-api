using FaceRecognizer.Common.Enums.CommonEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.Models.LogicParameters.RoleLogic
{
	[Validator(typeof(EditRoleInputValidator))]
	public class EditRoleInput : LogicInput
	{
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Level { get; set; }
		public List<int> ClaimIds { get; set; }
	}

	public class EditRoleOutput : LogicOutput { }

	public class EditRoleInputValidator : AbstractValidator<EditRoleInput>
	{
		public EditRoleInputValidator()
		{
			RuleFor(t => t.Name)
				 .Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.NAME, 2, 100));

			RuleFor(t => t.Description)
				.Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.DESCRIPTION, 2, 250));
		}
	}
}
