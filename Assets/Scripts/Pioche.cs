using UnityEngine;

public class Pioche : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Tnt;

	public GameObject Rock;

	public GameObject Piston;

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

	public bool JoystickOnZero;

	public GameObject fire;

	public SpriteRenderer symboleUlt;

	public bool isBlue;

	public int FireCooldown;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public GameObject Logo;

	public GameObject PistonLogo;

	public GameObject RockLogo;

	public GameObject TntLogo;

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
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
		StatePower = UnityEngine.Random.Range(0, 3);
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		StatePower = UnityEngine.Random.Range(0, 3);
		Logo.SetActive(value: true);
		if (StatePower == 0)
		{
			TntLogo.SetActive(value: true);
		}
		if (StatePower == 1)
		{
			RockLogo.SetActive(value: true);
		}
		if (StatePower == 2)
		{
			PistonLogo.SetActive(value: true);
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
			if (Cooldown == 0)
			{
				StatePower = UnityEngine.Random.Range(0, 3);
				Logo.SetActive(value: true);
				if (StatePower == 0)
				{
					TntLogo.SetActive(value: true);
				}
				if (StatePower == 1)
				{
					RockLogo.SetActive(value: true);
				}
				if (StatePower == 2)
				{
					PistonLogo.SetActive(value: true);
				}
			}
			if (direction.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
			symboleUlt.GetComponent<SpriteRenderer>().enabled = false;
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			Cooldown = 150;
			directionChosen = false;
			Logo.SetActive(value: false);
			if (StatePower == 0)
			{
				Tnt.gameObject.SetActive(value: false);
				Tnt.transform.position = base.transform.position;
				Tnt.gameObject.SetActive(value: true);
				Tnt.GetComponent<Rigidbody2D>().AddForce(Power * 4f, ForceMode2D.Impulse);
				TntLogo.SetActive(value: false);
			}
			if (StatePower == 1)
			{
				Rock.gameObject.SetActive(value: false);
				Rock.transform.position = base.transform.position;
				Rock.transform.rotation = base.transform.rotation;
				Rock.transform.Translate(-2f, 0f, 0f, Space.Self);
				Rock.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
				Rock.gameObject.SetActive(value: true);
				RockLogo.SetActive(value: false);
			}
			if (StatePower == 2)
			{
				Piston.gameObject.SetActive(value: false);
				Piston.transform.position = base.transform.position;
				Piston.transform.rotation = base.transform.rotation;
				Piston.transform.Translate(-2f, 0f, 0f, Space.Self);
				Piston.transform.Rotate(0f, 0f, 180f, Space.Self);
				Piston.gameObject.SetActive(value: true);
				PistonLogo.SetActive(value: false);
			}
			symboleUlt.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
