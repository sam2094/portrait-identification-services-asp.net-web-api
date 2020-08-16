using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums
{
    public enum Roles
    {
        [EnumDescription("Super Admin")]
        SUPER_ADMIN = 1,

        [EnumDescription("Admin")]
        ADMIN,

        [EnumDescription("Branch")]
        DEALER,

        [EnumDescription("Operator")]
        OPERATOR,

        [EnumDescription("Mix")]
        MIX
    }
}
