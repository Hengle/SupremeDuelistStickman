using UnityEngine;

public class EpeDoublePlayer : MonoBehaviour
{
	public Vector2 direction;

	public Vector2 Powerhit;

	public bool PowerhitReady;

	public bool directionChosen;

	public float speed;

	public float speed2;

	public bool chargePower;

	public Rigidbody2D rb;

	public Rigidbody2D rbautre;

	public float chocpower;

	public int choctime;

	public float Propulsion;

	public float PropulsionPower;

	public bool active;

	public int RecupHit;

	public int timeFirsAtt;

	public int randomAttackAi;

	public LineRenderer SwordCharge;

	public GameObject collision;

	public GameObject Gaz;

	public Color Base;

	public bool zeroAtteintGaz;

	public bool playerPress;

	public bool PlayerOneOrTwo;

	public AudioSource SoundSource;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	private void Start()
	{
		if (active)
		{
			InvokeRepeating("recupstate", 0.7f, 0.4f);
			Base = SwordCharge.startColor;
		}
	}

	private void FixedUpdate()
	{
		if (!active)
		{
			return;
		}
		if (!PlayerOneOrTwo)
		{
			if (RecupHit < 30)
			{
				direction = leftJoystick.GetInputDirection();
			}
			else
			{
				direction = Powerhit / 2f;
			}
			if (direction.magnitude != 0f)
			{
				Powerhit = direction * 2f;
			}
		}
		else
		{
			if (RecupHit < 30)
			{
				direction = rightJoystick.GetInputDirection();
			}
			else
			{
				direction = Powerhit / 2f;
			}
			if (direction.magnitude != 0f)
			{
				Powerhit = direction * 2f;
			}
		}
		direction = direction.normalized;
		if (direction.magnitude > 0.2f && timeFirsAtt > 100)
		{
			PowerhitReady = true;
		}
		if (direction.magnitude == 0f && PowerhitReady)
		{
			directionChosen = true;
			PowerhitReady = false;
		}
		timeFirsAtt++;
		if (Propulsion <= -3.4f && zeroAtteintGaz)
		{
			zeroAtteintGaz = false;
			SwordCharge.startColor = Base;
		}
		if (RecupHit > 0)
		{
			RecupHit--;
			if (Propulsion <= 0f)
			{
				Propulsion += 0.07f;
				SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
				rb.MovePosition(rb.position + Powerhit * speed2 * Time.fixedDeltaTime);
			}
			else
			{
				Powerhit.x = 0f;
				Powerhit.y = 0f;
				Propulsion = 0f;
				Gaz.SetActive(value: false);
				zeroAtteintGaz = true;
			}
		}
		if (choctime < 1)
		{
			if (RecupHit <= 30)
			{
				rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
			}
		}
		else
		{
			choctime--;
		}
		if (!directionChosen)
		{
			return;
		}
		SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
		if ((double)Propulsion <= -3.1 && timeFirsAtt > 100)
		{
			RecupHit = 100;
			if (Powerhit.x > 0.1f)
			{
				direction.x = 0.12f;
			}
			if (Powerhit.x < -0.1f)
			{
				direction.x = -0.12f;
			}
			Gaz.SetActive(value: true);
			SwordCharge.startColor = new Color(0f, 0f, 0f);
		}
		if (RecupHit < 99)
		{
			direction.x = 0f;
			direction.y = 0f;
		}
		directionChosen = false;
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "arme")
		{
			choctime = Mathf.RoundToInt(coll.relativeVelocity.magnitude / 1.5f);
			if (choctime > 70)
			{
				choctime = 70;
			}
			ContactPoint2D[] contacts = coll.contacts;
			for (int i = 0; i < contacts.Length; i++)
			{
				ContactPoint2D contactPoint2D = contacts[i];
				Vector3 vector = contactPoint2D.point;
				float magnitude = coll.relativeVelocity.magnitude;
				if (magnitude > 15f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				Vector3 normalized = (vector - base.transform.position).normalized;
				rbautre = coll.gameObject.GetComponent<Rigidbody2D>();
				rbautre.AddForce(normalized * (chocpower + magnitude));
			}
		}
		if (coll.gameObject.tag == "pointfaible")
		{
			ContactPoint2D[] contacts2 = coll.contacts;
			for (int j = 0; j < contacts2.Length; j++)
			{
				ContactPoint2D contactPoint2D2 = contacts2[j];
				Vector3 vector = contactPoint2D2.point;
				float num = coll.relativeVelocity.magnitude / 7f;
				if (num > 5f && !collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				Vector3 normalized = vector - base.transform.position;
				rbautre = coll.gameObject.GetComponent<Rigidbody2D>();
				rbautre.AddForce(normalized * (chocpower * num));
			}
		}
		if (coll.gameObject.tag == "membre")
		{
			ContactPoint2D[] contacts3 = coll.contacts;
			for (int k = 0; k < contacts3.Length; k++)
			{
				ContactPoint2D contactPoint2D3 = contacts3[k];
				Vector3 vector = contactPoint2D3.point;
				float num = 5.5f + coll.relativeVelocity.magnitude / 15f;
				Vector3 normalized = vector - base.transform.position;
				if (num > 5f)
				{
					if (!collision.activeInHierarchy)
					{
						collision.gameObject.SetActive(value: false);
						collision.gameObject.SetActive(value: true);
						collision.transform.position = vector;
					}
					else
					{
						num /= 2f;
					}
				}
				rbautre = coll.gameObject.GetComponent<Rigidbody2D>();
				rbautre.AddForce(normalized * (chocpower * num));
			}
		}
		if (!(coll.gameObject.tag == "tete"))
		{
			return;
		}
		ContactPoint2D[] contacts4 = coll.contacts;
		for (int l = 0; l < contacts4.Length; l++)
		{
			ContactPoint2D contactPoint2D4 = contacts4[l];
			Vector3 vector = contactPoint2D4.point;
			float num = 6.5f + coll.relativeVelocity.magnitude / 10f;
			Vector3 normalized = vector - base.transform.position;
			if (num > 5f)
			{
				if (!collision.activeInHierarchy)
				{
					collision.gameObject.SetActive(value: false);
					collision.gameObject.SetActive(value: true);
					collision.transform.position = vector;
				}
				else
				{
					num /= 2f;
				}
			}
			rbautre = coll.gameObject.GetComponent<Rigidbody2D>();
			rbautre.AddForce(normalized * (chocpower * num));
		}
		if (choctime > 70)
		{
			choctime = 70;
		}
	}

	private void recupstate()
	{
		if (active)
		{
			if (Propulsion > -3.4f)
			{
				Propulsion -= 0.3f;
			}
			else
			{
				Propulsion = -3.4f;
			}
			SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
		}
	}
}
