using UnityEngine;

public class PortalGun : MonoBehaviour
{
	private GameManager SkinChoose;

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

	public int ReloadTime;

	public AudioSource source;

	public AudioClip PowerAbility1;

	public AudioClip PowerAbility2;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public int TimePortal;

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
		Rigidbody2D rigidbody2D = rb;
		Vector2 force = direction * maniment;
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		rigidbody2D.AddForceAtPosition(force, new Vector2(x, position2.y) + direction * 5f);
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
		}
		if (directionChosen)
		{
			directionChosen = false;
			BulletSpeed.x = 0f - Speed;
			if (TimePortal == 0)
			{
				source.PlayOneShot(PowerAbility1);
				Cooldown = 20;
				TimePortal = 1;
				SuperBullet2.transform.position = base.transform.position;
				SuperBullet2.transform.rotation = base.transform.rotation;
				SuperBullet2.SetActive(value: true);
				SuperBullet2.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed, ForceMode2D.Impulse);
			}
			else
			{
				source.PlayOneShot(PowerAbility2);
				Cooldown = 20;
				TimePortal = 0;
				SuperBullet1.transform.position = base.transform.position;
				SuperBullet1.transform.rotation = base.transform.rotation;
				SuperBullet1.SetActive(value: true);
				SuperBullet1.GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed, ForceMode2D.Impulse);
			}
		}
		if (ReloadTime > 0)
		{
			ReloadTime--;
		}
		if (timeFirsAtt > 100 && direction.magnitude != 0f && ReloadTime < 1 && CoolDownShoot >= 40)
		{
			CoolDownShoot = 0;
		}
	}
}
