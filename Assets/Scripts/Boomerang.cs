using UnityEngine;

public class Boomerang : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject bras;

	public float SecondAngle;

	public bool PlayerOneOrTwo;

	public Vector2 direction;

	public Vector2 power;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Rigidbody2D rb;

	public float speed;

	public float retrunspeed;

	public bool directionChosen;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public float Distance;

	public HingeJoint2D BoomGrab;

	public CollisionWeapon BoomStat;

	public int timeToRetakeBoomerang;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public float Veloce;

	public GameObject AutreBoomerang;

	public int TimeRepear;

	public int InitialLayer;

	public PointEffector2D RepulseBoomerang;

	public GameObject explosion;

	public int timeRecoverBoomerang;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
		BoomStat = base.gameObject.GetComponent<CollisionWeapon>();
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		InitialLayer = base.gameObject.layer;
		BoomGrab.enabled = true;
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		timeFirsAtt++;
		Distance = (bras.transform.position - base.transform.position).magnitude;
		Rigidbody2D rigidbody2D = rb;
		Vector3 position = bras.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		float x2 = x - position2.x;
		Vector3 position3 = bras.transform.position;
		float y = position3.y;
		Vector3 position4 = base.transform.position;
		rigidbody2D.AddForce(new Vector2(x2, y - position4.y) * retrunspeed * Mathf.Abs(Distance / 5f), ForceMode2D.Force);
		if (!PlayerOneOrTwo)
		{
			if (!SkinChoose.OnePlayer)
			{
				direction = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
			else if (!SkinChoose.LeftUser)
			{
				direction = rightJoystick.GetInputDirection();
				JoystickOnZero = rightJoystick.IsTouching;
			}
			else
			{
				direction = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
		}
		else if (!DirPlayer.AI)
		{
			direction = rightJoystick.GetInputDirection();
			JoystickOnZero = rightJoystick.IsTouching;
		}
		else
		{
			direction = DirPlayer.direction / 4f;
		}
		direction = direction.normalized;
		if (direction.magnitude != 0f)
		{
			power = direction.normalized;
		}
		if (direction.magnitude > 0.2f && timeFirsAtt > 100 && BoomGrab.enabled)
		{
			PowerhitReady = true;
		}
		if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero && BoomGrab.enabled)
		{
			directionChosen = true;
			PowerhitReady = false;
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			if (BoomGrab.enabled)
			{
				directionChosen = false;
				BoomGrab.enabled = false;
				base.gameObject.GetComponent<Rigidbody2D>().AddForce(power * speed, ForceMode2D.Impulse);
				base.gameObject.GetComponent<Rigidbody2D>().AddTorque(speed * 5f);
				timeRecoverBoomerang = 0;
				BoomStat.chocpowerWeapon = 13f;
				BoomStat.DAMAGE = 0.15f;
			}
		}
		if (!BoomGrab.enabled)
		{
			timeToRetakeBoomerang++;
			if (timeToRetakeBoomerang > 20 && Distance < 5f)
			{
				BoomGrab.enabled = true;
				timeToRetakeBoomerang = 0;
				directionChosen = false;
				BoomStat.chocpowerWeapon = 11.5f;
				BoomStat.DAMAGE = 0.145f;
			}
		}
		Veloce = rb.velocity.magnitude;
		if (rb.velocity.magnitude > 50f)
		{
			Rigidbody2D rigidbody2D2 = rb;
			Vector2 velocity = rb.velocity;
			float x3 = velocity.x / (Veloce / 50f);
			Vector2 velocity2 = rb.velocity;
			rigidbody2D2.velocity = new Vector2(x3, velocity2.y / (Veloce / 50f));
		}
		if (TimeRepear > 0)
		{
			TimeRepear--;
			if (TimeRepear <= 2)
			{
				base.gameObject.layer = InitialLayer;
				AutreBoomerang.gameObject.layer = InitialLayer;
			}
		}
		if (timeRecoverBoomerang <= 0)
		{
			return;
		}
		timeRecoverBoomerang--;
		if (timeRecoverBoomerang == 2)
		{
			UnityEngine.Debug.Log("BOOMERANG RETOURNE");
			Rigidbody2D rigidbody2D3 = rb;
			Vector3 position5 = bras.transform.position;
			float x4 = position5.x;
			Vector3 position6 = base.transform.position;
			float x5 = x4 - position6.x;
			Vector3 position7 = bras.transform.position;
			float y2 = position7.y;
			Vector3 position8 = base.transform.position;
			rigidbody2D3.AddForce(new Vector2(x5, y2 - position8.y) * retrunspeed * 3f, ForceMode2D.Impulse);
			if (!BoomGrab.enabled)
			{
				timeRecoverBoomerang = 40;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (BoomGrab.enabled)
		{
			return;
		}
		if (coll.gameObject.layer == 8 || coll.gameObject.layer == 11)
		{
			base.gameObject.layer = 20;
			AutreBoomerang.gameObject.layer = 20;
			TimeRepear = 20;
			ContactPoint2D[] contacts = coll.contacts;
			for (int i = 0; i < contacts.Length; i++)
			{
				ContactPoint2D contactPoint2D = contacts[i];
				Vector3 position = contactPoint2D.point;
				explosion.gameObject.SetActive(value: false);
				explosion.gameObject.SetActive(value: true);
				explosion.transform.position = position;
				timeRecoverBoomerang = 80;
			}
		}
		if (!(coll.transform.tag == "arme"))
		{
			return;
		}
		base.gameObject.layer = 20;
		AutreBoomerang.gameObject.layer = 20;
		TimeRepear = 20;
		timeRecoverBoomerang = 40;
		if (coll.gameObject.tag == "arme")
		{
			ContactPoint2D[] contacts2 = coll.contacts;
			for (int j = 0; j < contacts2.Length; j++)
			{
				ContactPoint2D contactPoint2D2 = contacts2[j];
				Vector3 position = contactPoint2D2.point;
				Vector3 normalized = (position - base.transform.position).normalized;
				explosion.gameObject.SetActive(value: false);
				explosion.gameObject.SetActive(value: true);
				explosion.transform.position = position;
				Rigidbody2D rigidbody2D = rb;
				Vector3 position2 = bras.transform.position;
				float x = position2.x;
				Vector3 position3 = base.transform.position;
				float x2 = x - position3.x;
				Vector3 position4 = bras.transform.position;
				float y = position4.y;
				Vector3 position5 = base.transform.position;
				rigidbody2D.AddForce(new Vector2(x2, y - position5.y) * retrunspeed / 7f * Mathf.Abs(Distance / 5f), ForceMode2D.Impulse);
			}
		}
	}
}
