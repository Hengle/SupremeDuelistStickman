using UnityEngine;

public class IceCream : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Montagne;

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

	public SpriteRenderer symboleUlt;

	public bool isBlue;

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
		if (isBlue)
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
		}
		else
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
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
			if (!PlayerOneOrTwo)
			{
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
			if (isBlue)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
			}
			else
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
			}
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			Cooldown = 150;
			directionChosen = false;
			Montagne.transform.position = base.transform.position;
			Montagne.transform.rotation = base.transform.rotation;
			Montagne.transform.Rotate(new Vector3(0f, 0f, 180f));
			Montagne.gameObject.SetActive(value: true);
			Montagne.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -30f), ForceMode2D.Impulse);
			StatePower = UnityEngine.Random.Range(0, 3);
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		}
	}
}
