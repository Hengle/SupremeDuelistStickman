using UnityEngine;

public class Yoyo : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public GameObject Bras;

	public float speed;

	public Rigidbody2D rb;

	public Vector2 YoyoMoove;

	public Vector2 YoyoPower;

	public bool PlayerOneOrTwo;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public int yoyoPower;

	public int Cooldown;

	public GameObject YOYO;

	public ParticleSystem TrailYOYO;

	public GameObject ExplosionYoyo;

	public GameObject ExplosionYoyoCollider;

	public bool IsBlue;

	public LineRenderer filDuYoyo;

	private PlayerDirection DirPlayer;

	public float speedYoyoPower;

	public float distance;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float realVelocity;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public int stopCounter;

	private void Start()
	{
		KnockBack.forceMagnitude = 1030f;
		KnockBackTaille.radius = 1.26f;
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		distance = (Bras.transform.position - base.transform.position).magnitude;
		filDuYoyo.SetPosition(0, base.transform.position);
		filDuYoyo.SetPosition(1, Bras.transform.position);
		timeFirsAtt++;
		yoyoPower--;
		Cooldown--;
		if (!PlayerOneOrTwo)
		{
			if (!SkinChoose.OnePlayer)
			{
				YoyoMoove = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
			else if (!SkinChoose.LeftUser)
			{
				YoyoMoove = rightJoystick.GetInputDirection();
				JoystickOnZero = rightJoystick.IsTouching;
			}
			else
			{
				YoyoMoove = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
		}
		else if (!DirPlayer.AI)
		{
			YoyoMoove = rightJoystick.GetInputDirection();
			JoystickOnZero = rightJoystick.IsTouching;
		}
		else
		{
			YoyoMoove = DirPlayer.direction / 4f;
		}
		YoyoMoove = YoyoMoove.normalized;
		if (YoyoMoove.magnitude != 0f && Cooldown < 150)
		{
			YoyoPower = YoyoMoove;
		}
		if (Cooldown <= 0)
		{
			if (YoyoMoove.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (YoyoMoove.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			directionChosen = false;
			ExplosionYoyo.SetActive(value: true);
			ExplosionYoyoCollider.gameObject.transform.position = base.gameObject.transform.position;
			ExplosionYoyoCollider.SetActive(value: true);
			yoyoPower = 30;
			Cooldown = 200;
			TrailYOYO = YOYO.GetComponent<ParticleSystem>();
            ParticleSystem.TrailModule _module = TrailYOYO.trails;
            _module.colorOverLifetime = new Color(1f, 1f, 1f);
			ImageIsReady.color = new Color(0.7f, 0.7f, 0.7f);
		}
		if (yoyoPower <= 0)
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
		if (Cooldown > 150)
		{
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		else
		{
			rb.AddForce(YoyoMoove * speed * 1.2f * Time.deltaTime);
		}
		if (Cooldown <= 0)
		{
			TrailYOYO = YOYO.GetComponent<ParticleSystem>();
			ParticleSystem.TrailModule trails = TrailYOYO.trails;
			if (IsBlue)
			{
				trails.colorOverLifetime = new Color(0f, 1f, 1f);
				ImageIsReady.color = new Color(0f, 0.3f, 1f);
			}
			else
			{
				trails.colorOverLifetime = new Color(1f, 1f, 0f);
				ImageIsReady.color = new Color(1f, 0.3f, 0f);
			}
		}
		if (stopCounter > 0)
		{
			stopCounter--;
			Rigidbody2D rigidbody2D = rb;
			Vector2 velocity = rb.velocity;
			float x = velocity.x / 1.4f;
			Vector2 velocity2 = rb.velocity;
			rigidbody2D.velocity = new Vector2(x, velocity2.y / 1.4f);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("arme"))
		{
			Rigidbody2D rigidbody2D = rb;
			Vector2 velocity = rb.velocity;
			float x = velocity.x / 1.3f;
			Vector2 velocity2 = rb.velocity;
			rigidbody2D.velocity = new Vector2(x, velocity2.y / 1.3f);
			stopCounter = 3;
		}
	}
}
