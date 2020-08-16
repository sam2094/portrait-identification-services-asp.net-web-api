using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using FaceRecognizer.Common.Enums.DatabaseEnums.RoleEnums;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.Common.Resources;
using FaceRecognizer.DataAccess.UnitofWork;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.Models.LogicParameters.OrganizationLogic;
using System;
using System.IO;

namespace FaceRecognizer.BusinessLogic.Logic.OrganizationLogic
{
	public class EditOrganization : Logic<EditOrganizationInput, EditOrganizationOutput>
	{
		public EditOrganization(IUnitofWork uow,
				string firstExecutedLogicName,
				bool beginTransaction = false) : base(uow, firstExecutedLogicName, beginTransaction) { }

		private static readonly object _lock = new object();
		public override void DoExecute()
		{
			User currentUser = _uow.GetRepository<User>().Get(x => x.Id == Parameters.CurrentUserId, i => i.Role, i => i.Branch);
			bool isSuperAdmin = currentUser.RoleId == (int)Roles.SUPER_ADMIN ? true : false;

			if (!isSuperAdmin)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ACCESS_DENIED,
					ErrorMessage = Resource.ACCESS_DENIED,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			Organization organization = _uow.GetRepository<Organization>().Get(x => x.Id == Parameters.Id);

			if (organization == null)
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ORGANIZATION_DOES_NOT_EXIST,
					ErrorMessage = Resource.ORGANIZATION_DOES_NOT_EXIST,
					StatusCode = ErrorHttpStatus.NOT_FOUND
				});
				return;
			}

			if (_uow.GetRepository<Organization>().IsExist(x => x.Name.ToUpper().Trim() == Parameters.Name.ToUpper().Trim() && x.Id != organization.Id))
			{
				Result.ErrorList.Add(new Error
				{
					ErrorCode = ErrorCodes.ORGANIZATION_NAME_IS_EXIST,
					ErrorMessage = Resource.ORGANIZATION_NAME_IS_EXIST,
					StatusCode = ErrorHttpStatus.FORBIDDEN
				});
				return;
			}

			if (Parameters.Photo != null && Parameters.Photo.Length != 0)
			{
				string photoName = string.Empty;
				lock (_lock)
				{
					photoName = string.Concat(Guid.NewGuid().ToString("N"), ".jpg");
				}
				File.WriteAllBytes(Path.Combine(ConfigHelper.GetAppSetting("Photo"), photoName), Parameters.Photo);
				organization.Photo = photoName;
			}

			organization.Name = Parameters.Name;
			organization.Contact = Parameters.Contact;
			organization.Description = Parameters.Description;
			organization.IsActive = Parameters.IsActive;
			_uow.SaveChanges();
		}
	}
}
