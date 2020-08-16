using FaceRecognizer.Common.Attributes;

namespace FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums
{
	public enum Claims : int
	{
		// User
		[EnumDescription("Yeni istifadəçi əlavə edə bilər")]
		CAN_REGISTER_USER = 1,

		[EnumDescription("İstifadəçinin məlumatlarını yeniləyə bilər")]
		CAN_EDIT_USER,

		[EnumDescription("İdentifikasiya nömrəsinə görə istifadəçinin məlumatlarını əldə edə bilər")]
		CAN_GET_USER_BY_ID,

		[EnumDescription("İstifadəçilərin siyahısını əldə edə bilər")]
		CAN_GET_USERS,

		[EnumDescription("İstifadəçi statuslarının siyahısını əldə edə bilər")]
		CAN_GET_USER_STATUSES,

		[EnumDescription("İstifadəçi fayl növlərinin siyahısını əldə edə bilər")]
		CAN_GET_USER_FILE_TYPES,

		[EnumDescription("İstifadəçi faylını yükləyə bilər")]
		CAN_UPLOAD_USER_FILE,

		[EnumDescription("İstifadəçi faylını endirə bilər")]
		CAN_DOWNLOAD_USER_FILE,

		[EnumDescription("İstifadəçinin şifrəsini yeniləyə bilər")]
		CAN_RESET_USER_PASSWORD,

		[EnumDescription("Şifrəni dəyişə bilər")]
		CAN_CHANGE_PASSWORD,

		// Contract
		[EnumDescription("Müqavilə əlavə edə bilər")]
		CAN_ADD_CONTRACT,

		[EnumDescription("Müqavilə statusunu yeniləyə bilər")]
		CAN_UPDATE_CONTRACT_STATUS,

		[EnumDescription("İdentifikasiya nömrəsinə görə müqavilənin məlumatlarını əldə edə bilər")]
		CAN_GET_CONTRACT,

		[EnumDescription("Müqavilələrin siyahısını əldə edə bilər")]
		CAN_GET_CONTRACTS,

		[EnumDescription("Müqaviləni yoxlaya bilər")]
		CAN_CHECK_CONTRACT,

		[EnumDescription("Müqavilə faylını yükləyə bilər")]
		CAN_DOWNLOAD_CONTRACT,

		[EnumDescription("Müqavilə faylını yükləyə bilər")]
		CAN_UPLOAD_CONTRACT,

		[EnumDescription("Müqavilə statuslarının siyahısını əldə edə bilər")]
		CAN_GET_CONTRACT_STATUSES,

		[EnumDescription("Müqavilə fayl növlərinin siyahısını əldə edə bilər")]
		CAN_GET_CONTRACT_FILE_TYPES,

		[EnumDescription("Sənəd növlərinin siyahısını əldə edə bilər")]
		CAN_GET_DOCUMENT_TYPES,

		[EnumDescription("Əməliyyat növlərinin siyahısını əldə edə bilər")]
		CAN_GET_OPERATION_TYPES,

		[EnumDescription("Abunə növlərinin siyahısını əldə edə bilər")]
		CAN_GET_SUBSCRIPTION_TYPES,

		[EnumDescription("Tariflərin siyahısını əldə edə bilər")]
		CAN_GET_TARIFS,

		[EnumDescription("Vətəndaşlıq növlərinin siyahısını əldə edə bilər")]
		CAN_GET_CITIZENSHIP_TYPES,

		// Branch
		[EnumDescription("Filial əlavə edə bilər")]
		CAN_ADD_BRANCH,

		[EnumDescription("Filialın məlumatlarını yeniləyə bilər")]
		CAN_EDIT_BRANCH,

		[EnumDescription("Filialların siyahısını əldə edə bilər")]
		CAN_GET_ALL_BRANCH,

		[EnumDescription("İdentifikasiya nömrəsinə görə filialın məlumatlarını əldə edə bilər")]
		CAN_GET_BRANCH_BY_ID,

		// Role 
		[EnumDescription("Rol əlavə edə bilər")]
		CAN_ADD_ROLE,

		[EnumDescription("Rolun məlumatlarını və hüquqlarını yeniləyə bilər")]
		CAN_EDIT_ROLE,

		[EnumDescription("Rolların siyahısını əldə edə bilər")]
		CAN_GET_ROLES,

		[EnumDescription("Rol qrupu əlavə edə bilər")]
		CAN_ADD_ROLE_GROUP,

		[EnumDescription("Rol qrupun məlumatlarını yeniləyə bilər")]
		CAN_EDIT_ROLE_GROUP,

		[EnumDescription("Rol qrupların siyahısını əldə edə bilər")]
		CAN_GET_ROLE_GROUPS,

		// Organization
		[EnumDescription("Qurum əlavə edə bilər")]
		CAN_ADD_ORGANIZATION,

		[EnumDescription("Qurumun məlumatlarını yeniləyə bilər")]
		CAN_EDIT_ORGANIZATION,

		[EnumDescription("Qurumların siyahısını əldə edə bilər")]
		CAN_GET_ORGANIZATIONS,

		// Region
		[EnumDescription("Bölgələrin siyahısını əldə edə bilər")]
		CAN_GET_REGIONS,

		// Claim
		[EnumDescription("Hüquqların siyahısını əldə edə bilər")]
		CAN_GET_CLAIMS,
	}
}
