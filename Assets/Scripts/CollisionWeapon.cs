using UnityEngine;

public class CollisionWeapon : MonoBehaviour
{
	public bool AttackOnlyEnnemy;

	public bool BlueObject;

	public bool RedObject;

	public GameObject collision;

	public Rigidbody2D rbAutreCollider;

	public Rigidbody2D Membre;

	public float chocpowerWeapon;

	public float chocpowerTete;

	public float chocpowerMember;

	public float chocpowerSmallMember;

	public float TimeReCollision = 30f;

	private PlayerDirection DirPlayer;

	public GameObject PlayerBout;

	public Rigidbody2D CorpsDeAutreStick;

	public float attenuation;

	public barre AutreJoueur;

	public float DAMAGE;

	public int TimeCollision;

	public AudioSource source;

	public AudioClip CoupArme;

	public AudioClip CoupArme2;

	public AudioClip CoupArme3;

	public AudioClip CoupStickman1;

	public AudioClip CoupStickman2;

	public AudioClip CoupStickman3;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
		Membre = GetComponent<Rigidbody2D>();
		if (source == null)
		{
			source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
	}

	private void OnEnable()
	{
		Membre = GetComponent<Rigidbody2D>();
		TimeReCollision = -1f;
		TimeCollision = -1;
		if (source == null)
		{
			source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
	}

	private void FixedUpdate()
	{
		source.volume = gManag.Volume;
		TimeReCollision -= 1f;
		TimeCollision--;
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (AttackOnlyEnnemy && (!AttackOnlyEnnemy || !BlueObject || coll.gameObject.layer != 11) && (!AttackOnlyEnnemy || !RedObject || coll.gameObject.layer != 8))
		{
			return;
		}
		float num = Membre.velocity.magnitude * 10f;
		if (num > 200f)
		{
			num = 200f;
		}
		if (TimeCollision < 0)
		{
			if (coll.gameObject.CompareTag("pointfaible"))
			{
				AutreJoueur.Hp -= DAMAGE / 1.5f;
			}
			if (coll.gameObject.CompareTag("membre"))
			{
				AutreJoueur.Hp -= DAMAGE / 2f;
			}
			if (coll.gameObject.CompareTag("tete"))
			{
				AutreJoueur.Hp -= DAMAGE / 1.2f;
			}
		}
		if (!(TimeReCollision < 0f))
		{
			return;
		}
		if (coll.gameObject.CompareTag("arme"))
		{
			ContactPoint2D[] contacts = coll.contacts;
			for (int i = 0; i < contacts.Length; i++)
			{
				ContactPoint2D contactPoint2D = contacts[i];
				Vector3 vector = contactPoint2D.point;
				num += 30f;
				if (PlayerBout != null)
				{
					PlayerBout.GetComponent<PlayerDirection>().stunBras = (num - 30f) / 2f;
				}
				if (num > 80f)
				{
					num = 80f;
				}
				if (num > 15f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				Vector3 normalized = (vector - base.transform.position).normalized;
				rbAutreCollider = coll.gameObject.GetComponent<Rigidbody2D>();
				rbAutreCollider.AddForce(normalized * (chocpowerWeapon * num));
				int num2 = UnityEngine.Random.Range(0, 3);
				if (num2 == 0)
				{
					source.PlayOneShot(CoupArme);
				}
				if (num2 == 1)
				{
					source.PlayOneShot(CoupArme2);
				}
				if (num2 == 2)
				{
					source.PlayOneShot(CoupArme3);
				}
			}
		}
		if (coll.gameObject.CompareTag("pointfaible"))
		{
			ContactPoint2D[] contacts2 = coll.contacts;
			for (int j = 0; j < contacts2.Length; j++)
			{
				ContactPoint2D contactPoint2D2 = contacts2[j];
				int num3 = UnityEngine.Random.Range(0, 3);
				if (num3 == 0)
				{
					source.PlayOneShot(CoupStickman1);
				}
				if (num3 == 1)
				{
					source.PlayOneShot(CoupStickman2);
				}
				if (num3 == 2)
				{
					source.PlayOneShot(CoupStickman3);
				}
				Vector3 vector = contactPoint2D2.point;
				num = (num + 125f) / 3f;
				if (num > 5f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				Vector3 normalized = vector - base.transform.position;
				rbAutreCollider = coll.gameObject.GetComponent<Rigidbody2D>();
				rbAutreCollider.AddForce(normalized * (chocpowerSmallMember * num));
			}
		}
		if (coll.gameObject.CompareTag("membre"))
		{
			ContactPoint2D[] contacts3 = coll.contacts;
			for (int k = 0; k < contacts3.Length; k++)
			{
				ContactPoint2D contactPoint2D3 = contacts3[k];
				int num4 = UnityEngine.Random.Range(0, 3);
				if (num4 == 0)
				{
					source.PlayOneShot(CoupStickman1);
				}
				if (num4 == 1)
				{
					source.PlayOneShot(CoupStickman2);
				}
				if (num4 == 2)
				{
					source.PlayOneShot(CoupStickman3);
				}
				Vector3 vector = contactPoint2D3.point;
				num = (num + 30f) / 3f;
				if (num > 40f)
				{
					num = 40f;
				}
				Vector3 normalized = vector - base.transform.position;
				if (num > 5f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				rbAutreCollider = coll.gameObject.GetComponent<Rigidbody2D>();
				rbAutreCollider.AddForce(normalized * (chocpowerMember * num));
				if (!gManag.TwoPlayerSurvival)
				{
					CorpsDeAutreStick.AddForce(normalized * (chocpowerMember * num * 1.5f));
				}
			}
		}
		if (coll.gameObject.CompareTag("tete"))
		{
			ContactPoint2D[] contacts4 = coll.contacts;
			for (int l = 0; l < contacts4.Length; l++)
			{
				ContactPoint2D contactPoint2D4 = contacts4[l];
				int num5 = UnityEngine.Random.Range(0, 3);
				if (num5 == 0)
				{
					source.PlayOneShot(CoupStickman1);
				}
				if (num5 == 1)
				{
					source.PlayOneShot(CoupStickman2);
				}
				if (num5 == 2)
				{
					source.PlayOneShot(CoupStickman3);
				}
				Vector3 vector = contactPoint2D4.point;
				num = (num + 150f) / 3f;
				Vector3 normalized = vector - base.transform.position;
				if (num > 5f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				rbAutreCollider = coll.gameObject.GetComponent<Rigidbody2D>();
				rbAutreCollider.AddForce(normalized * (chocpowerTete * num));
			}
		}
		TimeReCollision = 10f;
		TimeCollision = 5;
	}
}
