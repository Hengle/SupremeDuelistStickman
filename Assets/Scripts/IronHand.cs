using UnityEngine;

public class IronHand : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Laser;

	public GameObject Flamme;

	public GameObject FlammeEffect;

	public GameObject Propulsion;

	public int StatePower;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public Vector2 direction;

	public Vector2 Power;

	public int timeFirsAtt;

	public int Cooldown;

	public Rigidbody2D rb;

	public bool PlayerOneOrTwo;

	public bool PowerhitReady;

	public bool directionChosen;

	public float maniment;

	private PlayerDirection DirPlayer;

	public PlayerDirection DirIronHand;

	public bool JoystickOnZero;

	public AudioSource source;

	public AudioClip PowerAbilityFly;

	public AudioClip PowerAbilityFire;

	public AudioClip PowerAbilityLaser;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public SpriteRenderer Indic;

	public bool flametrow;

	public bool Flight;

	public Rigidbody2D Corps;

	public Vector2 FlightDir;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
		StatePower = UnityEngine.Random.Range(0, 3);
		if (StatePower == 0)
		{
			Indic.color = new Color(1f, 0f, 0f);
		}
		if (StatePower == 1)
		{
			Indic.color = new Color(0f, 1f, 0f);
		}
		if (StatePower == 2)
		{
			Indic.color = new Color(1f, 0f, 1f);
		}
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		timeFirsAtt++;
		Cooldown--;
		rb.AddForce(direction * maniment * Time.fixedDeltaTime);
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
			Power = direction;
		}
		if (Cooldown <= 0)
		{
			if (direction.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
			if (StatePower == 0)
			{
				Indic.color = new Color(1f, 0f, 0f, 0.9f);
			}
			if (StatePower == 1)
			{
				Indic.color = new Color(0f, 1f, 0f, 0.9f);
			}
			if (StatePower == 2)
			{
				Indic.color = new Color(1f, 0f, 1f, 0.9f);
			}
		}
		if (directionChosen)
		{
			Cooldown = 140;
			if (StatePower == 0)
			{
				Flamme.transform.position = base.transform.position;
				Flamme.transform.rotation = base.transform.rotation;
				Flamme.transform.Rotate(0f, 0f, -90f, Space.Self);
				Flamme.SetActive(value: true);
				flametrow = true;
				source.PlayOneShot(PowerAbilityFire);
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
			if (StatePower == 1)
			{
				FlightDir = -DirIronHand.direction;
				Propulsion.transform.position = base.transform.position;
				Propulsion.transform.rotation = base.transform.rotation;
				Propulsion.transform.Rotate(0f, 0f, -90f, Space.Self);
				Propulsion.SetActive(value: true);
				Flight = true;
				Cooldown = 100;
				source.PlayOneShot(PowerAbilityFly);
			}
			if (StatePower == 2)
			{
				Laser.transform.position = base.transform.position;
				Laser.transform.rotation = base.transform.rotation;
				Laser.SetActive(value: true);
				Laser.GetComponent<Rigidbody2D>().AddForce(Power * 140f, ForceMode2D.Impulse);
				source.PlayOneShot(PowerAbilityLaser);
			}
			directionChosen = false;
			Indic.color = new Color(1f, 1f, 1f, 0.5f);
			StatePower = UnityEngine.Random.Range(0, 3);
		}
		if (Cooldown >= 30 && Cooldown % 15 == 0)
		{
			if (flametrow)
			{
				FlammeEffect.SetActive(value: false);
				FlammeEffect.transform.position = base.transform.position;
				FlammeEffect.transform.rotation = base.transform.rotation;
				FlammeEffect.transform.Rotate(0f, 0f, -90f, Space.Self);
				FlammeEffect.SetActive(value: true);
				FlammeEffect.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, 40f), ForceMode2D.Impulse);
			}
			if (Cooldown == 30)
			{
				flametrow = false;
				FlammeEffect.SetActive(value: false);
			}
		}
		if (flametrow && Cooldown == 125)
		{
			rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
		}
		if (Flight)
		{
			if (Cooldown > 20)
			{
				Corps.AddForce(-new Vector2(0f, Power.y * 1.5f) * 270f);
			}
			if (Cooldown == 20)
			{
				Propulsion.SetActive(value: false);
				Flight = false;
			}
		}
	}
}
