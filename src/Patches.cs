using Harmony;
using UnityEngine;

namespace HouseBasements
{
	class Patches
	{
		[HarmonyPatch(typeof(GameManager), "Awake")]
		internal class GameManager_Awake
		{
			public const string PATH = "assets/custom/mods/housebasements/";
			public static void Postfix()
			{
				string scene = GameManager.m_ActiveScene;
				
				if (scene == "AshCanyonRegion")
				{
					//1
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementsashcanyon.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "CoastalRegion")
				{
					//4
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementscoastalhighway.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "MountainTownRegion")
				{
					//6
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementsmountaintown.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "RuralRegion")
				{
					//2
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementspleasantvalley.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
			}
		}
	}
}
