using UnityEngine;

public class skinad : MonoBehaviour
{
	private GameManager SkinChoose;

	public bool Player1;

	public int layer;

	public int invincib;

	private Equilibre equil;

	public GameObject Corps1;

	public GameObject Corps2;

	public PlayerDirection FollowPlayer1;

	public bool AiPart;

	public GameObject AIParent;

	public Equilibre corpsCode1;

	public Equilibre corpsCode2;

	public Pied PiedCode1;

	public Pied PiedCode2;

	public Jambe JambeCode1;

	public Jambe JambeCode2;

	public int Desactive = -5;

	public GameObject AIAllBody;

	public GameObject BoutAi;

	public float hauteur;

	public barre JoueurVIe;

	public barre JoueurVIe2;

	public float ImpactPower = 10f;

	public AudioSource source;

	public AudioClip CoupStickman1;

	public AudioClip CoupStickman2;

	public AudioClip CoupStickman3;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public int randomFrappe;

	public float BonusScore;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		layer = base.gameObject.layer;
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (!Player1)
		{
			GetComponent<SpriteRenderer>().color = SkinChoose.skinColor;
		}
		else if (!AiPart)
		{
			GetComponent<SpriteRenderer>().color = SkinChoose.skinColor2;
		}
		else
		{
			GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
		}
		if (!Player1)
		{
			Corps1 = GameObject.Find("Corps");
			Corps2 = GameObject.Find("Corps 2");
		}
		else
		{
			Corps1 = GameObject.Find("Corps d");
			Corps2 = GameObject.Find("Corps 2 d");
		}
	}

	private void OnEnable()
	{
		if (AiPart)
		{
			Vector3 localPosition = base.transform.localPosition;
			hauteur = localPosition.y;
			Transform[] componentsInChildren = AIParent.gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = 11;
			}
		}
	}

	private void OnDisable()
	{
		if (AiPart)
		{
			Desactive = -5;
			FollowPlayer1.enabled = true;
			corpsCode1.enabled = true;
			corpsCode2.enabled = true;
			PiedCode1.enabled = true;
			PiedCode2.enabled = true;
			JambeCode1.enabled = true;
			JambeCode2.enabled = true;
			base.transform.localPosition = new Vector2(0f, hauteur);
			base.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
			BoutAi.transform.localPosition = new Vector2(0f, 1.5f);
			BoutAi.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
		}
	}

	private void FixedUpdate()
	{
		if (invincib > -1)
		{
			invincib--;
		}
		if (invincib == 0)
		{
			if (!AiPart)
			{
				if (!SkinChoose.TwoPlayerSurvival)
				{
					base.gameObject.layer = layer;
				}
				if (SkinChoose.TwoPlayerSurvival)
				{
					base.gameObject.layer = 8;
				}
			}
			else
			{
				base.gameObject.layer = layer;
			}
		}
		if (Desactive > 0)
		{
			Desactive--;
		}
		if (Desactive == 0)
		{
			AIAllBody.SetActive(value: false);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer == 8 || coll.gameObject.layer == 11)
		{
			invincib += 20;
			if (invincib >= 70)
			{
				base.gameObject.layer = 20;
			}
		}
		if (coll.gameObject.CompareTag("arme"))
		{
			equil = Corps1.gameObject.GetComponent<Equilibre>();
			equil.stun = equil.stun + coll.relativeVelocity.magnitude * 3f + 100f;
			equil = Corps2.gameObject.GetComponent<Equilibre>();
			equil.stun = equil.stun + coll.relativeVelocity.magnitude * 3f + 100f;
			if (AiPart && coll.relativeVelocity.magnitude > ImpactPower && FollowPlayer1.enabled)
			{
				FollowPlayer1.enabled = false;
				corpsCode1.enabled = false;
				corpsCode2.enabled = false;
				PiedCode1.enabled = false;
				PiedCode2.enabled = false;
				JambeCode1.enabled = false;
				JambeCode2.enabled = false;
				Desactive = 100;
				if (JoueurVIe.Hp > 0f)
				{
					JoueurVIe.TimeRecord = JoueurVIe.TimeRecord + 1f + BonusScore;
				}
			}
		}
		if (coll.gameObject.layer != 8 || !(coll.gameObject.transform.name != "Slice Teleportation") || !AiPart || !FollowPlayer1.enabled)
		{
			return;
		}
		if (coll.transform.parent.gameObject.name == "Perso")
		{
			JoueurVIe.Hp -= 0.014f;
		}
		if (GameObject.Find("Perso 2") != null && coll.transform.parent.gameObject.name == "Perso 2")
		{
			JoueurVIe2.Hp -= 0.014f;
		}
		randomFrappe = UnityEngine.Random.Range(0, 4);
		if (randomFrappe != 2)
		{
			return;
		}
		ContactPoint2D[] contacts = coll.contacts;
		for (int i = 0; i < contacts.Length; i++)
		{
			ContactPoint2D contactPoint2D = contacts[i];
			explsionActiveKnockBack[] array = Resources.FindObjectsOfTypeAll<explsionActiveKnockBack>();
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].transform.name == "explosion (2)")
				{
					array[j].gameObject.SetActive(value: false);
					array[j].gameObject.SetActive(value: true);
					GameObject.Find("RedKnockback2").GetComponent<PointEffector2D>().forceMagnitude = 1000f;
					array[j].transform.position = contactPoint2D.point;
				}
				int num = UnityEngine.Random.Range(0, 3);
				if (num == 0)
				{
					source.PlayOneShot(CoupStickman1);
				}
				if (num == 1)
				{
					source.PlayOneShot(CoupStickman2);
				}
				if (num == 2)
				{
					source.PlayOneShot(CoupStickman3);
				}
			}
		}
	}
}
