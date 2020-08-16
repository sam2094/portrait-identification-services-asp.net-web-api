using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum ContractStatuses : byte
    {
        [EnumDescription("New")]
        NEW = 1,
        [EnumDescription("Approved")]
        APPROVED,
        [EnumDescription("Canceled")]
        CANCELED,
        [EnumDescription("Archived")]
        ARCHIVED
    }
}
