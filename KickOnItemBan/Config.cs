using System;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;

namespace KickOnItemBan
{
	class Config
	{
		public int MaxTimeLeft = 10;

		public string CountDownMessage = "Take it off or you will be kicked. Time left: {0}";

		private static string configpath = Path.Combine(TShock.SavePath, "KickOnItemBan.json");

		public static Config ReadConfig()
		{
			Config config = new Config();

			if (File.Exists(configpath))
			{
				config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configpath));
			}
			else
			{
				try
				{
					File.WriteAllText(configpath, JsonConvert.SerializeObject(config, Formatting.Indented));
					TShock.Log.ConsoleInfo("Created " + configpath);
				}
				catch (Exception ex)
				{
					TShock.Log.ConsoleError(ex.Message);
				}
			}

			return config;
		}
	}
}
