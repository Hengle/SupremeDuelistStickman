using UnityEngine;

public class Trap : MonoBehaviour
{
	public GameObject piege;

	public bool Etat;

	public int timeDisapear;

	public Vector3 Pos1;

	public Vector3 Pos2;

	public GameObject SecondPart;

	public GameObject ParentPart;

	public bool Fixe;

	public Color ColorGrenade;

	public GameObject Explose;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		timeDisapear = 0;
		Etat = false;
		piege.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		base.gameObject.transform.parent = base.gameObject.transform.parent;
	}

	private void OnEnable()
	{
		timeDisapear = 0;
		Etat = false;
		piege.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		base.gameObject.transform.parent = base.gameObject.transform.parent;
	}

	private void OnDisable()
	{
		Etat = false;
		timeDisapear = 0;
		piege.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		base.gameObject.transform.parent = base.gameObject.transform.parent;
	}

	private void FixedUpdate()
	{
		if (Etat)
		{
			timeDisapear++;
			if (timeDisapear > 2)
			{
				timeDisapear = 0;
				base.gameObject.SetActive(value: false);
				Explose.transform.position = base.gameObject.transform.position;
				Explose.gameObject.SetActive(value: true);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer == 8 || coll.gameObject.layer == 11 || coll.gameObject.tag == "arme")
		{
			if (source == null)
			{
				source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
			}
			source.PlayOneShot(PowerAbility, 0.2f);
			Etat = true;
			piege.gameObject.GetComponent<SpriteRenderer>().color = ColorGrenade;
		}
	}
}
