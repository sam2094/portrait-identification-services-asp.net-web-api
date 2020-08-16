using FaceRecognizer.Models.DTOs.ContractDtos;
using FluentValidation;
using System.Collections.Generic;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	//[Validator(typeof(GetContractsInputValidator))]
	public class GetContractsInput : LogicInput
    {
        public int OrganizationId { get; set; }
        public int BranchId { get; set; }
        public byte OperationTypeId { get; set; }
        public byte ContractStatusId { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentPin { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
		public int PageNumber { get; set; }
		public int DataCount { get; set; }
	}

    public class GetContractsOutput : LogicOutput
    {
        public List<ContractsDto> Contracts { get; set; }
		public int TotalDataCount { get; set; }
		public int PageCount { get; set; }
	}

	public class GetContractsInputValidator : AbstractValidator<GetContractsInput>
    {
        public GetContractsInputValidator()
        {
            //RuleFor(t => t.OperationTypeId)
            //     .LessThanOrEqualTo((byte)Enum.GetValues(typeof(OperationTypes)).Cast<OperationTypes>().Max())
            //     .WithMessage(x => string.Format(Resource.LESSTHANOREQUALTO, nameof(x.OperationTypeId), (byte)Enum.GetValues(typeof(OperationTypes)).Cast<OperationTypes>().Max()))
            //     .GreaterThanOrEqualTo((byte)Enum.GetValues(typeof(UserStatuses)).Cast<UserStatuses>().Min())
            //     .WithMessage(x => string.Format(Resource.GREATERTHANOREQUALTO, nameof(x.OperationTypeId), (byte)Enum.GetValues(typeof(UserStatuses)).Cast<UserStatuses>().Min()));

            //RuleFor(t => t.ContractStatusId)
            //     .LessThanOrEqualTo((byte)Enum.GetValues(typeof(ContractStatuses)).Cast<ContractStatuses>().Max())
            //     .WithMessage(x => string.Format(Resource.LESSTHANOREQUALTO, nameof(x.ContractStatusId), (byte)Enum.GetValues(typeof(ContractStatuses)).Cast<ContractStatuses>().Max()))
            //     .GreaterThanOrEqualTo((byte)Enum.GetValues(typeof(ContractStatuses)).Cast<ContractStatuses>().Min())
            //     .WithMessage(x => string.Format(Resource.GREATERTHANOREQUALTO, nameof(x.ContractStatusId), (byte)Enum.GetValues(typeof(ContractStatuses)).Cast<ContractStatuses>().Min()));

            //RuleFor(t => t.DocumentPin)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.DocumentPin)))
            //    .Length(5, 10).WithMessage(x => string.Format(Resource.LENGTH, nameof(x.DocumentPin), 5, 10));

            //RuleFor(t => t.DocumentNumber)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.DocumentNumber)))
            //    .Length(5, 20).WithMessage(x => string.Format(Resource.LENGTH, nameof(x.DocumentNumber), 5, 20));

            //RuleFor(t => t.Name)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.Name)))
            //    .Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, nameof(x.Name), 2, 50));

            //RuleFor(t => t.Surname)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.Surname)))
            //    .Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, nameof(x.Surname), 2, 50));

            //RuleFor(t => t.Patronymic)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.Patronymic)))
            //    .Length(2, 50).WithMessage(x => string.Format(Resource.LENGTH, nameof(x.Patronymic), 2, 50));

            //RuleFor(t => t.PhoneNumber)
            //    .NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, nameof(x.PhoneNumber)))
            //    .Length(12).WithMessage(x => string.Format(Resource.CONCRETE_LENGTH, nameof(x.PhoneNumber), 12))
            //    .Matches(ConfigHelper.GetAppSetting("RegularExpressionPhone")).WithMessage(x => string.Format(Resource.INVALID, nameof(x.PhoneNumber)));
        }
    }
}