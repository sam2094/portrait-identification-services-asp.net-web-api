using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum OperationTypes : byte
    {
        [EnumDescription("Yeni satış")]
        NEW_SALE = 1,
        [EnumDescription("Addan-ada keçirilmə")]
        NAME_TRANSITION,
        [EnumDescription("Nömrənin kopyalanması (dublikatı)")]
        NUMBER_DUPLICATE,
        [EnumDescription("Nömrənin daşınması")]
        NUMBER_SHIPPING,
        [EnumDescription("Nömrənin deaktiv edilməsi")]
        NUMBER_DEACTIVATION
    }
}
