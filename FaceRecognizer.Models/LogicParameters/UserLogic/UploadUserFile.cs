using FaceRecognizer.Common.Resources;
using FluentValidation;
using FluentValidation.Attributes;
using System.Net.Http;


namespace FaceRecognizer.Models.LogicParameters.UserLogic
{
	[Validator(typeof(UploadUserFileInputValidator))]
	public class UploadUserFileInput : LogicInput
	{
		public int UserId { get; set; }
		public byte UserFileTypeId { get; set; }
		public string FileName { get; set; }
		public byte[] RawData { get; set; }
	}

	public class UploadUserFileRequestInput : LogicInput
	{
		public HttpRequestMessage Request { get; set; }
	}

	public class UploadUserFileOutput : LogicOutput { }

	public class UploadUserFileInputValidator : AbstractValidator<UploadUserFileInput>
	{
		public UploadUserFileInputValidator()
		{
			RuleFor(t => t.FileName)
				.NotEmpty().WithMessage(x => string.Format(Resource.NOTEMPTY, Resource.FILENAME))
				.Length(3, 500).WithMessage(x => string.Format(Resource.LENGTH, Resource.FILENAME, 3, 500));
		}
	}
}
