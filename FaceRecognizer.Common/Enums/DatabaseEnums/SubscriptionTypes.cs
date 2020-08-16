using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum SubscriptionTypes : byte
    {
        [EnumDescription("Fakturalı xətt")]
        INVOICE = 1,
        [EnumDescription("Fakturasız xətt")]
        NON_INVOICE
    }
}
