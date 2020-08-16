using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum Citizenships
    {
        [EnumDescription("Vətəndaş")]
        CITIZEN = 1,
        [EnumDescription("Vətəndaşlığı olmayan")]
        NON_CITIZEN, 
        [EnumDescription("Əcnəbi")]
        FOREIGNER
    }
}
