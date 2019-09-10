using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
	public GameManager GameManag;

	public GameObject EndMessage;

	public GameObject RateButton;

	public BoxCollider2D Yes;

	public BoxCollider2D No;

	public GameObject RightJoy;

	public GameObject LeftJoy;

	public Rigidbody2D rbjoueur1;

	public Rigidbody2D rbjoueur2;

	public bool STOP;

	public int timeToReset = 1;

	public bool doubleObject;

	public bool Bomb;

	private void Start()
	{
		GameManag = GameObject.Find("GameManager").GetComponent<GameManager>();
		RateButton = GameObject.Find("Rate");
		Yes = GameObject.Find("Yes").GetComponent<BoxCollider2D>();
		No = GameObject.Find("No").GetComponent<BoxCollider2D>();
		RightJoy = GameObject.Find("Right Joystick");
		LeftJoy = GameObject.Find("Left Joystick");
		EndMessage = GameObject.Find("EndMessage");
		rbjoueur1 = GameObject.Find("Tete").GetComponent<Rigidbody2D>();
		rbjoueur2 = GameObject.Find("Tete (3)").GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (timeToReset > 1)
		{
			timeToReset--;
			if (timeToReset == 2)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			for (int i = 0; i < UnityEngine.Input.touchCount; i++)
			{
				if (UnityEngine.Input.GetTouch(i).phase == TouchPhase.Began)
				{
					checkTouch(UnityEngine.Input.GetTouch(i).position);
				}
			}
		}
		if (timeToReset == 40)
		{
			TransisionScene[] array = Resources.FindObjectsOfTypeAll<TransisionScene>();
			for (int j = 0; j < array.Length; j++)
			{
				array[j].gameObject.SetActive(value: false);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (STOP)
		{
			return;
		}
		if ((coll.gameObject.layer == 11 && coll.gameObject.transform.name != "Slice Teleportation") || (coll.gameObject.GetComponent<Boot>() != null && coll.gameObject.layer != 18))
		{
			endgame[] array = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component = EndMessage.GetComponent<SpriteRenderer>();
			Color color = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float r = color.r;
			Color color2 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float g = color2.g;
			Color color3 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			component.color = new Color(r, g, color3.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.GaucheVictory++;
			GameManag.AddSkinRandom();
			if (GameManag.nombreParty >= 7 && PlayerPrefs.GetInt("hasRated", 0) == 0)
			{
				Yes.enabled = true;
				No.enabled = true;
				RateButton.GetComponent<SpriteRenderer>().enabled = true;
				RightJoy.SetActive(value: false);
				LeftJoy.SetActive(value: false);
			}
		}
		if ((coll.gameObject.layer == 8 && coll.gameObject.transform.name != "Slice Teleportation") || (coll.gameObject.GetComponent<Boot>() != null && coll.gameObject.layer != 19))
		{
			endgame[] array2 = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component2 = EndMessage.GetComponent<SpriteRenderer>();
			Color color4 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float r2 = color4.r;
			Color color5 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float g2 = color5.g;
			Color color6 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			component2.color = new Color(r2, g2, color6.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.DroiteVictory++;
			GameManag.AddSkinRandom();
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		UnityEngine.Debug.Log("bomb coll");
		if (STOP)
		{
			return;
		}
		if ((coll.gameObject.layer == 11 && coll.gameObject.transform.name != "Slice Teleportation") || (coll.gameObject.GetComponent<Boot>() != null && coll.gameObject.layer != 18))
		{
			endgame[] array = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component = EndMessage.GetComponent<SpriteRenderer>();
			Color color = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float r = color.r;
			Color color2 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float g = color2.g;
			Color color3 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			component.color = new Color(r, g, color3.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.GaucheVictory++;
			GameManag.AddSkinRandom();
			if (GameManag.nombreParty >= 7 && PlayerPrefs.GetInt("hasRated", 0) == 0)
			{
				Yes.enabled = true;
				No.enabled = true;
				RateButton.GetComponent<SpriteRenderer>().enabled = true;
				RightJoy.SetActive(value: false);
				LeftJoy.SetActive(value: false);
			}
		}
		if ((coll.gameObject.layer == 8 && coll.gameObject.transform.name != "Slice Teleportation") || (coll.gameObject.GetComponent<Boot>() != null && coll.gameObject.layer != 19))
		{
			endgame[] array2 = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component2 = EndMessage.GetComponent<SpriteRenderer>();
			Color color4 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float r2 = color4.r;
			Color color5 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float g2 = color5.g;
			Color color6 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			component2.color = new Color(r2, g2, color6.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.DroiteVictory++;
			GameManag.AddSkinRandom();
		}
		if (coll.gameObject.layer != 20 || !Bomb)
		{
			return;
		}
		if (coll.gameObject.transform.parent.name == "Perso")
		{
			endgame[] array3 = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component3 = EndMessage.GetComponent<SpriteRenderer>();
			Color color7 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float r3 = color7.r;
			Color color8 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			float g3 = color8.g;
			Color color9 = GameObject.Find("Tete (3)").GetComponent<SpriteRenderer>().color;
			component3.color = new Color(r3, g3, color9.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.DroiteVictory++;
			GameManag.AddSkinRandom();
		}
		if (coll.gameObject.transform.parent.name == "Perso 2")
		{
			endgame[] array4 = UnityEngine.Object.FindObjectsOfType<endgame>();
			for (int l = 0; l < array4.Length; l++)
			{
				array4[l].GetComponent<Collider2D>().enabled = false;
			}
			if (doubleObject)
			{
			}
			EndMessage.GetComponent<SpriteRenderer>().enabled = true;
			SpriteRenderer component4 = EndMessage.GetComponent<SpriteRenderer>();
			Color color10 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float r4 = color10.r;
			Color color11 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			float g4 = color11.g;
			Color color12 = GameObject.Find("Tete").GetComponent<SpriteRenderer>().color;
			component4.color = new Color(r4, g4, color12.b, 1f);
			STOP = true;
			rbjoueur1.constraints = RigidbodyConstraints2D.FreezeAll;
			rbjoueur2.constraints = RigidbodyConstraints2D.FreezeAll;
			timeToReset = 200;
			GameManag.nombreParty++;
			GameManag.GaucheVictory++;
			GameManag.AddSkinRandom();
			if (GameManag.nombreParty >= 20 && PlayerPrefs.GetInt("hasRated", 0) == 0)
			{
				Yes.enabled = true;
				No.enabled = true;
				RateButton.GetComponent<SpriteRenderer>().enabled = true;
				RightJoy.SetActive(value: false);
				LeftJoy.SetActive(value: false);
			}
		}
	}

	private void checkTouch(Vector3 pos)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(pos);
		Vector2 point = new Vector2(vector.x, vector.y);
		Collider2D collider2D = Physics2D.OverlapPoint(point);
		if ((bool)collider2D)
		{
			if (collider2D.transform.name == "Yes")
			{
				PlayerPrefs.SetInt("hasRated", 1);
				Application.OpenURL("market://details?id=com.Neurononfire.SupremeDuelist");
			}
			if (collider2D.transform.name == "No")
			{
				PlayerPrefs.SetInt("hasRated", 1);
				Yes.enabled = false;
				No.enabled = false;
				RateButton.GetComponent<SpriteRenderer>().enabled = false;
				RightJoy.SetActive(value: true);
				LeftJoy.SetActive(value: true);
			}
		}
	}
}
