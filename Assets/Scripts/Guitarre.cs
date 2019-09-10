using UnityEngine;

public class Guitarre : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Laser;

	public GameObject UpSouffle;

	public GameObject RandomAttackNote;

	public int StatePower;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public GameObject Baguet;

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

	public AudioSource source;

	public AudioClip PowerAbilityMONTE;

	public AudioClip PowerAbilitySTAGNE;

	public AudioClip PowerAbilityATTACK;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public int CountLaserBlock;

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
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
		}
		if (StatePower == 1)
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
		}
		if (StatePower == 2)
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f);
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
			if (StatePower == 0)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
			}
			if (StatePower == 1)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
			}
			if (StatePower == 2)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f);
			}
		}
		if (Cooldown > 60)
		{
			UpSouffle.transform.position = base.transform.position;
			Laser.transform.position = base.transform.position;
			Laser.transform.rotation = base.transform.rotation;
			Laser.transform.Rotate(new Vector3(0f, 0f, -90f));
		}
		if (directionChosen)
		{
			Cooldown = 150;
			directionChosen = false;
			if (StatePower == 1)
			{
				source.PlayOneShot(PowerAbilityMONTE);
				UpSouffle.transform.position = base.transform.position;
				UpSouffle.gameObject.SetActive(value: true);
			}
			if (StatePower == 2)
			{
				source.PlayOneShot(PowerAbilitySTAGNE);
				RandomAttackNote.transform.position = base.transform.position;
				RandomAttackNote.gameObject.SetActive(value: true);
			}
			if (StatePower == 0)
			{
				source.PlayOneShot(PowerAbilityATTACK);
				Laser.transform.position = base.transform.position;
				Laser.transform.rotation = base.transform.rotation;
				Laser.transform.Rotate(new Vector3(0f, 0f, -90f));
				Laser.gameObject.SetActive(value: true);
				rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
				CountLaserBlock = 80;
			}
			StatePower = UnityEngine.Random.Range(0, 3);
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
		}
		if (CountLaserBlock > 0)
		{
			CountLaserBlock--;
			if (CountLaserBlock == 1)
			{
				rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
			}
		}
	}
}
