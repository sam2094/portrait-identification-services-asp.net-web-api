using FaceRecognizer.Common.Attributes;


namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
	public enum UserFileTypes : byte
	{
		[EnumDescription("Elektron imza üçün ərizə forması")]
		E_SIGNATURE_APPLICATION_FORM = 1,

		[EnumDescription("Elektron imza üçün müqavilə")]
		E_SIGNATURE_CONTRACT,
	}
}
