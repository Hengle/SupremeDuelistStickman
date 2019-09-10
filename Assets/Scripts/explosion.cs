using UnityEngine;

public class explosion : MonoBehaviour
{
	public CircleCollider2D collision;

	public Rigidbody2D rbjoueur1;

	public Rigidbody2D rbjoueur2;

	public bool STOP;

	public int timeToReset = 1;

	public int timeToActivate;

	public float taille;

	private void Start()
	{
		collision = GetComponent<CircleCollider2D>();
		rbjoueur1 = GameObject.Find("Tete").GetComponent<Rigidbody2D>();
		rbjoueur2 = GameObject.Find("Tete (3)").GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		timeToActivate--;
		if (timeToActivate == 0)
		{
		}
		if (timeToReset > 1)
		{
			timeToReset--;
			if (timeToReset != 2)
			{
			}
		}
		else
		{
			base.transform.localScale = new Vector3(taille, taille, taille);
			taille += 1f;
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (!STOP)
		{
			if (coll.gameObject.layer == 11)
			{
				collision.enabled = false;
				STOP = true;
				timeToReset = 200;
			}
			if (coll.gameObject.layer == 8)
			{
				collision.enabled = false;
				STOP = true;
				timeToReset = 200;
			}
			if (coll.gameObject.layer == 20)
			{
				collision.enabled = false;
				STOP = true;
				timeToReset = 200;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (!STOP)
		{
			if (coll.gameObject.layer == 11)
			{
				collision.enabled = false;
				STOP = true;
				timeToReset = 200;
			}
			if (coll.gameObject.layer == 8)
			{
				collision.enabled = false;
				STOP = true;
				timeToReset = 200;
			}
		}
	}
}
