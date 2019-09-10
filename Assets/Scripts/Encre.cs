using UnityEngine;

public class Encre : MonoBehaviour
{
	public LineRenderer TraitEncre;

	public Transform encreOrigin;

	public Transform traitFin;

	public int state;

	public int count;

	public GameObject Pinceau;

	public GameObject[] Solid;

	public bool Isblue;

	public float angleRot;

	public Rigidbody2D CorpsGrab;

	public float Dist;

	public PlayerDirection Dir;

	public bool Col;

	public GameObject bloc;

	public AudioSource source;

	public AudioClip PowerAbilityLink;

	public AudioClip PowerAbilitySolid;

	public AudioClip PowerAbilityCaisse;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		TraitEncre = base.gameObject.GetComponent<LineRenderer>();
		traitFin = base.gameObject.GetComponent<Transform>();
		state = 0;
		count = 0;
		Col = false;
	}

	public void OnEnable()
	{
		base.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		base.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		Pinceau.gameObject.GetComponent<DistanceJoint2D>().enabled = false;
		Pinceau.gameObject.GetComponent<DistanceJoint2D>().connectedBody = null;
		traitFin = base.gameObject.GetComponent<Transform>();
		state = 0;
		count = 0;
		Col = false;
	}

	public void OnDisable()
	{
		if (state == 1)
		{
			Pinceau.gameObject.GetComponent<DistanceJoint2D>().enabled = false;
			Pinceau.gameObject.GetComponent<DistanceJoint2D>().connectedBody = null;
			CorpsGrab = null;
		}
		count = 0;
		Col = false;
	}

	public void LateUpdate()
	{
		LineRenderer traitEncre = TraitEncre;
		Vector3 position = encreOrigin.transform.position;
		float x = position.x;
		Vector3 position2 = encreOrigin.transform.position;
		traitEncre.SetPosition(0, new Vector3(x, position2.y, 0f));
		LineRenderer traitEncre2 = TraitEncre;
		Vector3 position3 = traitFin.transform.position;
		float x2 = position3.x;
		Vector3 position4 = traitFin.transform.position;
		traitEncre2.SetPosition(1, new Vector3(x2, position4.y, 0f));
	}

	private void FixedUpdate()
	{
		count++;
		if (count == 30 && state == 0)
		{
			state = 3;
			Col = true;
			base.gameObject.GetComponent<CircleCollider2D>().enabled = false;
			base.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			base.gameObject.SetActive(value: false);
			source.PlayOneShot(PowerAbilityCaisse);
			for (int i = 0; i < Solid.Length; i++)
			{
				if (!Solid[i].gameObject.activeInHierarchy)
				{
					Solid[i].gameObject.transform.position = (traitFin.transform.position + encreOrigin.transform.position) / 2f;
					Vector3 position = traitFin.transform.position;
					float y = position.y;
					Vector3 position2 = encreOrigin.transform.position;
					float y2 = y - position2.y;
					Vector3 position3 = traitFin.transform.position;
					float x = position3.x;
					Vector3 position4 = encreOrigin.transform.position;
					float num = Mathf.Atan2(y2, x - position4.x) * 57.29578f;
					Solid[i].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
					Solid[i].gameObject.GetComponent<solidEncre>().enabled = true;
					Solid[i].gameObject.GetComponent<solidEncre>().Box.gameObject.SetActive(value: true);
					Solid[i].gameObject.GetComponent<solidEncre>().barAcier.gameObject.SetActive(value: false);
					Solid[i].gameObject.transform.rotation = Quaternion.AngleAxis(num - angleRot, Vector3.forward);
					Solid[i].gameObject.transform.localScale = new Vector3((traitFin.transform.position - encreOrigin.transform.position).magnitude, 1f, 1f);
					if (Isblue)
					{
						Solid[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
					}
					else
					{
						Solid[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
					}
					Solid[i].gameObject.tag = "arme";
					Solid[i].gameObject.SetActive(value: true);
					Solid[i].gameObject.GetComponent<DestroyInTime>().time = -30;
					break;
				}
			}
		}
		if (state == 1)
		{
			if (!traitFin.gameObject.activeInHierarchy)
			{
				base.gameObject.SetActive(value: false);
			}
			else
			{
				CorpsGrab.AddForce(Dir.direction * (100f * (Dist / 7f)), ForceMode2D.Force);
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (Col || count <= 3 || state == 3)
		{
			return;
		}
		if (coll.gameObject.layer == 8 || coll.gameObject.layer == 9 || coll.gameObject.layer == 11 || coll.gameObject.layer == 12 || coll.gameObject.layer == 18 || coll.gameObject.layer == 19 || coll.gameObject.layer == 16)
		{
			if (!coll.gameObject.GetComponent<Encre>())
			{
				source.PlayOneShot(PowerAbilityLink);
				state = 1;
				base.gameObject.GetComponent<CircleCollider2D>().enabled = false;
				base.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				Pinceau.gameObject.GetComponent<DistanceJoint2D>().enabled = true;
				Pinceau.gameObject.GetComponent<DistanceJoint2D>().connectedBody = coll.gameObject.GetComponent<Rigidbody2D>();
				CorpsGrab = coll.gameObject.GetComponent<Rigidbody2D>();
				traitFin = coll.gameObject.GetComponent<Transform>();
				base.gameObject.GetComponent<DestroyInTime>().time = base.gameObject.GetComponent<DestroyInTime>().time - (int)(traitFin.transform.position - encreOrigin.transform.position).magnitude * 2;
				Dist = (traitFin.transform.position - encreOrigin.transform.position).magnitude;
				Col = true;
			}
		}
		else
		{
			if (coll.gameObject.CompareTag("Untagged") && coll.gameObject.layer == 10)
			{
				return;
			}
			state = 2;
			Col = true;
			base.gameObject.GetComponent<CircleCollider2D>().enabled = false;
			base.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			base.gameObject.SetActive(value: false);
			source.PlayOneShot(PowerAbilitySolid);
			int num = 0;
			while (true)
			{
				if (num < Solid.Length)
				{
					if (!Solid[num].gameObject.activeInHierarchy)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Solid[num].gameObject.transform.position = (traitFin.transform.position + encreOrigin.transform.position) / 2f;
			Vector3 position = traitFin.transform.position;
			float y = position.y;
			Vector3 position2 = encreOrigin.transform.position;
			float y2 = y - position2.y;
			Vector3 position3 = traitFin.transform.position;
			float x = position3.x;
			Vector3 position4 = encreOrigin.transform.position;
			float num2 = Mathf.Atan2(y2, x - position4.x) * 57.29578f;
			Solid[num].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			Solid[num].gameObject.GetComponent<solidEncre>().enabled = false;
			Solid[num].gameObject.GetComponent<solidEncre>().barAcier.gameObject.SetActive(value: true);
			Solid[num].gameObject.GetComponent<solidEncre>().Box.gameObject.SetActive(value: false);
			Solid[num].gameObject.transform.rotation = Quaternion.AngleAxis(num2 - angleRot, Vector3.forward);
			Solid[num].gameObject.transform.localScale = new Vector3((traitFin.transform.position - encreOrigin.transform.position).magnitude, 1f, 1f);
			Solid[num].gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
			Solid[num].gameObject.tag = "rebond";
			Solid[num].gameObject.SetActive(value: true);
			Solid[num].gameObject.GetComponent<DestroyInTime>().time = -80;
		}
	}
}
