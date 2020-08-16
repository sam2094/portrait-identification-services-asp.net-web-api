using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums
{
    public enum DocumentTypes : byte
    {
        [EnumDescription("Şəxsiyyət vəsiqəsi")]
        ID_CARDS = 1,
        [EnumDescription("Müvəqqəti yaşayış icazəsi")]
        TEMPORARY_RESIDENCE_PERMIT,
        [EnumDescription("Daimi yaşayış icazəsi")]
        PERMANENT_RESIDENCE_PERMIT,
        [EnumDescription("Ümumvətəndaşlıq pasportu")]
        NATIONAL_PASSPORT,
        [EnumDescription("Əcnəbi vətəndaşların xarici pasportu")]
        FOREIGN_PASSPORTS_OF_FOREIGN_CITIZENS,
        [EnumDescription("Vətəndaşlığı olmayan şəxsin şəxsiyyət vəsiqəsi")]
        IDENTITY_CARD_OF_STATELESS_PERSON,
        [EnumDescription("Əcnəbi vətəndaşların qaçqın vəsiqəsi")]
        REFUGEE_ID_OF_FOREIGN_CITIZENS,
        [EnumDescription("Virtual İdentifikasiya Nömrəsi")]
        VIRTUAL_IDENTIFICATION_NUMBER
    }
}
