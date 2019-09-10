using UnityEngine;

public class Hache : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Montagne;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Vector2 direction;

	public Vector2 Power;

	public int timeFirsAtt;

	public int Cooldown;

	public Rigidbody2D rb;

	public bool PlayerOneOrTwo;

	public bool PowerhitReady;

	public bool directionChosen;

	public float maniment;

	public Rigidbody2D Bras;

	public Rigidbody2D AutreBras;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public SpriteRenderer symboleUlt;

	public SpriteRenderer symboleUlt1;

	public SpriteRenderer symboleUlt2;

	public bool isBlue;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float ReculLance;

	public bool StopContinue;

	public Rigidbody2D Corps;

	public bool Impact;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
		if (isBlue)
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
			symboleUlt1.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
			symboleUlt2.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
		}
		else
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
			symboleUlt1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
			symboleUlt2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
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
		Bras.AddForce(direction * maniment * Time.fixedDeltaTime);
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
			if (isBlue)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
				symboleUlt1.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
				symboleUlt2.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
			}
			else
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
				symboleUlt1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
				symboleUlt2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
			}
		}
		if (directionChosen)
		{
			Cooldown = 270;
			directionChosen = false;
			if (base.gameObject.layer == 9)
			{
				base.gameObject.layer = 18;
			}
			else
			{
				base.gameObject.layer = 19;
			}
			Corps.constraints |= RigidbodyConstraints2D.FreezeRotation;
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			symboleUlt1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			symboleUlt2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
			Impact = false;
		}
		if (Cooldown > 250)
		{
			Corps.AddForce(new Vector2(direction.x * 150f, 1000f) * Time.fixedDeltaTime, ForceMode2D.Impulse);
		}
		if (Cooldown > 210 && Cooldown < 250)
		{
			Corps.AddForce(new Vector2(direction.x * 150f, -300f) * Time.fixedDeltaTime, ForceMode2D.Impulse);
			rb.AddForce(new Vector2(0f, -500f) * Time.fixedDeltaTime, ForceMode2D.Impulse);
		}
		if (Cooldown == 150)
		{
			if (base.gameObject.layer == 18)
			{
				base.gameObject.layer = 9;
			}
			else
			{
				base.gameObject.layer = 12;
			}
			Corps.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if ((coll.transform.tag == "sol" || coll.transform.tag == "rebond") && !Montagne.gameObject.activeInHierarchy && Cooldown > 0 && Cooldown < 245 && !Impact)
		{
			source.PlayOneShot(PowerAbility);
			Montagne.transform.position = base.transform.position;
			Montagne.transform.rotation = base.transform.rotation;
			Impact = true;
			Montagne.gameObject.SetActive(value: true);
		}
	}
}
