using UnityEngine;

public class Gun : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject[] arrow;

	public GameObject SuperBullet;

	public GameObject SuperBullet1;

	public GameObject SuperBullet2;

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

	public GameObject Fumer;

	public int ReloadTime;

	public AudioSource source;

	public AudioClip PowerAbility;

	public AudioClip PowerAbilityBigShot;

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
			if (!PlayerOneOrTwo)
			{
				gunsprite.color = new Color(0f, 0.7f, 1f);
			}
			else
			{
				gunsprite.color = new Color(1f, 0f, 0f);
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
		}
		else
		{
			gunsprite.color = new Color(0f, 0f, 0f);
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbilityBigShot);
			Cooldown = 190;
			directionChosen = false;
			SuperBullet.transform.position = base.transform.position;
			SuperBullet.transform.rotation = base.transform.rotation;
			SuperBullet.SetActive(value: true);
			BulletSpeed.y = Speed;
			SuperBullet.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed * 1.5f, ForceMode2D.Impulse);
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			rb.MovePosition(rb.position + Power * speed * Time.fixedDeltaTime);
			SuperBullet1.transform.position = base.transform.position;
			SuperBullet1.transform.rotation = base.transform.rotation;
			SuperBullet1.transform.Rotate(0f, 0f, 10f, Space.Self);
			SuperBullet1.SetActive(value: true);
			SuperBullet1.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed * 1.5f, ForceMode2D.Impulse);
			SuperBullet2.transform.position = base.transform.position;
			SuperBullet2.transform.rotation = base.transform.rotation;
			SuperBullet2.transform.Rotate(0f, 0f, -10f, Space.Self);
			SuperBullet2.SetActive(value: true);
			SuperBullet2.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed * 1.5f, ForceMode2D.Impulse);
		}
		if (ReloadTime > 0)
		{
			ReloadTime--;
		}
		if (timeFirsAtt <= 100 || direction.magnitude == 0f || ReloadTime >= 1 || CoolDownShoot < 40)
		{
			return;
		}
		CoolDownShoot = 0;
		int num = 0;
		while (true)
		{
			if (num < arrow.Length)
			{
				if (!arrow[num].activeInHierarchy)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		source.PlayOneShot(PowerAbility);
		ShootNumber++;
		if (ShootNumber >= 4)
		{
			ReloadTime = 110;
			ShootNumber = 0;
			Fumer.SetActive(value: true);
		}
		arrow[num].transform.position = base.transform.position;
		arrow[num].transform.rotation = base.transform.rotation;
		arrow[num].SetActive(value: true);
		BulletSpeed.y = Speed;
		arrow[num].GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed, ForceMode2D.Impulse);
		rb.MovePosition(rb.position + Power * speed / 2f * Time.fixedDeltaTime);
	}
}
