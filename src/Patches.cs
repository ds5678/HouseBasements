using Harmony;
using UnityEngine;

namespace HouseBasements
{
	class Patches
	{
		[HarmonyPatch(typeof(GameManager), "Awake")]
		internal class EmptyScene6
		{
			public static void Postfix()
			{
				string scene = GameManager.m_ActiveScene;
				bool sceneIsRegion = GameManager.m_ActiveSceneIsRegion;
				Implementation.Log("Awake {0} {1}", scene, sceneIsRegion);
				if (scene == "AshCanyonRegion")
				{
					//1
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset("assets/housebasementsashcanyon.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "CoastalRegion")
				{
					//4
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset("assets/housebasementscoastalhighway.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "MountainTownRegion")
				{
					//6
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset("assets/housebasementsmountaintown.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
				else if (scene == "RuralRegion")
				{
					//2
					Settings.basements = GameObject.Instantiate(Implementation.assetBundle.LoadAsset("assets/housebasementspleasantvalley.prefab")).Cast<GameObject>();
					Settings.SetBasementVisibility();
				}
			}
		}
	}
}
