using ModSettings;

namespace HouseBasements;

internal class Settings : JsonModSettings
{
	internal static Settings Instance { get; } = new();

	[Name("Disable Basements")]
	[Description("Don't disable this while you're inside a basement. It could drop you out of the world.")]
	public bool disableBasements = false;

	private GameObject? basements;

	public GameObject? Basements
	{
		get => basements;
		set
		{
			basements = value;
			basements?.SetActive(!disableBasements);
		}
	}

	protected override void OnConfirm()
	{
		base.OnConfirm();
		basements?.SetActive(!disableBasements);
	}
}
