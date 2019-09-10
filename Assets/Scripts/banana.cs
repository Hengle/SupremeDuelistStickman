using UnityEngine;

public class banana : MonoBehaviour
{
	public bool Etat;

	public int timeDisapear;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public GameObject Parentstick;

	public Rigidbody2D Corps1;

	public Rigidbody2D Corps2;

	public float rotationSide;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		timeDisapear = 0;
		Etat = false;
	}

	private void OnEnable()
	{
		timeDisapear = 0;
		Etat = false;
	}

	private void OnDisable()
	{
		if (Corps1 != null)
		{
			Corps1.drag = 0f;
			Corps2.drag = 0f;
			if ((bool)Corps1.gameObject.GetComponent<Equilibre>())
			{
				Corps1.gameObject.GetComponent<Equilibre>().enabled = true;
			}
			if ((bool)Corps2.gameObject.GetComponent<Equilibre>())
			{
				Corps2.gameObject.GetComponent<Equilibre>().enabled = true;
			}
			Corps1 = null;
			Corps2 = null;
		}
		Etat = false;
		timeDisapear = 0;
	}

	private void FixedUpdate()
	{
		if (!Etat)
		{
			return;
		}
		timeDisapear--;
		Corps1.AddTorque(rotationSide * Time.deltaTime, ForceMode2D.Impulse);
		Corps2.AddTorque(rotationSide * Time.deltaTime, ForceMode2D.Impulse);
		if (timeDisapear == 1)
		{
			Corps1.drag = 0f;
			Corps2.drag = 0f;
			if ((bool)Corps1.gameObject.GetComponent<Equilibre>())
			{
				Corps1.gameObject.GetComponent<Equilibre>().enabled = true;
			}
			if ((bool)Corps2.gameObject.GetComponent<Equilibre>())
			{
				Corps2.gameObject.GetComponent<Equilibre>().enabled = true;
			}
			Corps1 = null;
			Corps2 = null;
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (Etat || (coll.gameObject.layer != 8 && coll.gameObject.layer != 11))
		{
			return;
		}
		Parentstick = coll.transform.parent.gameObject;
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			rotationSide = 500f;
		}
		else
		{
			rotationSide = -500f;
		}
		Rigidbody2D[] componentsInChildren = Parentstick.gameObject.GetComponentsInChildren<Rigidbody2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].gameObject.CompareTag("pointfaible"))
			{
				continue;
			}
			if (Corps1 == null)
			{
				Corps1 = componentsInChildren[i];
				Corps1.drag = 100f;
				if ((bool)Corps1.gameObject.GetComponent<Equilibre>())
				{
					Corps1.gameObject.GetComponent<Equilibre>().enabled = false;
				}
			}
			else
			{
				Corps2 = componentsInChildren[i];
				Corps2.drag = 100f;
				if ((bool)Corps2.gameObject.GetComponent<Equilibre>())
				{
					Corps2.gameObject.GetComponent<Equilibre>().enabled = false;
				}
			}
		}
		Etat = true;
		timeDisapear = 40;
	}
}
