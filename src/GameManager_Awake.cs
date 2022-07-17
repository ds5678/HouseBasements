using HarmonyLib;
using UnityEngine;

namespace HouseBasements
{
	[HarmonyPatch(typeof(GameManager), "Awake")]
	internal class GameManager_Awake
	{
		public const string PATH = "assets/custom/mods/housebasements/";
		public static void Postfix()
		{
			string scene = GameManager.m_ActiveScene;

			switch (scene)
			{
				case "AshCanyonRegion":
					//1
					Settings.basements = Object.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementsashcanyon.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
					break;
				case "CoastalRegion":
					//4
					Settings.basements = Object.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementscoastalhighway.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
					break;
				case "MountainTownRegion":
					//6
					Settings.basements = Object.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementsmountaintown.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
					break;
				case "RuralRegion":
					//3
					Settings.basements = Object.Instantiate(Implementation.assetBundle.LoadAsset(PATH + "housebasementspleasantvalley.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
					break;
			}
		}
	}
}
