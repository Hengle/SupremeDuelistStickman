using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int nombreParty;

	public int GaucheVictory;

	public int DroiteVictory;

	public bool Outline1;

	public bool Outline2;

	public GameObject home;

	public GameObject sound;

	public GameObject SoundStop;

	public Canvas screen;

	public static GameManager instance;

	public float Volume;

	public float VolumeMax;

	public Camera CameNewScene;

	public Color skinColor;

	public Color skinColor2;

	public int player1Skin;

	public int player2Skin;

	public GameObject Skin1;

	public GameObject Skin2;

	public int weaponB;

	public int weaponR;

	public int AccesorieB;

	public int AccesorieR;

	public TextMesh WeaponBlueText;

	public TextMesh WeaponRedText;

	public bool Changeweapon;

	public bool OnePlayer;

	public bool Survival;

	public GameObject SwordB;

	public GameObject YoyoB;

	public GameObject HammerB;

	public GameObject GrappinB;

	public GameObject GunB;

	public GameObject ScepterB;

	public GameObject ArcB;

	public GameObject BootB;

	public GameObject PunchB;

	public GameObject GlaceB;

	public GameObject ChaussureB;

	public GameObject KnifeB;

	public GameObject GuitarreB;

	public GameObject KatanaB;

	public GameObject BombB;

	public GameObject SwordR;

	public GameObject YoyoR;

	public GameObject HammerR;

	public GameObject GrappinR;

	public GameObject GunR;

	public GameObject ScepterR;

	public GameObject ArcR;

	public GameObject BootR;

	public GameObject PunchR;

	public GameObject GlaceR;

	public GameObject ChaussureR;

	public GameObject KnifeR;

	public GameObject GuitarreR;

	public GameObject KatanaR;

	public GameObject BombR;

	public int TransitionTimerHome;

	public int TransitionTimerFight;

	public bool HealthBar;

	public SpriteRenderer Coeur1;

	public GameObject TeteB;

	public GameObject chapeauB;

	public GameObject EcharpeB;

	public GameObject yeuxB;

	public GameObject SpartanB;

	public GameObject SamuraiB;

	public GameObject TeteR;

	public GameObject chapeauR;

	public GameObject EcharpeR;

	public GameObject yeuxR;

	public GameObject SpartanR;

	public GameObject SamuraiR;

	public bool CharCustomize;

	public string player2Te;

	public string AiLevelText;

	public int map = 21;

	public bool TwoPlayerSurvival;

	public bool LeftUser;

	public int AiLevel;

	public float Experience;

	public float Constante;

	public int Level;

	public int SkinNumber;

	public int limitNumber;

	public float ScoreSurvival;

	public GameObject SkinWinAffiche;

	public AudioSource source;

	public AudioClip wrongSound;

	public AudioClip successSound;

	public AudioClip clickSound;

	public AudioClip ButtonPress1;

	public AudioClip ButtonPress2;

	public bool RandomSameWeapon;

	public GameObject PrivacyButton;

	public bool IsEuropean;

	public bool ActiveAd;

	public bool initialiseAd;

	public bool ResetMenuScreen = true;

	private void Awake()
	{
		SkinNumber = PlayerPrefs.GetInt("skin", 1);
		if (SkinNumber == 1)
		{
			ScoreSurvival = PlayerPrefs.GetFloat("HighScore", 0f);
			if (ScoreSurvival > 5f)
			{
				SkinNumber = 8380417;
			}
		}
		CameNewScene = GameObject.Find("Main Camera").GetComponent<Camera>();
		screen.worldCamera = CameNewScene;
		home.SetActive(value: false);
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(base.transform.gameObject);
			AffichageGdp();
		}
		else if (instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void ActivatePrivacyButton()
	{
		if (!(PrivacyButton == null))
		{
			return;
		}
		SpriteRenderer[] array = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].gameObject.name == "PrivacyButton")
			{
				PrivacyButton = array[i].gameObject;
				PrivacyButton.gameObject.SetActive(value: true);
			}
		}
	}

	private void AffichageGdp()
	{
		if (Application.systemLanguage == SystemLanguage.French)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Italian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Greek)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Dutch)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Danish)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Finnish)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Bulgarian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Catalan)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Estonian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.German)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Hungarian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Latvian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Lithuanian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Polish)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Portuguese)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Romanian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Slovak)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Slovenian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Spanish)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Swedish)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.SerboCroatian)
		{
			IsEuropean = true;
		}
		if (Application.systemLanguage == SystemLanguage.Czech)
		{
			IsEuropean = true;
		}
		if (IsEuropean)
		{
			if (PlayerPrefs.GetInt("Eu", 0) == 0)
			{
				SpriteRenderer[] array = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].gameObject.name == "Gdp")
					{
						array[i].gameObject.SetActive(value: true);
					}
				}
			}
			else
			{
				ActiveAd = true;
			}
		}
		else
		{
			ActiveAd = true;
		}
	}

	private void FixedUpdate()
	{
		if (ActiveAd)
		{
			ActiveAd = false;
			Object.FindObjectOfType<AdManager>().InitAd();
		}
		Scene activeScene = SceneManager.GetActiveScene();
		if (TransitionTimerHome > 0)
		{
			TransitionTimerHome--;
		}
		if (TransitionTimerHome == 1)
		{
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
		if (TransitionTimerFight > 0)
		{
			TransitionTimerFight--;
		}
		if (TransitionTimerFight == 1)
		{
			SceneManager.LoadScene(1, LoadSceneMode.Single);
			nombreParty = 0;
			GaucheVictory = 0;
			DroiteVictory = 0;
		}
		if (activeScene.name == "game" && CameNewScene == null)
		{
			CameNewScene = GameObject.Find("Main Camera").GetComponent<Camera>();
			screen.worldCamera = CameNewScene;
		}
		if (activeScene.name == "duel" && CameNewScene == null)
		{
			CameNewScene = GameObject.Find("Main Camera").GetComponent<Camera>();
			screen.worldCamera = CameNewScene;
		}
		if (activeScene.name == "Menu")
		{
			CameNewScene = GameObject.Find("Main Camera").GetComponent<Camera>();
			screen.worldCamera = CameNewScene;
			if (!CharCustomize)
			{
				ResetMenuScreen = true;
			}
			if (CharCustomize)
			{
				if (ResetMenuScreen)
				{
					ResetMenuScreen = false;
					if (OnePlayer)
					{
						SpriteRenderer[] array = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						if (LeftUser)
						{
							for (int i = 0; i < array.Length; i++)
							{
								if (array[i].transform.name == "Lefty")
								{
									array[i].gameObject.SetActive(value: true);
								}
								if (array[i].transform.name == "Righty")
								{
									array[i].gameObject.SetActive(value: false);
								}
							}
						}
						else
						{
							for (int j = 0; j < array.Length; j++)
							{
								if (array[j].transform.name == "Righty")
								{
									array[j].gameObject.SetActive(value: true);
								}
								if (array[j].transform.name == "Lefty")
								{
									array[j].gameObject.SetActive(value: false);
								}
							}
						}
					}
					else
					{
						SpriteRenderer[] array2 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int k = 0; k < array2.Length; k++)
						{
							if (array2[k].transform.name == "Lefty")
							{
								array2[k].gameObject.SetActive(value: false);
							}
							if (array2[k].transform.name == "Righty")
							{
								array2[k].gameObject.SetActive(value: false);
							}
						}
					}
					map[] array3 = Resources.FindObjectsOfTypeAll<map>();
					for (int l = 0; l < array3.Length; l++)
					{
						if (!Survival)
						{
							if (array3[l].MapNum == map)
							{
								array3[l].gameObject.SetActive(value: true);
							}
							else
							{
								array3[l].gameObject.SetActive(value: false);
							}
						}
						else if (array3[l].MapNum == -1)
						{
							array3[l].gameObject.SetActive(value: true);
						}
						else
						{
							array3[l].gameObject.SetActive(value: false);
						}
					}
					if (HealthBar)
					{
						SpriteRenderer[] array4 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int m = 0; m < array4.Length; m++)
						{
							if (array4[m].transform.name == "Vie On")
							{
								array4[m].gameObject.SetActive(value: true);
							}
							if (array4[m].transform.name == "Vie Off")
							{
								array4[m].gameObject.SetActive(value: false);
							}
							if (RandomSameWeapon)
							{
								if (weaponB == 0 && weaponR == 0 && !Survival)
								{
									if (array4[m].transform.name == "randomSame On")
									{
										array4[m].gameObject.SetActive(value: true);
									}
									if (array4[m].transform.name == "randomSame Off")
									{
										array4[m].gameObject.SetActive(value: false);
									}
								}
								else
								{
									if (array4[m].transform.name == "randomSame On")
									{
										array4[m].gameObject.SetActive(value: false);
									}
									if (array4[m].transform.name == "randomSame Off")
									{
										array4[m].gameObject.SetActive(value: false);
									}
								}
							}
							else if (weaponB == 0 && weaponR == 0 && !Survival)
							{
								if (array4[m].transform.name == "randomSame On")
								{
									array4[m].gameObject.SetActive(value: false);
								}
								if (array4[m].transform.name == "randomSame Off")
								{
									array4[m].gameObject.SetActive(value: true);
								}
							}
							else
							{
								if (array4[m].transform.name == "randomSame On")
								{
									array4[m].gameObject.SetActive(value: false);
								}
								if (array4[m].transform.name == "randomSame Off")
								{
									array4[m].gameObject.SetActive(value: false);
								}
							}
						}
					}
					else
					{
						SpriteRenderer[] array5 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int n = 0; n < array5.Length; n++)
						{
							if (array5[n].transform.name == "Vie On")
							{
								array5[n].gameObject.SetActive(value: false);
							}
							if (array5[n].transform.name == "Vie Off")
							{
								array5[n].gameObject.SetActive(value: true);
							}
							if (RandomSameWeapon)
							{
								if (weaponB == 0 && weaponR == 0 && !Survival)
								{
									if (array5[n].transform.name == "randomSame On")
									{
										array5[n].gameObject.SetActive(value: true);
									}
									if (array5[n].transform.name == "randomSame Off")
									{
										array5[n].gameObject.SetActive(value: false);
									}
								}
								else
								{
									if (array5[n].transform.name == "randomSame On")
									{
										array5[n].gameObject.SetActive(value: false);
									}
									if (array5[n].transform.name == "randomSame Off")
									{
										array5[n].gameObject.SetActive(value: false);
									}
								}
							}
							else if (weaponB == 0 && weaponR == 0 && !Survival)
							{
								if (array5[n].transform.name == "randomSame On")
								{
									array5[n].gameObject.SetActive(value: false);
								}
								if (array5[n].transform.name == "randomSame Off")
								{
									array5[n].gameObject.SetActive(value: true);
								}
							}
							else
							{
								if (array5[n].transform.name == "randomSame On")
								{
									array5[n].gameObject.SetActive(value: false);
								}
								if (array5[n].transform.name == "randomSame Off")
								{
									array5[n].gameObject.SetActive(value: false);
								}
							}
						}
					}
					if (Outline1)
					{
						SpriteRenderer[] array6 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int num = 0; num < array6.Length; num++)
						{
							if (array6[num].transform.name == "Outline Bleu")
							{
								array6[num].enabled = true;
								if (skinColor == new Color(0f, 0f, 0f, 1f))
								{
									array6[num].gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
								}
								else
								{
									array6[num].gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
								}
							}
						}
					}
					else
					{
						SpriteRenderer[] array7 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int num2 = 0; num2 < array7.Length; num2++)
						{
							if (array7[num2].transform.name == "Outline Bleu")
							{
								array7[num2].enabled = false;
							}
						}
					}
					if (Outline2)
					{
						SpriteRenderer[] array8 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int num3 = 0; num3 < array8.Length; num3++)
						{
							if (array8[num3].transform.name == "Outline Rouge")
							{
								array8[num3].enabled = true;
								if (skinColor2 == new Color(0f, 0f, 0f, 1f))
								{
									array8[num3].gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
								}
								else
								{
									array8[num3].gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
								}
							}
						}
					}
					else
					{
						SpriteRenderer[] array9 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
						for (int num4 = 0; num4 < array9.Length; num4++)
						{
							if (array9[num4].transform.name == "Outline Rouge")
							{
								array9[num4].enabled = false;
							}
						}
					}
					Skin1 = GameObject.Find("Stick Bleu");
					if (Skin1.GetComponent<SpriteRenderer>().color != skinColor)
					{
						Skin1.GetComponent<SpriteRenderer>().color = skinColor;
					}
					MenuType[] array10 = Resources.FindObjectsOfTypeAll<MenuType>();
					for (int num5 = 0; num5 < array10.Length; num5++)
					{
						if (!(array10[num5].gameObject.name == "Player Droite") || !array10[num5].gameObject.activeInHierarchy || !GameObject.Find("Player Droite").gameObject.activeInHierarchy)
						{
							continue;
						}
						GameObject.Find("Text Player2").GetComponent<TextMesh>().text = player2Te;
						if (OnePlayer)
						{
							GameObject.Find("AiLevel").GetComponent<BoxCollider2D>().enabled = true;
							GameObject.Find("AiLevel").GetComponent<SpriteRenderer>().enabled = true;
						}
						Skin2 = GameObject.Find("Stick Jaune");
						if (Skin2.GetComponent<SpriteRenderer>().color != skinColor2)
						{
							Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
						}
						WeaponRedText = GameObject.Find("Text R weapon").GetComponent<TextMesh>();
						ArmeRouge[] array11 = UnityEngine.Object.FindObjectsOfType<ArmeRouge>();
						for (int num6 = 0; num6 < array11.Length; num6++)
						{
							array11[num6].gameObject.GetComponent<SpriteRenderer>().enabled = false;
						}
						for (int num7 = 0; num7 < array11.Length; num7++)
						{
							if (weaponR == array11[num7].GetComponent<ArmeRouge>().num)
							{
								array11[num7].gameObject.GetComponent<SpriteRenderer>().enabled = true;
							}
						}
						if (weaponR == 0)
						{
							WeaponRedText.text = "Random";
						}
						if (weaponR == 1)
						{
							WeaponRedText.text = "Sword";
						}
						if (weaponR == 2)
						{
							WeaponRedText.text = "Hammer";
						}
						if (weaponR == 3)
						{
							WeaponRedText.text = "Grapnel";
						}
						if (weaponR == 4)
						{
							WeaponRedText.text = "Gun";
						}
						if (weaponR == 5)
						{
							WeaponRedText.text = "Scepter";
						}
						if (weaponR == 6)
						{
							WeaponRedText.text = "Flail";
						}
						if (weaponR == 7)
						{
							WeaponRedText.text = "Bow";
						}
						if (weaponR == 8)
						{
							WeaponRedText.text = "Boomerang";
							WeaponRedText.fontSize = 23;
						}
						if (weaponR == 9)
						{
							WeaponRedText.text = "Gauntlet";
						}
						if (weaponR == 10)
						{
							WeaponRedText.text = "Ice cream";
							WeaponRedText.fontSize = 24;
						}
						if (weaponR == 11)
						{
							WeaponRedText.text = "Boot";
						}
						if (weaponR == 12)
						{
							WeaponRedText.text = "Dagger";
						}
						if (weaponR == 13)
						{
							WeaponRedText.text = "Guitar";
						}
						if (weaponR == 14)
						{
							WeaponRedText.text = "Katana";
						}
						if (weaponR == 15)
						{
							WeaponRedText.text = "Bomb";
						}
						if (weaponR == 16)
						{
							WeaponRedText.fontSize = 23;
							WeaponRedText.text = "Portal Gun";
						}
						if (weaponR == 17)
						{
							WeaponRedText.text = "Sickle";
						}
						if (weaponR == 18)
						{
							WeaponRedText.text = "Circular Saw";
							WeaponRedText.fontSize = 20;
						}
						if (weaponR == 19)
						{
							WeaponRedText.text = "Axe";
						}
						if (weaponR == 20)
						{
							WeaponRedText.text = "Lance";
						}
						if (weaponR == 21)
						{
							WeaponRedText.text = "Sniper";
						}
						if (weaponR == 22)
						{
							WeaponRedText.text = "Shield";
						}
						if (weaponR == 23)
						{
							WeaponRedText.text = "Infinity Gauntlet";
							WeaponRedText.fontSize = 15;
						}
						if (weaponR == 24)
						{
							WeaponRedText.text = "Spear";
						}
						if (weaponR == 25)
						{
							WeaponRedText.text = "Lightsaber";
							WeaponRedText.fontSize = 20;
						}
						if (weaponR == 26)
						{
							WeaponRedText.text = "Bazooka";
						}
						if (weaponR == 27)
						{
							WeaponRedText.text = "Pickaxe";
						}
						if (weaponR == 28)
						{
							WeaponRedText.text = "Shuriken";
						}
						if (weaponR == 30)
						{
							WeaponRedText.text = "PaintBrush";
							WeaponRedText.fontSize = 25;
						}
						if (weaponR == 29)
						{
							WeaponRedText.text = "Iron Hand";
							WeaponRedText.fontSize = 25;
						}
						WeaponRedText.color = new Color(1f, 1f, 1f, 1f);
						SkinRouge[] array12 = UnityEngine.Object.FindObjectsOfType<SkinRouge>();
						for (int num8 = 0; num8 < array12.Length; num8++)
						{
							array12[num8].gameObject.GetComponent<SpriteRenderer>().enabled = false;
						}
						for (int num9 = 0; num9 < array12.Length; num9++)
						{
							if (AccesorieR == array12[num9].GetComponent<SkinRouge>().num)
							{
								if (AccesorieR == 1)
								{
									array12[num9].GetComponent<SpriteRenderer>().color = skinColor2;
								}
								array12[num9].gameObject.GetComponent<SpriteRenderer>().enabled = true;
							}
						}
					}
					WeaponBlueText = GameObject.Find("Text B weapon").GetComponent<TextMesh>();
					ArmeBleu[] array13 = UnityEngine.Object.FindObjectsOfType<ArmeBleu>();
					for (int num10 = 0; num10 < array13.Length; num10++)
					{
						array13[num10].gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
					for (int num11 = 0; num11 < array13.Length; num11++)
					{
						if (weaponB == array13[num11].GetComponent<ArmeBleu>().num)
						{
							array13[num11].gameObject.GetComponent<SpriteRenderer>().enabled = true;
						}
					}
					if (weaponB == 0)
					{
						WeaponBlueText.text = "Random";
					}
					if (weaponB == 1)
					{
						WeaponBlueText.text = "Sword";
					}
					if (weaponB == 2)
					{
						WeaponBlueText.text = "Hammer";
					}
					if (weaponB == 3)
					{
						WeaponBlueText.text = "Grapnel";
					}
					if (weaponB == 4)
					{
						WeaponBlueText.text = "Gun";
					}
					if (weaponB == 5)
					{
						WeaponBlueText.text = "Scepter";
					}
					if (weaponB == 6)
					{
						WeaponBlueText.text = "Flail";
					}
					if (weaponB == 7)
					{
						WeaponBlueText.text = "Bow";
					}
					if (weaponB == 8)
					{
						WeaponBlueText.text = "Boomerang";
						WeaponBlueText.fontSize = 23;
					}
					if (weaponB == 9)
					{
						WeaponBlueText.text = "Gauntlet";
					}
					if (weaponB == 10)
					{
						WeaponBlueText.text = "Ice cream";
						WeaponBlueText.fontSize = 24;
					}
					if (weaponB == 11)
					{
						WeaponBlueText.text = "Boot";
					}
					if (weaponB == 12)
					{
						WeaponBlueText.text = "Dagger";
					}
					if (weaponB == 13)
					{
						WeaponBlueText.text = "Guitar";
					}
					if (weaponB == 14)
					{
						WeaponBlueText.text = "Katana";
					}
					if (weaponB == 15)
					{
						WeaponBlueText.text = "Bomb";
					}
					if (weaponB == 16)
					{
						WeaponBlueText.text = "Portal Gun";
						WeaponBlueText.fontSize = 23;
					}
					if (weaponB == 17)
					{
						WeaponBlueText.text = "Sickle";
					}
					if (weaponB == 18)
					{
						WeaponBlueText.text = "Circular Saw";
						WeaponBlueText.fontSize = 20;
					}
					if (weaponB == 19)
					{
						WeaponBlueText.text = "Axe";
					}
					if (weaponB == 20)
					{
						WeaponBlueText.text = "Lance";
					}
					if (weaponB == 21)
					{
						WeaponBlueText.text = "Sniper";
					}
					if (weaponB == 22)
					{
						WeaponBlueText.text = "Shield";
					}
					if (weaponB == 23)
					{
						WeaponBlueText.text = "Infinity Gauntlet";
						WeaponBlueText.fontSize = 15;
					}
					if (weaponB == 24)
					{
						WeaponBlueText.text = "Spear";
					}
					if (weaponB == 25)
					{
						WeaponBlueText.text = "Lightsaber";
						WeaponBlueText.fontSize = 20;
					}
					if (weaponB == 26)
					{
						WeaponBlueText.text = "Bazooka";
					}
					if (weaponB == 27)
					{
						WeaponBlueText.text = "Pickaxe";
					}
					if (weaponB == 28)
					{
						WeaponBlueText.text = "Shuriken";
					}
					if (weaponB == 30)
					{
						WeaponBlueText.text = "PaintBrush";
						WeaponBlueText.fontSize = 25;
					}
					if (weaponB == 29)
					{
						WeaponBlueText.text = "Iron Hand";
						WeaponBlueText.fontSize = 25;
					}
					WeaponBlueText.color = new Color(1f, 1f, 1f, 1f);
					SkinBleu[] array14 = UnityEngine.Object.FindObjectsOfType<SkinBleu>();
					for (int num12 = 0; num12 < array14.Length; num12++)
					{
						array14[num12].gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
					for (int num13 = 0; num13 < array14.Length; num13++)
					{
						if (AccesorieB == array14[num13].GetComponent<SkinBleu>().num)
						{
							if (AccesorieB == 1)
							{
								array14[num13].GetComponent<SpriteRenderer>().color = skinColor;
							}
							array14[num13].gameObject.GetComponent<SpriteRenderer>().enabled = true;
						}
					}
				}
			}
			else if (PlayerPrefs.GetInt("Eu", 0) == 1 && TransitionTimerFight <= 0)
			{
				ActivatePrivacyButton();
			}
		}
		Changeweapon = false;
	}

	public void Update()
	{
		for (int i = 0; i < UnityEngine.Input.touchCount; i++)
		{
			if (UnityEngine.Input.GetTouch(i).phase == TouchPhase.Began)
			{
				checkTouch(UnityEngine.Input.GetTouch(i).position);
			}
		}
		if (!Input.GetKeyDown(KeyCode.DownArrow))
		{
		}
	}

	private void checkTouch(Vector3 pos)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(pos);
		Vector2 point = new Vector2(vector.x, vector.y);
		Collider2D collider2D = Physics2D.OverlapPoint(point);
		if (!collider2D)
		{
			return;
		}
		if (collider2D.transform.name == "Coeur1" || collider2D.transform.name == "Coeur2")
		{
			ResetMenuScreen = true;
			if (!Survival)
			{
				HealthBar = !HealthBar;
				if (source == null)
				{
					source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
				}
				source.PlayOneShot(clickSound, 0.2f);
				if (HealthBar)
				{
					SpriteRenderer[] array = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].transform.name == "Vie On")
						{
							array[i].gameObject.SetActive(value: true);
						}
						if (array[i].transform.name == "Vie Off")
						{
							array[i].gameObject.SetActive(value: false);
						}
					}
				}
				else
				{
					ResetMenuScreen = true;
					SpriteRenderer[] array2 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j].transform.name == "Vie On")
						{
							array2[j].gameObject.SetActive(value: false);
						}
						if (array2[j].transform.name == "Vie Off")
						{
							array2[j].gameObject.SetActive(value: true);
						}
					}
				}
			}
		}
		if (collider2D.transform.name == "AiLevel")
		{
			ResetMenuScreen = true;
			AiLevel++;
			if (AiLevel == 10)
			{
				AiLevel = 1;
			}
			source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			source.PlayOneShot(clickSound);
			player2Te = "AI Lv" + AiLevel.ToString();
			GameObject.Find("Text Player2").GetComponent<TextMesh>().text = player2Te;
		}
		if (collider2D.transform.name == "Twitter Bouton")
		{
		}
		if (collider2D.transform.name == "Youtube Bouton")
		{
			Application.OpenURL("https://www.youtube.com/channel/UCN-4imQmz1_EpEIZ7bjegaQ/featured");
			int num = UnityEngine.Random.Range(0, 8);
			if (num == 1)
			{
				AdManager.Instance.ShowVideo();
			}
		}
		if (collider2D.transform.name == "AcceptGDPR")
		{
			PlayerPrefs.SetInt("PersoAd", 1);
			GameObject.Find("Gdp").SetActive(value: false);
			ActiveAd = true;
			PlayerPrefs.SetInt("Eu", 1);
		}
		if (collider2D.transform.name == "RefuseGDPR")
		{
			PlayerPrefs.SetInt("PersoAd", 0);
			GameObject.Find("Gdp").SetActive(value: false);
			ActiveAd = true;
			PlayerPrefs.SetInt("Eu", 1);
		}
		if (collider2D.transform.name == "PrivacyButton")
		{
			UnityEngine.Debug.Log("Privacy Police");
			SpriteRenderer[] array3 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
			for (int k = 0; k < array3.Length; k++)
			{
				if (array3[k].gameObject.name == "Gdp")
				{
					array3[k].gameObject.SetActive(value: true);
				}
			}
		}
		if (collider2D.transform.name == "Outline Bleu")
		{
			Outline1 = !Outline1;
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
		}
		if (collider2D.transform.name == "Outline Rouge")
		{
			Outline2 = !Outline2;
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
		}
		if (collider2D.transform.name == "randomSame Button")
		{
			RandomSameWeapon = !RandomSameWeapon;
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
		}
		if (collider2D.transform.name == "Left Handed Option")
		{
			LeftUser = !LeftUser;
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
		}
		if (collider2D.transform.name == "map+" && !Survival)
		{
			ResetMenuScreen = true;
			map++;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if (map > 31)
			{
				map = 0;
			}
		}
		if (collider2D.transform.name == "map-" && !Survival)
		{
			ResetMenuScreen = true;
			map--;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if ((float)map < 0f)
			{
				map = 31;
			}
		}
		if (collider2D.transform.name == "accessB+")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if (AccesorieB <= 27)
			{
				AccesorieB++;
			}
			else
			{
				AccesorieB = 0;
			}
		}
		if (collider2D.transform.name == "accessB-")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if (AccesorieB > 0)
			{
				AccesorieB--;
			}
			else
			{
				AccesorieB = 28;
			}
		}
		if (collider2D.transform.name == "accessR+")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if (AccesorieR <= 27)
			{
				AccesorieR++;
			}
			else
			{
				AccesorieR = 0;
			}
		}
		if (collider2D.transform.name == "accessR-")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			if (AccesorieR > 0)
			{
				AccesorieR--;
			}
			else
			{
				AccesorieR = 28;
			}
		}
		if (collider2D.transform.name == "AddPlayer")
		{
			ResetMenuScreen = true;
			player2Te = "Player 2";
			if (TransitionTimerFight <= 0 && TransitionTimerHome <= 0)
			{
				TwoPlayerSurvival = !TwoPlayerSurvival;
				if (TwoPlayerSurvival)
				{
					if (source == null)
					{
						source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
					}
					source.PlayOneShot(clickSound, 0.2f);
					MenuType[] array4 = Resources.FindObjectsOfTypeAll<MenuType>();
					for (int l = 0; l < array4.Length; l++)
					{
						if (array4[l].gameObject.name == "Player Droite")
						{
							skip[] array5 = Resources.FindObjectsOfTypeAll<skip>();
							for (int m = 0; m < array5.Length; m++)
							{
								array5[m].gameObject.SetActive(value: true);
							}
							TwoPlayerSurvival = true;
							OnePlayer = false;
							array4[l].gameObject.SetActive(value: true);
							break;
						}
					}
				}
				if (!TwoPlayerSurvival)
				{
					if (source == null)
					{
						source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
					}
					source.PlayOneShot(clickSound, 0.2f);
					MenuType[] array6 = Resources.FindObjectsOfTypeAll<MenuType>();
					for (int n = 0; n < array6.Length; n++)
					{
						if (array6[n].gameObject.name == "Player Droite")
						{
							array6[n].gameObject.SetActive(value: false);
							TwoPlayerSurvival = false;
							OnePlayer = true;
							break;
						}
					}
				}
			}
		}
		if (collider2D.transform.name == "Fight" && TransitionTimerHome <= 0 && TransitionTimerFight <= 0 && !CharCustomize)
		{
			ResetMenuScreen = true;
			if (PrivacyButton != null)
			{
				PrivacyButton.SetActive(value: false);
			}
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(ButtonPress1, 0.4f);
			home.SetActive(value: true);
			OnePlayer = true;
			Survival = true;
			HealthBar = true;
			RandomSameWeapon = false;
			MenuType[] array7 = Resources.FindObjectsOfTypeAll<MenuType>();
			for (int num2 = 0; num2 < array7.Length; num2++)
			{
				if (array7[num2].gameObject.name == "Player Droite")
				{
					array7[num2].gameObject.SetActive(value: false);
				}
				if (array7[num2].gameObject.name == "Player Gauche")
				{
					array7[num2].gameObject.SetActive(value: true);
				}
				if (array7[num2].gameObject.name == "Centre Go")
				{
					array7[num2].gameObject.SetActive(value: true);
				}
				if (array7[num2].gameObject.name == "Titre")
				{
					array7[num2].gameObject.SetActive(value: false);
				}
				if (array7[num2].gameObject.name == "Bouton Selection")
				{
					array7[num2].gameObject.SetActive(value: false);
				}
				if (array7[num2].gameObject.name == "Player Droite IMAGE")
				{
					array7[num2].gameObject.SetActive(value: false);
				}
				if (array7[num2].gameObject.name == "Player Gauche IMAGE")
				{
					array7[num2].gameObject.SetActive(value: false);
				}
				if (array7[num2].gameObject.name == "Player Droite activation")
				{
					array7[num2].gameObject.SetActive(value: true);
				}
			}
			CharCustomize = true;
			transitionInScene[] array8 = Resources.FindObjectsOfTypeAll<transitionInScene>();
			for (int num3 = 0; num3 < array8.Length; num3++)
			{
				array8[num3].gameObject.SetActive(value: true);
			}
		}
		if (collider2D.transform.name == "WeaponBlue-")
		{
			ResetMenuScreen = true;
			WeaponBlueText.color = new Color(0f, 0f, 0f, 0f);
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.4f);
			WeaponBlueText.fontSize = 29;
			if (weaponB > 0)
			{
				weaponB--;
			}
			else
			{
				weaponB = 30;
			}
			Changeweapon = true;
		}
		if (collider2D.transform.name == "WeaponBlue+")
		{
			ResetMenuScreen = true;
			WeaponBlueText.color = new Color(0f, 0f, 0f, 0f);
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			WeaponBlueText.fontSize = 29;
			if (weaponB < 30)
			{
				weaponB++;
			}
			else
			{
				weaponB = 0;
			}
			Changeweapon = true;
		}
		if (collider2D.transform.name == "WeaponRed-")
		{
			ResetMenuScreen = true;
			WeaponRedText.color = new Color(0f, 0f, 0f, 0f);
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			WeaponRedText.fontSize = 29;
			if (weaponR > 0)
			{
				weaponR--;
			}
			else
			{
				weaponR = 30;
			}
			Changeweapon = true;
		}
		if (collider2D.transform.name == "WeaponRed+")
		{
			ResetMenuScreen = true;
			WeaponRedText.color = new Color(0f, 0f, 0f, 0f);
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.4f);
			WeaponRedText.fontSize = 29;
			if (weaponR < 30)
			{
				weaponR++;
			}
			else
			{
				weaponR = 0;
			}
			Changeweapon = true;
		}
		if (collider2D.transform.tag == "home")
		{
			int num4 = UnityEngine.Random.Range(0, 6);
			if (Survival)
			{
			}
			if (num4 == 1)
			{
				AdManager.Instance.ShowVideo();
			}
			if (TransitionTimerFight <= 0 && TransitionTimerHome <= 0)
			{
				TransitionTimerHome = 40;
				home.SetActive(value: false);
				Survival = false;
				CharCustomize = false;
			}
			else
			{
				UnityEngine.Debug.Log("Full BUG home");
			}
			TwoPlayerSurvival = false;
		}
		if (collider2D.transform.tag == "son")
		{
			UnityEngine.Debug.Log(" hit");
			if (Volume == VolumeMax)
			{
				SoundStop.SetActive(value: true);
				Volume = 0f;
				UnityEngine.Debug.Log("Son = 0");
			}
			else
			{
				SoundStop.SetActive(value: false);
				Volume = VolumeMax;
			}
		}
		if (collider2D.transform.tag == "Player1" && TransitionTimerHome <= 0 && TransitionTimerFight <= 0)
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(ButtonPress1, 0.4f);
			if (PrivacyButton != null)
			{
				PrivacyButton.SetActive(value: false);
			}
			int num5 = UnityEngine.Random.Range(0, 7);
			if (num5 == 1)
			{
				AdManager.Instance.ShowVideo();
			}
			home.SetActive(value: true);
			OnePlayer = true;
			Survival = false;
			player2Te = "AI Lv" + AiLevel.ToString();
			MenuType[] array9 = Resources.FindObjectsOfTypeAll<MenuType>();
			for (int num6 = 0; num6 < array9.Length; num6++)
			{
				if (array9[num6].gameObject.name == "Player Droite")
				{
					array9[num6].gameObject.SetActive(value: true);
				}
				if (array9[num6].gameObject.name == "Player Gauche")
				{
					array9[num6].gameObject.SetActive(value: true);
				}
				if (array9[num6].gameObject.name == "Centre Go")
				{
					array9[num6].gameObject.SetActive(value: true);
				}
				if (array9[num6].gameObject.name == "Titre")
				{
					array9[num6].gameObject.SetActive(value: false);
				}
				if (array9[num6].gameObject.name == "Bouton Selection")
				{
					array9[num6].gameObject.SetActive(value: false);
				}
				if (array9[num6].gameObject.name == "Player Droite IMAGE")
				{
					array9[num6].gameObject.SetActive(value: false);
				}
				if (array9[num6].gameObject.name == "Player Gauche IMAGE")
				{
					array9[num6].gameObject.SetActive(value: false);
				}
				if (array9[num6].gameObject.name == "Player Droite activation")
				{
					array9[num6].gameObject.SetActive(value: false);
				}
			}
			CharCustomize = true;
			transitionInScene[] array10 = Resources.FindObjectsOfTypeAll<transitionInScene>();
			for (int num7 = 0; num7 < array10.Length; num7++)
			{
				array10[num7].gameObject.SetActive(value: true);
			}
		}
		if (collider2D.transform.tag == "Player2" && TransitionTimerHome <= 0 && TransitionTimerFight <= 0)
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(ButtonPress1, 0.4f);
			if (PrivacyButton != null)
			{
				PrivacyButton.SetActive(value: false);
			}
			int num8 = UnityEngine.Random.Range(0, 7);
			if (num8 == 1)
			{
				AdManager.Instance.ShowVideo();
			}
			home.SetActive(value: true);
			OnePlayer = false;
			Survival = false;
			player2Te = "Player 2";
			MenuType[] array11 = Resources.FindObjectsOfTypeAll<MenuType>();
			for (int num9 = 0; num9 < array11.Length; num9++)
			{
				if (array11[num9].gameObject.name == "Player Droite")
				{
					array11[num9].gameObject.SetActive(value: true);
				}
				if (array11[num9].gameObject.name == "Player Gauche")
				{
					array11[num9].gameObject.SetActive(value: true);
				}
				if (array11[num9].gameObject.name == "Centre Go")
				{
					array11[num9].gameObject.SetActive(value: true);
				}
				if (array11[num9].gameObject.name == "Titre")
				{
					array11[num9].gameObject.SetActive(value: false);
				}
				if (array11[num9].gameObject.name == "Bouton Selection")
				{
					array11[num9].gameObject.SetActive(value: false);
				}
				if (array11[num9].gameObject.name == "Player Droite IMAGE")
				{
					array11[num9].gameObject.SetActive(value: false);
				}
				if (array11[num9].gameObject.name == "Player Gauche IMAGE")
				{
					array11[num9].gameObject.SetActive(value: false);
				}
			}
			CharCustomize = true;
			transitionInScene[] array12 = Resources.FindObjectsOfTypeAll<transitionInScene>();
			for (int num10 = 0; num10 < array12.Length; num10++)
			{
				array12[num10].gameObject.SetActive(value: true);
			}
		}
		if (collider2D.transform.name == "Go")
		{
			bool flag = true;
			skin[] array13 = UnityEngine.Object.FindObjectsOfType<skin>();
			for (int num11 = 0; num11 < array13.Length; num11++)
			{
				if (array13[num11].gameObject.GetComponent<SpriteRenderer>().enabled)
				{
					if (array13[num11].gameObject.GetComponent<SkinBleu>() != null && !array13[num11].gameObject.GetComponent<SkinBleu>().Accessible)
					{
						flag = false;
					}
					if (array13[num11].gameObject.GetComponent<SkinRouge>() != null && !array13[num11].gameObject.GetComponent<SkinRouge>().Accessible)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				if (TransitionTimerHome <= 0 && TransitionTimerFight <= 0)
				{
					if (source == null)
					{
						source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
					}
					source.PlayOneShot(ButtonPress1, 0.4f);
					TransitionTimerFight = 40;
					CharCustomize = false;
					if (map == 22)
					{
						HealthBar = true;
					}
					TransisionScene[] array14 = Resources.FindObjectsOfTypeAll<TransisionScene>();
					for (int num12 = 0; num12 < array14.Length; num12++)
					{
						array14[num12].gameObject.SetActive(value: true);
					}
				}
			}
			else
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
				source.PlayOneShot(wrongSound);
			}
		}
		if (collider2D.transform.name == "Weaponize")
		{
			TransitionTimerHome = 40;
			CharCustomize = true;
		}
		if (collider2D.transform.name == "skinB+")
		{
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			ResetMenuScreen = true;
			UnityEngine.Debug.Log("skin bleu");
			player1Skin++;
			if (player1Skin > 14)
			{
				player1Skin = 0;
			}
			if (player1Skin == 0)
			{
				UnityEngine.Debug.Log("WHITE");
				skinColor = new Color(1f, 1f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 1)
			{
				skinColor = new Color(0.8f, 0.8f, 0.8f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 2)
			{
				skinColor = new Color(0.1f, 0.2f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 3)
			{
				skinColor = new Color(0.4f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 4)
			{
				skinColor = new Color(0f, 1f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 5)
			{
				skinColor = new Color(1f, 0.7f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 6)
			{
				skinColor = new Color(0f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 7)
			{
				skinColor = new Color(1f, 1f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 8)
			{
				skinColor = new Color(0.5f, 1f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 9)
			{
				skinColor = new Color(1f, 0.7f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 10)
			{
				skinColor = new Color(1f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 11)
			{
				skinColor = new Color(0f, 1f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 12)
			{
				skinColor = new Color(0f, 0f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 13)
			{
				skinColor = new Color(0.5f, 0f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 14)
			{
				skinColor = new Color(1f, 0f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
		}
		if (collider2D.transform.name == "skinB-")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			player1Skin--;
			if (player1Skin < 0)
			{
				player1Skin = 14;
			}
			UnityEngine.Debug.Log("skin bleu");
			if (player1Skin == 0)
			{
				UnityEngine.Debug.Log("WHITE");
				skinColor = new Color(1f, 1f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 1)
			{
				skinColor = new Color(0.8f, 0.8f, 0.8f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 2)
			{
				skinColor = new Color(0.1f, 0.2f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 3)
			{
				skinColor = new Color(0.4f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 4)
			{
				skinColor = new Color(0f, 1f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 5)
			{
				skinColor = new Color(1f, 0.7f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 6)
			{
				skinColor = new Color(0f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 7)
			{
				skinColor = new Color(1f, 1f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 8)
			{
				skinColor = new Color(0.5f, 1f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 9)
			{
				skinColor = new Color(1f, 0.7f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 10)
			{
				skinColor = new Color(1f, 0f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 11)
			{
				skinColor = new Color(0f, 1f, 0f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 12)
			{
				skinColor = new Color(0f, 0f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 13)
			{
				skinColor = new Color(0.5f, 0f, 0.5f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
			else if (player1Skin == 14)
			{
				skinColor = new Color(1f, 0f, 1f, 1f);
				Skin1.GetComponent<SpriteRenderer>().color = skinColor;
			}
		}
		if (collider2D.transform.name == "skinY+")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			player2Skin++;
			if (player2Skin > 14)
			{
				player2Skin = 0;
			}
			if (player2Skin == 0)
			{
				UnityEngine.Debug.Log("WHITE");
				skinColor2 = new Color(1f, 1f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 1)
			{
				skinColor2 = new Color(0.8f, 0.8f, 0.8f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 2)
			{
				skinColor2 = new Color(0.1f, 0.2f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 3)
			{
				skinColor2 = new Color(0.4f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 4)
			{
				skinColor2 = new Color(0f, 1f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 5)
			{
				skinColor2 = new Color(1f, 0.7f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 6)
			{
				skinColor2 = new Color(0f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 7)
			{
				skinColor2 = new Color(1f, 1f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 8)
			{
				skinColor2 = new Color(0.5f, 1f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 9)
			{
				skinColor2 = new Color(1f, 0.7f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 10)
			{
				skinColor2 = new Color(1f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 11)
			{
				skinColor2 = new Color(0f, 1f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 12)
			{
				skinColor2 = new Color(0f, 0f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 13)
			{
				skinColor2 = new Color(0.5f, 0f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 14)
			{
				skinColor2 = new Color(1f, 0f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
		}
		if (collider2D.transform.name == "skinY-")
		{
			ResetMenuScreen = true;
			if (source == null)
			{
				source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			}
			source.PlayOneShot(clickSound, 0.2f);
			player2Skin--;
			if (player2Skin < 0)
			{
				player2Skin = 14;
			}
			if (player2Skin == 0)
			{
				UnityEngine.Debug.Log("WHITE");
				skinColor2 = new Color(1f, 1f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 1)
			{
				skinColor2 = new Color(0.8f, 0.8f, 0.8f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 2)
			{
				skinColor2 = new Color(0.1f, 0.2f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 3)
			{
				skinColor2 = new Color(0.4f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 4)
			{
				skinColor2 = new Color(0f, 1f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 5)
			{
				skinColor2 = new Color(1f, 0.7f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 6)
			{
				skinColor2 = new Color(0f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 7)
			{
				skinColor2 = new Color(1f, 1f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 8)
			{
				skinColor2 = new Color(0.5f, 1f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 9)
			{
				skinColor2 = new Color(1f, 0.7f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 10)
			{
				skinColor2 = new Color(1f, 0f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 11)
			{
				skinColor2 = new Color(0f, 1f, 0f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 12)
			{
				skinColor2 = new Color(0f, 0f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 13)
			{
				skinColor2 = new Color(0.5f, 0f, 0.5f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
			else if (player2Skin == 14)
			{
				skinColor2 = new Color(1f, 0f, 1f, 1f);
				Skin2.GetComponent<SpriteRenderer>().color = skinColor2;
			}
		}
	}

	public void AddSkinRandom()
	{
		int num = UnityEngine.Random.Range(0, 5);
		if (num != 1)
		{
			return;
		}
		int i = 0;
		int num2 = UnityEngine.Random.Range(1, 26);
		int num3 = (int)Mathf.Pow(2f, num2);
		int skinNumber = SkinNumber;
		int num4 = 0;
		for (; SkinNumber - (int)Mathf.Pow(2f, i) >= 0; i++)
		{
			limitNumber = (int)Mathf.Pow(2f, i);
		}
		if ((skinNumber & num3) == 0)
		{
			UnityEngine.Debug.Log("New SKIN");
			PlayerPrefs.SetInt("skin", SkinNumber + num3);
			SkinNumber = PlayerPrefs.GetInt("skin", 1);
			GameObject.Find("SkinSuccess").gameObject.GetComponent<SpriteRenderer>().enabled = true;
			SkinWinAffiche = GameObject.Find("SkinSuccess");
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
			source.PlayOneShot(successSound);
			if (Survival)
			{
				Transform transform = SkinWinAffiche.transform;
				Vector3 position = SkinWinAffiche.transform.position;
				transform.localPosition = new Vector3(-150.24f, -116.44f, position.z);
				Invoke("desactivateSkin", 2f);
			}
		}
		else
		{
			UnityEngine.Debug.Log("SKIN déja possédé");
		}
	}

	private void desactivateSkin()
	{
		if (Survival && SceneManager.GetActiveScene().name == "duel")
		{
			GameObject.Find("SkinSuccess").gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
