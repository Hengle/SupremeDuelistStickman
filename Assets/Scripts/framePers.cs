using System.Globalization;
using UnityEngine;

public class framePers : MonoBehaviour
{
	public float avgFrameRate;

	public TextMesh TextFps;

	public string DevideIde;

	public int numAffichage;

	private void Start()
	{
		TextFps = base.gameObject.GetComponent<TextMesh>();
		if (numAffichage == 0)
		{
			TextFps.text = Application.systemLanguage.ToString();
		}
		if (numAffichage == 1)
		{
			TextFps.text = SystemLanguage.English.ToString();
		}
		if (numAffichage == 2)
		{
			TextFps.text = RegionInfo.CurrentRegion.NativeName.ToString();
		}
		if (numAffichage == 3)
		{
			TextFps.text = RegionInfo.CurrentRegion.ThreeLetterISORegionName.ToString();
		}
		if (numAffichage == 4)
		{
			TextFps.text = RegionInfo.CurrentRegion.TwoLetterISORegionName.ToString();
		}
	}

	private void Update()
	{
	}
}
