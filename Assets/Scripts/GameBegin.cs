using System;
using UnityEngine;
using UnityEngine.UI;

public class GameBegin : MonoBehaviour
{
	public Rigidbody2D rbjoueur1;

	public Rigidbody2D rbjoueur2;

	public int count;

	public int MapSelection;

	public int RandomMap;

	public GameObject Background;

	public LineRenderer SwordCharge;

	public int TotalMap;

	public int minMap;

	public GameObject SurvivalMap;

	public GameObject Map1;

	public GameObject Map2;

	public GameObject Map3;

	public GameObject Map4;

	public GameObject Map5;

	public GameObject Map6;

	public GameObject Map7;

	public GameObject Map8;

	public GameObject Map9;

	public GameObject Map10;

	public GameObject Map11;

	public GameObject Map12;

	public GameObject Map13;

	public GameObject Map14;

	public GameObject Map15;

	public GameObject Map16;

	public GameObject Map17;

	public GameObject Map18;

	public GameObject Map19;

	public GameObject Map20;

	public GameObject Map21;

	public GameObject Map22;

	public GameObject Map23;

	public GameObject Map24;

	public GameObject Map25;

	public GameObject Map26;

	public GameObject Map27;

	public GameObject Map28;

	public GameObject Map29;

	public GameObject Map30;

	public GameObject Map31;

	public GameObject NuageSystem;

	public GameObject Soleil;

	private GameManager SkinChoose;

	public GameObject JoystickToErase;

	public GameObject Joystick1Base;

	public GameObject JoystickMoove;

	public GameObject JoystickDroiteToErase;

	public GameObject BarreGauche;

	public GameObject BarreDroite;

	public GameObject[] LimiteDeLaMap;

	public GameObject TwoPLayer;

	public GameObject Player1;

	public GameObject Player2;

	public GameObject ScoreGauche;

	public GameObject ScoreDroite;

	private void Start()
	{
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (SkinChoose.OnePlayer)
		{
			if (!SkinChoose.LeftUser)
			{
				JoystickToErase.SetActive(value: false);
				Joystick1Base.GetComponent<Image>().color = new Color(0f, 0f, 1f);
				JoystickMoove.GetComponent<Image>().color = new Color(0f, 1f, 1f, 0.3f);
			}
			else
			{
				JoystickDroiteToErase.SetActive(value: false);
			}
		}
		if (SkinChoose.Survival)
		{
			if (!SkinChoose.TwoPlayerSurvival)
			{
				minMap = -1;
				TotalMap = 0;
				GameObject.Find("Perso 2").SetActive(value: false);
			}
			else
			{
				minMap = -1;
				TotalMap = 0;
				Transform[] array = Resources.FindObjectsOfTypeAll<Transform>();
				TwoPLayer = GameObject.Find("Perso 2");
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].gameObject.layer == 11)
					{
						array[i].gameObject.layer = 8;
					}
					if (array[i].gameObject.layer == 12)
					{
						if (array[i].gameObject.GetComponent<AreaEffector2D>() != null)
						{
							if ((array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & 0x100) > 1)
							{
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & -257);
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask | 0x800);
							}
							if ((array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & 0x200) > 1)
							{
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & -513);
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask | 0x1000);
							}
							if ((array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & 0x40000) > 1)
							{
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask & -262145);
								array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask = (array[i].gameObject.GetComponent<AreaEffector2D>().colliderMask | 0x80000);
							}
						}
						if (array[i].gameObject.GetComponent<PointEffector2D>() != null)
						{
							if ((array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & 0x100) > 1)
							{
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & -257);
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask | 0x800);
							}
							if ((array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & 0x200) > 1)
							{
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & -513);
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask | 0x1000);
							}
							if ((array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & 0x40000) > 1)
							{
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask & -262145);
								array[i].gameObject.GetComponent<PointEffector2D>().colliderMask = (array[i].gameObject.GetComponent<PointEffector2D>().colliderMask | 0x80000);
							}
						}
						array[i].gameObject.layer = 9;
					}
					if (array[i].gameObject.layer == 19)
					{
						array[i].gameObject.layer = 18;
					}
				}
			}
		}
		rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
		rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
		if (!SkinChoose.Survival)
		{
			MapSelection = SkinChoose.map;
		}
		if (MapSelection == 21)
		{
			if (!SkinChoose.HealthBar)
			{
				do
				{
					RandomMap = UnityEngine.Random.Range(minMap, 32);
					UnityEngine.Debug.Log("Random Sans HP");
				}
				while (RandomMap == 21 || RandomMap == 22);
			}
			else
			{
				do
				{
					RandomMap = UnityEngine.Random.Range(minMap, 31);
				}
				while (RandomMap == 21);
			}
		}
		else if (!SkinChoose.Survival)
		{
			RandomMap = MapSelection;
		}
		else
		{
			minMap = -1;
			TotalMap = 0;
			RandomMap = UnityEngine.Random.Range(minMap, TotalMap);
		}
		if (RandomMap == -1)
		{
			SwordCharge.startColor = new Color(0.333333343f, 0.333333343f, 0.333333343f);
			SwordCharge.endColor = new Color(1f, 1f, 1f);
			SwordCharge.gameObject.transform.localScale = new Vector3(5f, 420f, 1f);
			for (int j = 0; j < LimiteDeLaMap.Length; j++)
			{
				LimiteDeLaMap[j].SetActive(value: false);
			}
			UnityEngine.Object.Instantiate(SurvivalMap);
		}
		else
		{
			if (SkinChoose.HealthBar)
			{
				BarreDroite.gameObject.SetActive(value: true);
				BarreGauche.gameObject.SetActive(value: true);
			}
			ScoreGauche.SetActive(value: true);
			ScoreDroite.SetActive(value: true);
			ScoreGauche.GetComponent<TextMesh>().text = SkinChoose.GaucheVictory.ToString();
			ScoreDroite.GetComponent<TextMesh>().text = SkinChoose.DroiteVictory.ToString();
		}
		if (SkinChoose.Outline1)
		{
			if (SkinChoose.skinColor == new Color(0f, 0f, 0f, 1f))
			{
				Articulation[] componentsInChildren = Player1.gameObject.GetComponentsInChildren<Articulation>();
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					componentsInChildren[k].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
		else
		{
			Articulation[] componentsInChildren2 = Player1.gameObject.GetComponentsInChildren<Articulation>();
			for (int l = 0; l < componentsInChildren2.Length; l++)
			{
				UnityEngine.Object.Destroy(componentsInChildren2[l].gameObject);
			}
		}
		if (SkinChoose.Outline2)
		{
			if (SkinChoose.skinColor2 == new Color(0f, 0f, 0f, 1f))
			{
				Articulation[] componentsInChildren3 = Player2.gameObject.GetComponentsInChildren<Articulation>();
				for (int m = 0; m < componentsInChildren3.Length; m++)
				{
					componentsInChildren3[m].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
				}
			}
		}
		else
		{
			Articulation[] componentsInChildren4 = Player2.gameObject.GetComponentsInChildren<Articulation>();
			for (int n = 0; n < componentsInChildren4.Length; n++)
			{
				UnityEngine.Object.Destroy(componentsInChildren4[n].gameObject);
			}
		}
		if (RandomMap == 0)
		{
			SwordCharge.startColor = new Color(41f / 255f, 142f / (339f * (float)Math.PI), 142f / (339f * (float)Math.PI));
			SwordCharge.endColor = new Color(40f / 51f, 0.5882353f, 0.5882353f);
			UnityEngine.Object.Instantiate(Map1);
		}
		if (RandomMap == 1)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(0.5882353f, 0.5882353f, 32f / 51f);
			UnityEngine.Object.Instantiate(Map2);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
		}
		if (RandomMap == 2)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map3);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 3)
		{
			SwordCharge.startColor = new Color(10f / 51f, 28f / 51f, 10f / 51f);
			SwordCharge.endColor = new Color(20f / 51f, 20f / 51f, 20f / 51f);
			UnityEngine.Object.Instantiate(Map4);
		}
		if (RandomMap == 4)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map5);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 5)
		{
			SwordCharge.startColor = new Color(0.7f, 0.7f, 0.7f);
			SwordCharge.endColor = new Color(0.4f, 0.4f, 0.8f);
			UnityEngine.Object.Instantiate(Map16);
		}
		if (RandomMap == 6)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map7);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 7)
		{
			SwordCharge.startColor = new Color(0f, 0.4f, 0f);
			SwordCharge.endColor = new Color(0.8f, 0.8f, 0.8f);
			UnityEngine.Object.Instantiate(Map8);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 8)
		{
			SwordCharge.endColor = new Color(40f / 51f, 20f / 51f, 0.8235294f);
			SwordCharge.startColor = new Color(71f / (339f * (float)Math.PI), 10f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map9);
		}
		if (RandomMap == 9)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map10);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 10)
		{
			SwordCharge.startColor = new Color(10f / 51f, 28f / 51f, 10f / 51f);
			SwordCharge.endColor = new Color(20f / 51f, 20f / 51f, 20f / 51f);
			UnityEngine.Object.Instantiate(Map11);
		}
		if (RandomMap == 11)
		{
			SwordCharge.endColor = new Color(1f, 16f / 51f, 20f / 51f);
			SwordCharge.startColor = new Color(76f / 255f, 16f / 255f, 14f / 51f);
			UnityEngine.Object.Instantiate(Map12);
		}
		if (RandomMap == 12)
		{
			SwordCharge.startColor = new Color(10f / 51f, 28f / 51f, 10f / 51f);
			SwordCharge.endColor = new Color(0.7f, 0.2f, 0.5f);
			UnityEngine.Object.Instantiate(Map13);
		}
		if (RandomMap == 13)
		{
			SwordCharge.endColor = new Color(10f / 51f, 38f / 51f, 10f / 51f);
			SwordCharge.startColor = new Color(0.8f, 0.1f, 0.3f);
			UnityEngine.Object.Instantiate(Map17);
		}
		if (RandomMap == 14)
		{
			SwordCharge.startColor = new Color(0.6f, 0.6f, 0.6f);
			SwordCharge.endColor = new Color(0.7f, 0.7f, 0.7f);
			UnityEngine.Object.Instantiate(Map15);
		}
		if (RandomMap == 15)
		{
			SwordCharge.startColor = new Color(0f, 0f, 0.3f);
			SwordCharge.endColor = new Color(0.8f, 0.9f, 1f);
			UnityEngine.Object.Instantiate(Map6);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 16)
		{
			LimiteDeLaMap[2].gameObject.transform.Translate(new Vector3(0f, 5f, 0f), Space.Self);
			SwordCharge.startColor = new Color(0f, 0.4f, 0f);
			SwordCharge.endColor = new Color(0.8f, 0.8f, 0.8f);
			UnityEngine.Object.Instantiate(Map14);
		}
		if (RandomMap == 17)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.117647059f, 10f / 51f);
			SwordCharge.endColor = new Color(0.5882353f, 20f / 51f, 20f / 51f);
			UnityEngine.Object.Instantiate(Map18);
		}
		if (RandomMap == 18)
		{
			SwordCharge.startColor = new Color(14f / 51f, 14f / 51f, 2f / 3f);
			SwordCharge.endColor = new Color(40f / 51f, 0.5882353f, 38f / 51f);
			UnityEngine.Object.Instantiate(Map19);
		}
		if (RandomMap == 19)
		{
			SwordCharge.startColor = new Color(41f / 255f, 142f / (339f * (float)Math.PI), 142f / (339f * (float)Math.PI));
			SwordCharge.endColor = new Color(40f / 51f, 0.5882353f, 0.5882353f);
			UnityEngine.Object.Instantiate(Map20);
		}
		if (RandomMap == 20)
		{
			SwordCharge.startColor = new Color(20f / 51f, 20f / 51f, 20f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 0.5882353f, 0.5882353f);
			UnityEngine.Object.Instantiate(Map21);
		}
		if (RandomMap == 22)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(0f, 52f / 85f, 0.333333343f);
			UnityEngine.Object.Instantiate(Map22);
		}
		if (RandomMap == 23)
		{
			SwordCharge.startColor = new Color(0.3f, 0.2f, 0.6f);
			SwordCharge.endColor = new Color(0f, 0.63f, 0.58f);
			UnityEngine.Object.Instantiate(Map23);
			NuageSystem.SetActive(value: true);
			Soleil.SetActive(value: true);
			Soleil.transform.Translate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f), Space.World);
		}
		if (RandomMap == 24)
		{
			SwordCharge.startColor = new Color(0.3f, 0.2f, 0.8f);
			SwordCharge.endColor = new Color(0.8f, 0.8f, 0.8f);
			UnityEngine.Object.Instantiate(Map24);
		}
		if (RandomMap == 25)
		{
			SwordCharge.startColor = new Color(0.7f, 0.2f, 0.9f);
			SwordCharge.endColor = new Color(0f, 0.7f, 0.8f);
			UnityEngine.Object.Instantiate(Map25);
		}
		if (RandomMap == 26)
		{
			SwordCharge.startColor = new Color(0.3f, 0.4f, 1f);
			SwordCharge.endColor = new Color(0.3f, 0.7f, 0.2f);
			UnityEngine.Object.Instantiate(Map26);
		}
		if (RandomMap == 27)
		{
			NuageSystem.SetActive(value: true);
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map27);
		}
		if (RandomMap == 28)
		{
			SwordCharge.startColor = new Color(0.2f, 0.4f, 0.9f);
			SwordCharge.endColor = new Color(0.6f, 0.7f, 0.9f);
			SwordCharge.gameObject.transform.localScale = new Vector3(50f, 548f, 1f);
			SwordCharge.gameObject.transform.position = new Vector3(11f, 116f, 27.9f);
			for (int num = 0; num < LimiteDeLaMap.Length; num++)
			{
				LimiteDeLaMap[num].SetActive(value: false);
			}
			UnityEngine.Object.Instantiate(Map28);
		}
		if (RandomMap == 29)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.117647059f, 10f / 51f);
			SwordCharge.endColor = new Color(0.5882353f, 20f / 51f, 20f / 51f);
			for (int num2 = 0; num2 < LimiteDeLaMap.Length; num2++)
			{
				LimiteDeLaMap[num2].SetActive(value: false);
			}
			UnityEngine.Object.Instantiate(Map29);
		}
		if (RandomMap == 30)
		{
			SwordCharge.startColor = new Color(41f / 255f, 142f / (339f * (float)Math.PI), 142f / (339f * (float)Math.PI));
			SwordCharge.endColor = new Color(40f / 51f, 0.5882353f, 0.5882353f);
			UnityEngine.Object.Instantiate(Map31);
		}
		if (RandomMap == 31)
		{
			SwordCharge.startColor = new Color(0.235294119f, 0.235294119f, 50f / 51f);
			SwordCharge.endColor = new Color(40f / 51f, 40f / 51f, 0.8235294f);
			UnityEngine.Object.Instantiate(Map30);
		}
	}

	private void FixedUpdate()
	{
		if (count > 0)
		{
			count--;
		}
		if (count == 1)
		{
			rbjoueur1.constraints = RigidbodyConstraints2D.None;
			rbjoueur2.constraints = RigidbodyConstraints2D.None;
		}
	}
}
