using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.Models.Entities;
using FaceRecognizer.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using FaceRecognizer.Common.Helpers;
using FaceRecognizer.BusinessLogic.Logic.Cache;
using FaceRecognizer.Common.Enums.DatabaseEnums.ClaimEnums;
using FaceRecognizer.Common.Enums.DatabaseEnums;

namespace FaceRecognizer.BusinessLogic.Cache
{
	public class TokenCache
	{
		private Dictionary<string, TokenSessionInfo> dictionary;
		private static readonly object _lock = new object();

		private TokenCache() { }
		static TokenCache()
		{
			Instance = new TokenCache
			{
				dictionary = new Dictionary<string, TokenSessionInfo>(StringComparer.OrdinalIgnoreCase)
			};
			DateTime date = DateTime.Now;
			List<Token> tokenList = new Repository<Token>(new MyDbContext()).GetAll(x => x.ExpireDate > date && x.TokenStatusId == (byte)TokenStatuses.ACTIVE, i => i.User.Role.Claims).ToList();

			tokenList.ForEach(t => Instance.Add(t.Value, new TokenSessionInfo { UserId = t.UserId, ExpireDate = t.ExpireDate, Claims = t.User.Role.Claims.ToList() }));
		}

		public static TokenCache Instance { get; private set; }

		public void Add(string key, TokenSessionInfo sessionInfo)
		{
			lock (_lock)
			{
				if (dictionary.Values.Any(x => x.UserId == sessionInfo.UserId))
					Remove(sessionInfo.UserId);
				dictionary.Add(key, sessionInfo);
			}
		}

		private void Remove(int value)
		{
			KeyValuePair<string, TokenSessionInfo> keyValuePair = dictionary.FirstOrDefault(x => x.Value.UserId == value);
			if (!keyValuePair.Equals(default(KeyValuePair<string, int>)))
				dictionary.Remove(keyValuePair.Key);
		}

		public bool CheckByToken(string token, Claims claim)
		{
			lock (_lock)
			{
				if (dictionary.ContainsKey(token))
				{
					if (dictionary[token].ExpireDate >= DateTime.Now)
					{
						if (dictionary[token].Claims.Any(c => c.Name == claim.ToString())) return true;
					}
					else dictionary.Remove(token);
				}
				return false;
			}
		}

		public string GetToken()
		{
			lock (_lock)
			{
				return Hashing.GetSha512HashData(Guid.NewGuid().ToString("N"));
			}
		}
	}
}
