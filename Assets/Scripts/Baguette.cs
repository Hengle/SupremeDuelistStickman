using UnityEngine;

public class Baguette : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject[] arrow;

	public GameObject[] caisse;

	public GameObject[] Teleportation;

	public int StatePower;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public GameObject Baguet;

	public ParticleSystem TrailBaguette;

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

	public AudioClip PowerAbilityTeleport;

	public AudioClip PowerAbilityAttack;

	public AudioClip PowerAbilityShield;

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
		TrailBaguette = Baguet.GetComponent<ParticleSystem>();
		ParticleSystem.MainModule main = TrailBaguette.main;
		StatePower = UnityEngine.Random.Range(0, 3);
		if (StatePower == 0)
		{
			main.startColor = new Color(1f, 0f, 0f);
		}
		if (StatePower == 1)
		{
			main.startColor = new Color(0f, 1f, 0f);
		}
		if (StatePower == 2)
		{
			main.startColor = new Color(1f, 0f, 1f);
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
			TrailBaguette = Baguet.GetComponent<ParticleSystem>();
			ParticleSystem.MainModule main = TrailBaguette.main;
			if (StatePower == 0)
			{
				main.startColor = new Color(1f, 0f, 0f);
			}
			if (StatePower == 1)
			{
				main.startColor = new Color(0f, 1f, 0f);
			}
			if (StatePower == 2)
			{
				main.startColor = new Color(1f, 0f, 1f);
			}
		}
		if (!directionChosen)
		{
			return;
		}
		Cooldown = 100;
		directionChosen = false;
		if (StatePower == 0)
		{
			for (int i = 0; i < arrow.Length; i++)
			{
				if (!arrow[i].activeInHierarchy)
				{
					arrow[i].transform.position = base.transform.position;
					arrow[i].transform.rotation = base.transform.rotation;
					arrow[i].SetActive(value: true);
					arrow[i].GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f - speed, 0f - speed), ForceMode2D.Impulse);
					source.PlayOneShot(PowerAbilityAttack);
					break;
				}
			}
		}
		if (StatePower == 1)
		{
			for (int j = 0; j < caisse.Length; j++)
			{
				if (!caisse[j].activeInHierarchy)
				{
					caisse[j].transform.position = base.transform.position;
					caisse[j].transform.rotation = base.transform.rotation;
					caisse[j].SetActive(value: true);
					caisse[j].GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2((0f - speed) * 2f, (0f - speed) * 2f), ForceMode2D.Impulse);
					caisse[j].transform.Rotate(0f, 0f, 45f, Space.Self);
					caisse[j].transform.Translate(-1f, 0f, 0f, Space.Self);
					source.PlayOneShot(PowerAbilityShield);
					break;
				}
			}
		}
		if (StatePower == 2)
		{
			for (int k = 0; k < Teleportation.Length; k++)
			{
				if (!Teleportation[k].activeInHierarchy)
				{
					Teleportation[k].transform.position = base.transform.position;
					Teleportation[k].transform.rotation = base.transform.rotation;
					Teleportation[k].SetActive(value: true);
					source.PlayOneShot(PowerAbilityTeleport);
					Teleportation[k].GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2((0f - speed) / 1.5f, (0f - speed) / 1.5f), ForceMode2D.Impulse);
					break;
				}
			}
		}
		StatePower = UnityEngine.Random.Range(0, 3);
		TrailBaguette = Baguet.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main1 = TrailBaguette.main;
        main1.startColor = new Color(1f, 1f, 1f);
	}
}
