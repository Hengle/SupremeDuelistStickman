using UnityEngine;

public class bomb : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject[] SuperBullet;

	public Vector2 BulletSpeed;

	public float Speed;

	public int CoolDownShoot;

	public bool PlayerOneOrTwo;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Vector2 direction;

	public Vector2 Power;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public int Cooldown;

	public Rigidbody2D rb;

	public float speed;

	public SpriteRenderer gunsprite;

	public float maniment;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public int ShootNumber;

	public int ReloadTime;

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
		gunsprite = GetComponent<SpriteRenderer>();
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		CoolDownShoot++;
		Cooldown--;
		timeFirsAtt++;
		if (Cooldown > 220)
		{
			rb.MovePosition(rb.position + Power * speed * Time.fixedDeltaTime);
		}
		else
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
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
		rb.AddForce(direction * maniment * Time.fixedDeltaTime);
		if (direction.magnitude != 0f)
		{
			Power = direction;
		}
		if (Cooldown <= 0)
		{
			gunsprite.color = new Color(0f, 0f, 0f);
			if (direction.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
		}
		else if (!PlayerOneOrTwo)
		{
			gunsprite.color = new Color(1f, 1f, 1f);
		}
		else
		{
			gunsprite.color = new Color(1f, 1f, 1f);
		}
		if (!directionChosen)
		{
			return;
		}
		Cooldown = 90;
		directionChosen = false;
		source.PlayOneShot(PowerAbility);
		int num = 0;
		while (true)
		{
			if (num < SuperBullet.Length)
			{
				if (!SuperBullet[num].activeInHierarchy)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		SuperBullet[num].transform.position = base.transform.position;
		SuperBullet[num].transform.rotation = base.transform.rotation;
		SuperBullet[num].SetActive(value: true);
		BulletSpeed.x = Speed;
		SuperBullet[num].GetComponent<Rigidbody2D>().AddForce(Power * Speed, ForceMode2D.Impulse);
		SuperBullet[num].GetComponent<Rigidbody2D>().AddTorque(Speed * 2f);
		rb.MovePosition(rb.position + Power * speed / 2f * Time.fixedDeltaTime);
	}
}
