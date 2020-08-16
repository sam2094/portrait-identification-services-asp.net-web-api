using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace FaceRecognizer.Common.Helpers
{
	public static class JwtParser
	{
		public static string GetUserName(string token)
		{
			try
			{
				var handler = new JwtSecurityTokenHandler();
				var tokenS = handler.ReadToken(token) as JwtSecurityToken;
				string result = tokenS.Claims.FirstOrDefault(claim => claim.Type == "").Value;
				return result;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
