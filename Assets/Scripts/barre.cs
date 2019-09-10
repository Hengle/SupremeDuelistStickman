using UnityEngine;
using UnityEngine.SceneManagement;

public class barre : MonoBehaviour
{
	public float Hp;

	public float HpMemo;

	public float HeightBarre;

	public GameObject EndMessage;

	public bool STOP;

	public int timeToReset = 1;

	public int chanceAds;

	public TextMesh score;

	public TextMesh highScore;

	public float TimeRecord;

	public bool SurvivalModeOff;

	public barre AutreJoueurVie;

	public bool playerOne;

	public int TimeDisappeair;

	public SpriteRenderer TexteVert;

	public SpriteRenderer TexteRouge;

	private GameManager OptionPlay;

	public bool RewardActif;

	public TextMesh scoreText;

	public TextMesh bestScoreText;

	public bool AdRewardEnable;

	public bool RewardDisplay;

	public SurvivorMapGeneration survivalSystem;

	private void Start()
	{
		OptionPlay = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (!SurvivalModeOff)
		{
			highScore.text = "Best Score : " + PlayerPrefs.GetFloat("HighScore", 0f).ToString();
		}
		TimeDisappeair = 100;
		Vector3 localScale = base.transform.localScale;
		HeightBarre = localScale.y;
		EndMessage = GameObject.Find("EndMessage");
	}

	private void FixedUpdate()
	{
		if (RewardDisplay)
		{
			RewardDisplay = false;
			TextMesh textMesh = score;
			Color color = score.color;
			float r = color.r;
			Color color2 = score.color;
			float g = color2.g;
			Color color3 = score.color;
			textMesh.color = new Color(r, g, color3.b, 1f);
			scoreText.text = string.Empty;
			bestScoreText.text = string.Empty;
			SpriteRenderer[] array = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.name == "Watch Video" || array[i].gameObject.name == "Replay Survival")
				{
					array[i].gameObject.SetActive(value: false);
				}
			}
			skinad[] array2 = Resources.FindObjectsOfTypeAll<skinad>();
			for (int j = 0; j < array2.Length; j++)
			{
				if (array2[j].gameObject.GetComponent<Rigidbody2D>() != null)
				{
					array2[j].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				}
			}
			Transform[] array3 = UnityEngine.Object.FindObjectsOfType<Transform>();
			for (int k = 0; k < array3.Length; k++)
			{
				if (array3[k].gameObject.tag == "efface")
				{
					array3[k].gameObject.SetActive(value: false);
				}
			}
			barre[] array4 = UnityEngine.Object.FindObjectsOfType<barre>();
			for (int l = 0; l < array4.Length; l++)
			{
				array4[l].Hp = 1f;
				array4[l].HpMemo = 1f;
				array4[l].STOP = false;
			}
		}
		if (HpMemo != Hp)
		{
			TimeDisappeair = 100;
		}
		HpMemo = Hp;
		if (TimeDisappeair > 0)
		{
			TimeDisappeair--;
			Color color4 = TexteRouge.color;
			if (color4.a < 1f)
			{
				SpriteRenderer texteVert = TexteVert;
				Color color5 = TexteVert.color;
				float r2 = color5.r;
				Color color6 = TexteVert.color;
				float g2 = color6.g;
				Color color7 = TexteVert.color;
				texteVert.color = new Color(r2, g2, color7.b, 1f);
				SpriteRenderer texteRouge = TexteRouge;
				Color color8 = TexteRouge.color;
				float r3 = color8.r;
				Color color9 = TexteRouge.color;
				float g3 = color9.g;
				Color color10 = TexteRouge.color;
				texteRouge.color = new Color(r3, g3, color10.b, 1f);
			}
		}
		else
		{
			Color color11 = TexteRouge.color;
			if (color11.a > 0f)
			{
				SpriteRenderer texteVert2 = TexteVert;
				Color color12 = TexteVert.color;
				float r4 = color12.r;
				Color color13 = TexteVert.color;
				float g4 = color13.g;
				Color color14 = TexteVert.color;
				texteVert2.color = new Color(r4, g4, color14.b, 0f);
				SpriteRenderer texteRouge2 = TexteRouge;
				Color color15 = TexteRouge.color;
				float r5 = color15.r;
				Color color16 = TexteRouge.color;
				float g5 = color16.g;
				Color color17 = TexteRouge.color;
				texteRouge2.color = new Color(r5, g5, color17.b, 0f);
			}
		}
		if (timeToReset > 1)
		{
			timeToReset--;
			if (timeToReset == 2)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
		if (Hp <= 0f)
		{
			Hp = 0f;
			if (!STOP)
			{
				GameObject.Find("Tete").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
				if (!OptionPlay.TwoPlayerSurvival)
				{
					if (SurvivalModeOff)
					{
						GameObject.Find("Tete (3)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
						if (!EndMessage.GetComponent<SpriteRenderer>().enabled)
						{
							endgame[] array5 = UnityEngine.Object.FindObjectsOfType<endgame>();
							for (int m = 0; m < array5.Length; m++)
							{
								array5[m].GetComponent<Collider2D>().enabled = false;
							}
							EndMessage.GetComponent<SpriteRenderer>().enabled = true;
							if (!playerOne)
							{
								SpriteRenderer component = EndMessage.GetComponent<SpriteRenderer>();
								Color color18 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
								float r6 = color18.r;
								Color color19 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
								float g6 = color19.g;
								Color color20 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
								component.color = new Color(r6, g6, color20.b, 1f);
								timeToReset = 200;
								OptionPlay.DroiteVictory++;
							}
							else
							{
								SpriteRenderer component2 = EndMessage.GetComponent<SpriteRenderer>();
								Color color21 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
								float r7 = color21.r;
								Color color22 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
								float g7 = color22.g;
								Color color23 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
								component2.color = new Color(r7, g7, color23.b, 1f);
								timeToReset = 200;
								OptionPlay.GaucheVictory++;
								OptionPlay.AddSkinRandom();
							}
						}
					}
				}
				else
				{
					GameObject.Find("Tete (3)").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
					TextMesh textMesh2 = score;
					Color color24 = score.color;
					float r8 = color24.r;
					Color color25 = score.color;
					float g8 = color25.g;
					Color color26 = score.color;
					textMesh2.color = new Color(r8, g8, color26.b, 0f);
					if (AutreJoueurVie.TimeRecord > PlayerPrefs.GetFloat("HighScore", 0f))
					{
						PlayerPrefs.SetFloat("HighScore", TimeRecord);
					}
					OptionPlay.AddSkinRandom();
					scoreText = GameObject.Find("Text Score").GetComponent<TextMesh>();
					scoreText.text = "Score : " + AutreJoueurVie.TimeRecord;
					bestScoreText = GameObject.Find("Best Text Score").GetComponent<TextMesh>();
					bestScoreText.text = "Best Score : " + PlayerPrefs.GetFloat("HighScore", 0f);
					SpriteRenderer[] array6 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
					for (int n = 0; n < array6.Length; n++)
					{
						if (array6[n].gameObject.name == "Replay Survival")
						{
							array6[n].gameObject.SetActive(value: true);
						}
						if (survivalSystem.NumberReset > 0 && array6[n].gameObject.name == "Watch Video")
						{
							array6[n].gameObject.SetActive(value: true);
							survivalSystem.NumberReset--;
						}
					}
					Transform[] array7 = UnityEngine.Object.FindObjectsOfType<Transform>();
					for (int num = 0; num < array7.Length; num++)
					{
						if (array7[num].gameObject.tag == "efface")
						{
							array7[num].gameObject.SetActive(value: false);
						}
					}
					skinad[] array8 = Resources.FindObjectsOfTypeAll<skinad>();
					for (int num2 = 0; num2 < array8.Length; num2++)
					{
						if (array8[num2].gameObject.GetComponent<Rigidbody2D>() != null)
						{
							array8[num2].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
						}
					}
				}
				STOP = true;
				if (!SurvivalModeOff)
				{
					timeToReset = 0;
				}
				if (!SurvivalModeOff)
				{
					TextMesh textMesh3 = score;
					Color color27 = score.color;
					float r9 = color27.r;
					Color color28 = score.color;
					float g9 = color28.g;
					Color color29 = score.color;
					textMesh3.color = new Color(r9, g9, color29.b, 0f);
					if (TimeRecord > PlayerPrefs.GetFloat("HighScore", 0f))
					{
						PlayerPrefs.SetFloat("HighScore", TimeRecord);
					}
					OptionPlay.AddSkinRandom();
					scoreText = GameObject.Find("Text Score").GetComponent<TextMesh>();
					scoreText.text = "Score : " + TimeRecord;
					bestScoreText = GameObject.Find("Best Text Score").GetComponent<TextMesh>();
					bestScoreText.text = "Best Score : " + PlayerPrefs.GetFloat("HighScore", 0f);
					SpriteRenderer[] array9 = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
					for (int num3 = 0; num3 < array9.Length; num3++)
					{
						if (array9[num3].gameObject.name == "Replay Survival")
						{
							array9[num3].gameObject.SetActive(value: true);
						}
						if (survivalSystem.NumberReset > 0 && array9[num3].gameObject.name == "Watch Video")
						{
							array9[num3].gameObject.SetActive(value: true);
							survivalSystem.NumberReset--;
						}
					}
					Transform[] array10 = UnityEngine.Object.FindObjectsOfType<Transform>();
					for (int num4 = 0; num4 < array10.Length; num4++)
					{
						if (array10[num4].gameObject.tag == "efface")
						{
							array10[num4].gameObject.SetActive(value: false);
						}
					}
					skinad[] array11 = Resources.FindObjectsOfTypeAll<skinad>();
					for (int num5 = 0; num5 < array11.Length; num5++)
					{
						if (array11[num5].gameObject.GetComponent<Rigidbody2D>() != null)
						{
							array11[num5].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
						}
					}
				}
			}
			for (int num6 = 0; num6 < UnityEngine.Input.touchCount; num6++)
			{
				if (UnityEngine.Input.GetTouch(num6).phase == TouchPhase.Began)
				{
					finPartie(UnityEngine.Input.GetTouch(num6).position);
				}
			}
		}
		if (!SurvivalModeOff)
		{
			score.text = Mathf.RoundToInt(TimeRecord).ToString();
		}
		base.transform.localPosition = new Vector2(Hp / 2f - 0.5f, 0f);
		base.transform.localScale = new Vector2(Hp, HeightBarre);
	}

	private void finPartie(Vector3 pos)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(pos);
		Vector2 point = new Vector2(vector.x, vector.y);
		Collider2D collider2D = Physics2D.OverlapPoint(point);
		if ((bool)collider2D)
		{
			if (collider2D.transform.name == "Watch Video")
			{
				AdManager.Instance.ShowRewardVideo();
			}
			if (collider2D.transform.name == "Replay Survival")
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
