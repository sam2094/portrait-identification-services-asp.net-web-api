﻿using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;

namespace FaceRecognizer.Models.LogicParameters.OrganizationLogic
{
	[Validator(typeof(AddOrganizationtInputValidator))]
	public class AddOrganizationInput : LogicInput
	{
		public string Name { get; set; }
		public string Contact { get; set; }
		public string Description { get; set; }
		public byte[] Photo { get; set; }
		public bool IsActive { get; set; }
	}

	public class AddOrganizationOutput : LogicOutput
	{
	}

	public class AddOrganizationtInputValidator : AbstractValidator<AddOrganizationInput>
	{
		public AddOrganizationtInputValidator()
		{
			RuleFor(t => t.Name)
				.Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.NAME, 2, 100));

			RuleFor(t => t.Description)
				.Length(2, 150).WithMessage(x => string.Format(Resource.LENGTH, Resource.DESCRIPTION, 2, 250));

			RuleFor(t => t.Contact)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.CONTACT_NUMBER))
				 .Matches("^(50|51|55|70|77)[2-9][0-9]{6}$").WithMessage(x => string.Format(Resource.INVALID_NUMBER_FORMAT));
		}
	}
}
