extern alias Hinterland;
using Hinterland;
using UnhollowerBaseLib;

namespace HouseBasements;

internal static class RerollCommand
{
	internal static void RegisterCommand()
	{
		uConsole.RegisterCommand("house_basements_reroll_interiors", new System.Action(RerollBasementInteriors));
	}
	
	private static void RerollBasementInteriors()
	{
		if (Settings.Instance.Basements == null)
		{
			uConsole.Log("|  Error: Current scene does not contain any modded basements.");
			return;
		}

		Il2CppArrayBase<RandomSpawnObject> spawners = Settings.Instance.Basements.GetComponentsInChildren<RandomSpawnObject>();

		for (int i = 0; i < spawners.Length; i++)
		{
			RerollSpawner(spawners[i]);
		}

		uConsole.Log($"|  Successfully rerolled {spawners.Length} basements!");
	}
	
	private static void RerollSpawner(RandomSpawnObject spawner)
	{
		// First disable all objects spawned by this spawner
		spawner.DisableAll();

		// Then re-enable some, moving around the spawner to modify the seed that ActivateRandomObject uses
		Vector3 oldPos = spawner.transform.localPosition;

		try
		{
			spawner.transform.Translate(Random.onUnitSphere);
			spawner.ActivateRandomObject();
		}
		finally
		{
			spawner.transform.localPosition = oldPos;
		}
	}
}