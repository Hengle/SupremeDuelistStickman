using UnityEngine;

public class Shuriken : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Montagne;

	public int NumberShuriken;

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

	public GameObject FireCooldownIndic;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public AudioSource source;

	public AudioClip PowerAbility;

	public AudioClip PowerAbilityUltime;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public GameObject PlayerParent;

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
				if (NumberShuriken < 3)
				{
					symboleUlt.enabled = true;
				}
				else
				{
					FireCooldownIndic.SetActive(value: true);
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
			if (!isBlue)
			{
			}
		}
		if (FireCooldown > 0)
		{
			FireCooldown--;
			if (FireCooldown == 2)
			{
				maniment /= 20f;
				fire.SetActive(value: false);
				SpriteRenderer[] componentsInChildren = PlayerParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
				foreach (SpriteRenderer spriteRenderer in componentsInChildren)
				{
					SpriteRenderer spriteRenderer2 = spriteRenderer;
					Color color = spriteRenderer.color;
					float r = color.r;
					Color color2 = spriteRenderer.color;
					float g = color2.g;
					Color color3 = spriteRenderer.color;
					spriteRenderer2.color = new Color(r, g, color3.b, 1f);
					if (!PlayerOneOrTwo)
					{
						spriteRenderer.gameObject.layer = 8;
					}
					else if (!gManag.TwoPlayerSurvival)
					{
						spriteRenderer.gameObject.layer = 11;
					}
					else
					{
						spriteRenderer.gameObject.layer = 8;
					}
					base.gameObject.GetComponent<Collider2D>().enabled = true;
				}
			}
		}
		if (!directionChosen)
		{
			return;
		}
		Cooldown = 50;
		directionChosen = false;
		if (NumberShuriken < 3)
		{
			source.PlayOneShot(PowerAbility);
			symboleUlt.enabled = false;
			Montagne.transform.position = base.transform.position;
			Montagne.transform.rotation = base.transform.rotation;
			Montagne.transform.Rotate(new Vector3(0f, 0f, 180f));
			Montagne.gameObject.SetActive(value: true);
			Montagne.GetComponent<Rigidbody2D>().AddForce(Power * 21f, ForceMode2D.Impulse);
			Montagne.GetComponent<Rigidbody2D>().AddTorque(UnityEngine.Random.Range(-200, 200));
			NumberShuriken++;
			return;
		}
		source.PlayOneShot(PowerAbilityUltime);
		FireCooldownIndic.SetActive(value: false);
		maniment *= 20f;
		FireCooldown = 120;
		Cooldown = 125;
		fire.SetActive(value: true);
		base.gameObject.GetComponent<Collider2D>().enabled = false;
		SpriteRenderer[] componentsInChildren2 = PlayerParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer spriteRenderer3 in componentsInChildren2)
		{
			SpriteRenderer spriteRenderer4 = spriteRenderer3;
			Color color4 = spriteRenderer3.color;
			float r2 = color4.r;
			Color color5 = spriteRenderer3.color;
			float g2 = color5.g;
			Color color6 = spriteRenderer3.color;
			spriteRenderer4.color = new Color(r2, g2, color6.b, 0f);
			spriteRenderer3.gameObject.layer = 20;
		}
		rb.AddForce(Power * 50f, ForceMode2D.Impulse);
		NumberShuriken = 0;
	}
}
