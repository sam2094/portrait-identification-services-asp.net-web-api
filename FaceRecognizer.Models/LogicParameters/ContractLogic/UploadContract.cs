using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System.Net.Http;

namespace FaceRecognizer.Models.LogicParameters.ContractLogic
{
	[Validator(typeof(UploadContractInputValidator))]
	public class UploadContractInput : LogicInput
	{
		public int ContractId { get; set; }
		public byte ContractFileTypeId { get; set; }
		public string FileName { get; set; }
		public byte[] RawData { get; set; }
	}

	public class UploadContractRequestInput : LogicInput
	{
		public HttpRequestMessage Request { get; set; }
	}

	public class UploadContractOutput : LogicOutput { }

	public class UploadContractInputValidator : AbstractValidator<UploadContractInput>
	{
		public UploadContractInputValidator()
		{
			RuleFor(t => t.FileName)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.FILENAME))
				.Length(3, 500).WithMessage(x => string.Format(Resource.LENGTH, Resource.FILENAME, 3, 500));
		}
	}
}
