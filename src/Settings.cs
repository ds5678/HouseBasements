using ModSettings;
using UnityEngine;

namespace HouseBasements
{
	internal class Settings : JsonModSettings
	{
		internal readonly static Settings instance = new Settings();
		internal static GameObject basements;

		[Name("Disable Basements")]
		[Description("Don't disable this while you're inside a basement. It could drop you out of the world.")]
		public bool disableBasements = false;

		internal static void SetBasementVisibility()
		{
			if (basements == null) return;
			else basements.SetActive(!instance.disableBasements);
		}

		protected override void OnConfirm()
		{
			base.OnConfirm();
			SetBasementVisibility();
		}
	}
}
