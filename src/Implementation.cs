using MelonLoader;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace HouseBasements
{
	public class Implementation : MelonMod
	{
		internal static AssetBundle assetBundle;
		public override void OnApplicationStart()
		{
			assetBundle = LoadEmbeddedAssetBundle("HouseBasements.res.housebasements");
#if DEBUG
			ListContents(assetBundle);
#endif
			Settings.instance.AddToModSettings("House Basements");
		}

		private static AssetBundle LoadEmbeddedAssetBundle(string path)
		{
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
			{
				MemoryStream memoryStream = new MemoryStream((int)stream.Length);
				stream.CopyTo(memoryStream);
				return memoryStream.Length != 0
					? AssetBundle.LoadFromMemory(memoryStream.ToArray())
					: throw new System.Exception("No data loaded!");
			}
		}

		private void ListContents(AssetBundle assetBundle)
		{
			foreach (string name in assetBundle.GetAllAssetNames())
			{
				LoggerInstance.Msg(name);
			}
		}
	}
}
