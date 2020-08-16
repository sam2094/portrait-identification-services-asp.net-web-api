using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.BusinessLogic.Logic.Cache
{
	public class PinCache
	{
		private Dictionary<int, PinSessionInfo> dictionary;
		private static readonly object _lock = new object();

		private PinCache() { }

		static PinCache()
		{

			Instance = new PinCache
			{
				dictionary = new Dictionary<int, PinSessionInfo>()
			};
		}

		public static PinCache Instance { get; private set; }

		public void Add(int key, PinSessionInfo sessionInfo)
		{
			lock (_lock)
			{
				if (dictionary.Keys.Any(x => x == key))
					dictionary.Remove(key);
				dictionary.Add(key, sessionInfo);
			}
		}

		public bool Check(int key, int pin)
		{
			lock (_lock)
			{
				if (dictionary.ContainsKey(key))
				{
					if (dictionary[key].ExpireDate >= DateTime.Now
						&& dictionary[key].Pin == pin
						&& dictionary[key].Attempt <= 3
						&& !dictionary[key].IsUsed)
					{
						dictionary[key].IsUsed = true;
						Remove(key);
						return true;
					}
				}
				return false;
			}
		}

		public void Remove(int key)
		{
			if (dictionary.ContainsKey(key))
				dictionary.Remove(key);
		}

		public void AddAttempt(int key)
		{
			lock (_lock)
			{
				if (dictionary.ContainsKey(key))
					dictionary[key].Attempt += 1;
			}
		}

		public int GetPin()
		{
			lock (_lock)
			{
				return new Random().Next(1000, 9999);
			}
		}
	}
}
