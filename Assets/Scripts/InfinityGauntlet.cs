using UnityEngine;

public class InfinityGauntlet : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Ralentissement;

	public GameObject TrouNoir;

	public GameObject Protection;

	public GameObject Rayon;

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

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public MeteoreApparition MeteorLOL;

	public SpriteRenderer ImageCrystale;

	public SpriteRenderer ImageReflet;

	public GameObject ParentStick;

	public Vector3 PositionPlayyer;

	public Vector3 DistanceToTeleport;

	public GameObject pied;

	public bool Bigger;

	public bool ChangePlayer;

	public PlayerDirection DirCode;

	public float DirxLol;

	public float DiryLol;

	private void Start()
	{
		Bigger = false;
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
		StatePower = UnityEngine.Random.Range(0, 6);
		if (StatePower == 0)
		{
			ImageCrystale.color = new Color(1f, 0f, 0f);
		}
		if (StatePower == 1)
		{
			ImageCrystale.color = new Color(0f, 1f, 0f);
		}
		if (StatePower == 2)
		{
			ImageCrystale.color = new Color(1f, 0f, 1f);
		}
		if (StatePower == 3)
		{
			ImageCrystale.color = new Color(0f, 1f, 0f);
		}
		if (StatePower == 4)
		{
			ImageCrystale.color = new Color(1f, 1f, 0f);
		}
		if (StatePower == 5)
		{
			ImageCrystale.color = new Color(1f, 0.5f, 0f);
		}
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		if (Cooldown >= 0)
		{
			ImageReflet.color = new Color(0f, 0f, 0f, 0f);
		}
		else
		{
			SpriteRenderer imageReflet = ImageReflet;
			Color color = ImageCrystale.color;
			float r = color.r;
			Color color2 = ImageCrystale.color;
			float g = color2.g;
			Color color3 = ImageCrystale.color;
			imageReflet.color = new Color(r, g, color3.b, 0.3f);
		}
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
				ImageCrystale.color = new Color(1f, 0f, 0f);
			}
			if (StatePower == 1)
			{
				ImageCrystale.color = new Color(0f, 1f, 1f);
			}
			if (StatePower == 2)
			{
				ImageCrystale.color = new Color(1f, 0f, 1f);
			}
			if (StatePower == 3)
			{
				ImageCrystale.color = new Color(0f, 1f, 0f);
			}
			if (StatePower == 4)
			{
				ImageCrystale.color = new Color(1f, 1f, 0f);
			}
			if (StatePower == 5)
			{
				ImageCrystale.color = new Color(1f, 0.5f, 0f);
			}
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility, 0.4f);
			Cooldown = 200;
			directionChosen = false;
			if (StatePower == 0)
			{
				Protection.transform.position = base.transform.position;
				Protection.transform.rotation = base.transform.rotation;
				Protection.SetActive(value: true);
			}
			if (StatePower == 1)
			{
				TrouNoir.transform.position = base.transform.position;
				TrouNoir.transform.rotation = base.transform.rotation;
				TrouNoir.SetActive(value: true);
				TrouNoir.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
			}
			if (StatePower == 2)
			{
				MeteorLOL.Enable = true;
			}
			if (StatePower == 3)
			{
				Ralentissement.transform.position = base.transform.position;
				Ralentissement.transform.rotation = base.transform.rotation;
				Ralentissement.SetActive(value: true);
				UnityEngine.Debug.Log("ARRET TEMPS");
			}
			if (StatePower == 4)
			{
				PlayerDirection[] array = UnityEngine.Object.FindObjectsOfType<PlayerDirection>();
				DirxLol = UnityEngine.Random.Range(-5f, 5f);
				DiryLol = UnityEngine.Random.Range(-5f, 5f);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != DirCode)
					{
						array[i].Devx = DirxLol;
						array[i].Devy = DiryLol;
					}
				}
				ChangePlayer = true;
			}
			if (StatePower == 5)
			{
				Rayon.transform.position = base.transform.position;
				Rayon.transform.rotation = base.transform.rotation;
				Rayon.SetActive(value: true);
				Rayon.GetComponent<Rigidbody2D>().AddForce(Power * 300f, ForceMode2D.Impulse);
			}
			StatePower = UnityEngine.Random.Range(0, 6);
			ImageCrystale.color = new Color(1f, 1f, 1f);
		}
		if (Cooldown == 30)
		{
			MeteorLOL.Enable = false;
		}
		if (!ChangePlayer)
		{
			return;
		}
		if (Cooldown > 100)
		{
			PlayerDirection[] array2 = UnityEngine.Object.FindObjectsOfType<PlayerDirection>();
			for (int j = 0; j < array2.Length; j++)
			{
				if (array2[j] != DirCode)
				{
					array2[j].Devx = DirxLol;
					array2[j].Devy = DiryLol;
				}
			}
		}
		if (Cooldown != 100)
		{
			return;
		}
		PlayerDirection[] array3 = UnityEngine.Object.FindObjectsOfType<PlayerDirection>();
		for (int k = 0; k < array3.Length; k++)
		{
			if (array3[k] != DirCode)
			{
				array3[k].Devx = 0f;
				array3[k].Devy = 0f;
			}
		}
		ChangePlayer = false;
	}
}
