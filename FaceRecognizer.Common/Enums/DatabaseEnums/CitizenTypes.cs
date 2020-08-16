using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum CitizenTypes
    {
        [EnumDescription("Azerbaijani")]
        AZERBAIJANI = 1,
        [EnumDescription("Permanent resident")]
        PERMANENT_RESIDENT,
        [EnumDescription("Temporary resident")]
        TEMPORARY_RESIDENT
    }
}
