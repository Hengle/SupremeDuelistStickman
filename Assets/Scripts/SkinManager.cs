using UnityEngine;

public class SkinManager : MonoBehaviour
{
	public SkinBleu[] skinB;

	public SkinRouge[] skinR;

	public GameManager Gmanaj;

	public int SkinMaskNumber;

	public int limitNumber;

	public int SkinAssetNumber;

	public GameObject VerrouBleu;

	public GameObject VerrouRouge;

	private void Start()
	{
		Gmanaj = GameObject.Find("GameManager").GetComponent<GameManager>();
		Gmanaj = GameObject.Find("GameManager").GetComponent<GameManager>();
		Invoke("DataSkin", 0.1f);
		InvokeRepeating("activeSkin", 0.2f, 0.2f);
	}

	private void Update()
	{
	}

	private void DataSkin()
	{
		int i = 0;
		SkinMaskNumber = Gmanaj.SkinNumber;
		SkinBleu[] array = skinB = Resources.FindObjectsOfTypeAll<SkinBleu>();
		SkinRouge[] array2 = skinR = Resources.FindObjectsOfTypeAll<SkinRouge>();
		for (; SkinMaskNumber - (int)Mathf.Pow(2f, i) >= 0; i++)
		{
			limitNumber = (int)Mathf.Pow(2f, i);
		}
		for (int j = 0; j < skinB.Length; j++)
		{
			SkinAssetNumber = j;
			CheckAvailableSkin();
		}
	}

	private void activeSkin()
	{
		Gmanaj.ResetMenuScreen = true;
		for (int i = 0; i < skinB.Length; i++)
		{
			if (Gmanaj.CharCustomize)
			{
				if (skinB[i].gameObject.GetComponent<SpriteRenderer>().enabled)
				{
					VerrouBleu.SetActive(!skinB[i].Accessible);
				}
				if (skinR[i].gameObject.GetComponent<SpriteRenderer>().enabled)
				{
					VerrouRouge.SetActive(!skinR[i].Accessible);
				}
			}
		}
	}

	private void CheckAvailableSkin()
	{
		int num = limitNumber;
		int num2 = SkinMaskNumber;
		int num3 = limitNumber;
		int num4 = SkinMaskNumber;
		while (num > 0)
		{
			if (num2 - num >= 0)
			{
				if ((int)Mathf.Pow(2f, skinB[SkinAssetNumber].UnlockNum) == num)
				{
					skinB[SkinAssetNumber].Accessible = true;
				}
				num2 -= num;
			}
			num /= 2;
			if (num4 - num3 >= 0)
			{
				if ((int)Mathf.Pow(2f, skinR[SkinAssetNumber].UnlockNum) == num3)
				{
					skinR[SkinAssetNumber].Accessible = true;
				}
				num4 -= num3;
			}
			num3 /= 2;
		}
	}
}
