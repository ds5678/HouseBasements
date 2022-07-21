extern alias Hinterland;
using HarmonyLib;
using Hinterland;

namespace HouseBasements
{
	[HarmonyPatch(typeof(GameManager), "Awake")]
	internal class GameManager_Awake
	{
		private const string BundlePathToPrefabs = "assets/custom/mods/housebasements/";
		public static void Postfix()
		{
			Settings.Instance.Basements = GameManager.m_ActiveScene switch
			{
				"AshCanyonRegion" => InstantiateBasements("housebasementsashcanyon.prefab"),//1
				"CoastalRegion" => InstantiateBasements("housebasementscoastalhighway.prefab"),//4
				"MountainTownRegion" => InstantiateBasements("housebasementsmountaintown.prefab"),//6
				"RuralRegion" => InstantiateBasements("housebasementspleasantvalley.prefab"),//3
				_ => null,
			};
		}

		private static GameObject InstantiateBasements(string prefabName)
		{
			return Object.Instantiate(Implementation.LoadedAssetBundle.LoadAsset($"{BundlePathToPrefabs}{prefabName}")).Cast<GameObject>();
		}
	}
}
