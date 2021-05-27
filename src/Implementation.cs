using MelonLoader;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace HouseBasements
{
	public static class BuildInfo
	{
		public const string Name = "HouseBasements"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "A mod to add a few more basements to the game."; // Description for the Mod.  (Set as null if none)
		public const string Author = "The Long Development"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	public class Implementation : MelonMod
	{
		internal static AssetBundle assetBundle = LoadEmbeddedAssetBundle("HouseBasements.res.housebasements");
		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
			//ListContents(assetBundle);
			Settings.instance.AddToModSettings("House Basements");
		}
		internal static void Log(string message, params object[] parameters) => MelonLogger.Log(message, parameters);

		private static AssetBundle LoadEmbeddedAssetBundle(string path)
		{
			MemoryStream memoryStream;

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
			{
				memoryStream = new MemoryStream((int)stream.Length);
				stream.CopyTo(memoryStream);
			}
			if (memoryStream.Length == 0)
			{
				throw new System.Exception("No data loaded!");
			}
			return AssetBundle.LoadFromMemory(memoryStream.ToArray());
		}

		private static void ListContents(AssetBundle assetBundle)
		{
			foreach (string name in assetBundle.GetAllAssetNames())
			{
				Log(name);
			}
		}
	}
}
