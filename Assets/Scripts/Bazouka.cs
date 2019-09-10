using UnityEngine;

public class Bazouka : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject[] arrow;

	public GameObject SuperBullet;

	public Vector2 BulletSpeed;

	public float SpeedBull;

	public float SpeedUltime;

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

	public AudioClip PowerAbilityBigShot;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public HingeJoint2D mainHing;

	public float limitBras;

	public GameObject SuperShootParticle;

	public int PowerRecul;

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
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		for (int i = 0; i < arrow.Length; i++)
		{
			arrow[i].transform.localScale = arrow[i].transform.localScale * 1.3f;
		}
		mainHing.useLimits = false;
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
				gunsprite.color = new Color(1f, 1f, 1f);
			}
			else
			{
				gunsprite.color = new Color(1f, 1f, 1f);
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
			gunsprite.color = new Color(0f, 0f, 0f, 0f);
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbilityBigShot);
			Cooldown = 220;
			directionChosen = false;
			SuperBullet.transform.position = base.transform.position;
			SuperBullet.transform.rotation = base.transform.rotation;
			SuperBullet.SetActive(value: false);
			SuperBullet.SetActive(value: true);
			BulletSpeed.y = 0f - SpeedBull;
			SuperBullet.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed / 5f, ForceMode2D.Impulse);
			SuperBullet.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
			rb.MovePosition(rb.position + Power * speed * Time.fixedDeltaTime);
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			SuperShootParticle.SetActive(value: true);
			if (Power.y < -0.7f)
			{
				PowerRecul = 35;
			}
			else
			{
				PowerRecul = 20;
			}
		}
		if (PowerRecul == 20)
		{
			if (Cooldown > 215)
			{
				rb.MovePosition(rb.position + Power * speed * Time.fixedDeltaTime);
				rb.AddRelativeForce(new Vector2(0f, PowerRecul), ForceMode2D.Impulse);
			}
		}
		else if (Cooldown > 210)
		{
			rb.MovePosition(rb.position + new Vector2(0f, (float)PowerRecul / 1.7f) * speed * Time.fixedDeltaTime);
			rb.AddForce(new Vector2(0f, (float)PowerRecul / 1.7f), ForceMode2D.Impulse);
		}
		if (Cooldown == 170)
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
		if (ReloadTime > 0)
		{
			ReloadTime--;
		}
		if (timeFirsAtt <= 100 || direction.magnitude == 0f || CoolDownShoot < 60)
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
			ReloadTime = 130;
			ShootNumber = 0;
		}
		arrow[num].transform.position = base.transform.position;
		arrow[num].transform.rotation = base.transform.rotation;
		arrow[num].SetActive(value: true);
		BulletSpeed.y = 0f - SpeedBull;
		arrow[num].GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed, ForceMode2D.Impulse);
		arrow[num].GetComponent<CollisionWeapon>().DAMAGE = 0.15f;
		rb.AddRelativeForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
	}
}
