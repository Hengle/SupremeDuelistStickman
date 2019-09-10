using UnityEngine;

public class lightsab : MonoBehaviour
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

	public GameObject fire;

	public SpriteRenderer symboleUlt;

	public bool isBlue;

	public int FireCooldown;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public AudioSource source;

	public AudioClip PowerAbility;

	public AudioClip PowerAbilityElectric;

	public AudioClip PowerAbilityForcePunch;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public GameObject doubleSabre;

	public bool MainSabre;

	public bool DoubleActive;

	public GameObject AutreSabre;

	public GameObject doubleSabreApp;

	public CollisionWeapon saberStat;

	public HingeJoint2D mainHing;

	public GameObject forceEclair;

	public GameObject forceEclairPower;

	public GameObject forcePunch;

	public GameObject forcePunchPower;

	public int power;

	public bool powerAcitavtion;

	private void Start()
	{
		mainHing = base.gameObject.GetComponent<HingeJoint2D>();
		saberStat = base.gameObject.GetComponent<CollisionWeapon>();
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
		if (MainSabre)
		{
			InvokeRepeating("PowerRandom", 1f, 1f);
		}
	}

	private void FixedUpdate()
	{
		if (DoubleActive)
		{
			rb.AddForceAtPosition(direction * 15f * Time.fixedDeltaTime, base.transform.position, ForceMode2D.Impulse);
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
		if (MainSabre && Cooldown == 1)
		{
			forceEclairPower.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		if (!directionChosen)
		{
			return;
		}
		source.PlayOneShot(PowerAbility);
		Cooldown = 10;
		directionChosen = false;
		if (!MainSabre)
		{
			return;
		}
		if (!DoubleActive)
		{
			DoubleActive = true;
			base.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -1.610428f);
			base.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.27f, 8.0871f);
			AutreSabre.SetActive(value: false);
			doubleSabreApp.SetActive(value: true);
			saberStat.DAMAGE = 0.068f;
			saberStat.chocpowerMember = 20f;
			saberStat.chocpowerSmallMember = 25f;
			saberStat.chocpowerWeapon = 7f;
			JointAngleLimits2D limits = mainHing.limits;
			limits.min = -180f;
			limits.max = 180f;
			mainHing.limits = limits;
		}
		else
		{
			DoubleActive = false;
			base.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, -0.0724f);
			base.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.27f, 5.011055f);
			AutreSabre.transform.position = base.transform.position;
			AutreSabre.SetActive(value: true);
			doubleSabreApp.SetActive(value: false);
			saberStat.DAMAGE = 0.03f;
			saberStat.chocpowerMember = 15f;
			saberStat.chocpowerSmallMember = 20f;
			saberStat.chocpowerWeapon = 5f;
			JointAngleLimits2D limits2 = mainHing.limits;
			limits2.min = -90f;
			limits2.max = 90f;
			mainHing.limits = limits2;
		}
		if (powerAcitavtion)
		{
			powerAcitavtion = false;
			if (power == 3)
			{
				float num = Mathf.Atan2(Power.y, Power.x) * 57.29578f;
				forceEclair.gameObject.SetActive(value: false);
				forceEclairPower.gameObject.transform.position = rb.transform.position;
				forceEclairPower.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, num - 90f);
				forceEclairPower.gameObject.SetActive(value: false);
				forceEclairPower.gameObject.GetComponent<BoxCollider2D>().enabled = true;
				forceEclairPower.gameObject.SetActive(value: true);
				source.PlayOneShot(PowerAbilityElectric, 0.7f);
			}
			if (power == 5)
			{
				forcePunch.gameObject.SetActive(value: false);
				float num2 = Mathf.Atan2(Power.y, Power.x) * 57.29578f;
				forcePunchPower.gameObject.transform.position = rb.transform.position;
				forcePunchPower.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, num2 - 90f);
				forcePunchPower.gameObject.GetComponent<BoxCollider2D>().enabled = true;
				forcePunchPower.gameObject.SetActive(value: true);
				source.PlayOneShot(PowerAbilityForcePunch, 0.8f);
			}
		}
	}

	private void PowerRandom()
	{
		if (!powerAcitavtion)
		{
			power = UnityEngine.Random.Range(0, 15);
			if (power == 3)
			{
				forceEclair.gameObject.SetActive(value: true);
				powerAcitavtion = true;
				source.PlayOneShot(PowerAbilityElectric, 0.2f);
			}
			if (power == 5)
			{
				forcePunch.gameObject.SetActive(value: true);
				powerAcitavtion = true;
				source.PlayOneShot(PowerAbilityForcePunch, 0.6f);
			}
		}
	}
}
