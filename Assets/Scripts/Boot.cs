using UnityEngine;

public class Boot : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public Rigidbody2D rb;

	public Vector2 YoyoMoove;

	public Vector2 YoyoPower;

	public bool PlayerOneOrTwo;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public Jambe vite;

	public Jambe vite2;

	public int yoyoPower;

	public int Cooldown;

	public GameObject YOYO;

	public ParticleSystem TrailYOYO;

	public GameObject ExplosionYoyo;

	public bool IsBlue;

	public bool GoOn;

	private PlayerDirection DirPlayer;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public AudioSource source;

	public AudioClip PowerAbility;

	public AudioClip PowerAbilityExplosion;

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
		vite.revSpeed = 2000f;
		vite2.revSpeed = 2000f;
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		KnockBack.forceMagnitude = 1045f;
		KnockBackTaille.radius = 1.61f;
	}

	private void FixedUpdate()
	{
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
				GoOn = false;
			}
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			directionChosen = false;
			yoyoPower = 30;
			Cooldown = 200;
			TrailYOYO = YOYO.GetComponent<ParticleSystem>();
			ParticleSystem.TrailModule trails = TrailYOYO.trails;
			rb.AddForce(new Vector3(0f, 75f, 0f), ForceMode2D.Impulse);
			trails.colorOverLifetime = new Color(1f, 1f, 1f);
			GoOn = true;
		}
		if (Cooldown > 150)
		{
		}
		if (Cooldown <= 0)
		{
			TrailYOYO = YOYO.GetComponent<ParticleSystem>();
			ParticleSystem.TrailModule trails2 = TrailYOYO.trails;
			if (IsBlue)
			{
				trails2.colorOverLifetime = new Color(0f, 1f, 1f);
				GoOn = false;
			}
			else
			{
				trails2.colorOverLifetime = new Color(1f, 1f, 0f);
				GoOn = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (GoOn)
		{
			GoOn = false;
			if (!ExplosionYoyo.gameObject.activeInHierarchy)
			{
				source.PlayOneShot(PowerAbilityExplosion);
				ExplosionYoyo.transform.position = base.transform.position;
				ExplosionYoyo.transform.rotation = base.transform.rotation;
				ExplosionYoyo.SetActive(value: true);
			}
		}
	}
}
