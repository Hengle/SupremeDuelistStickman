using UnityEngine;

public class Arc : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject[] arrow;

	public GameObject[] SuperBullet;

	public Vector2 BulletSpeed;

	public float Speed;

	public int CoolDownShoot;

	public bool PlayerOneOrTwo;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Vector2 direction;

	public Vector2 SecondBrasDirection;

	public Vector2 Power;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public int Cooldown;

	public int CooldownUlt;

	public Rigidbody2D rb;

	public float speedDep;

	public SpriteRenderer gunsprite;

	public float maniment;

	public GameObject AvantBras;

	public GameObject AvantBras2;

	public GameObject Bras;

	public GameObject BrasCorrection;

	public GameObject AttachFil1;

	public GameObject AttachFil2;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public LineRenderer ArcFil;

	public GameObject PlayerParent;

	public GameObject Corps;

	public float dash;

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
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		BrasCorrection.gameObject.GetComponent<HingeJoint2D>().useLimits = true;
		JointAngleLimits2D limits = BrasCorrection.gameObject.GetComponent<HingeJoint2D>().limits;
		limits.min = -1f;
		limits.max = 1f;
		BrasCorrection.gameObject.GetComponent<HingeJoint2D>().limits = limits;
	}

	private void LateUpdate()
	{
		if (Cooldown < 50)
		{
			LineRenderer arcFil = ArcFil;
			Vector3 position = AttachFil1.transform.position;
			float x = position.x;
			Vector3 position2 = AttachFil1.transform.position;
			arcFil.SetPosition(0, new Vector3(x, position2.y, -2f));
			LineRenderer arcFil2 = ArcFil;
			Vector3 position3 = AttachFil1.transform.position;
			float x2 = position3.x;
			Vector3 position4 = AttachFil1.transform.position;
			arcFil2.SetPosition(1, new Vector3(x2, position4.y, -2f));
			LineRenderer arcFil3 = ArcFil;
			Vector3 position5 = AttachFil2.transform.position;
			float x3 = position5.x;
			Vector3 position6 = AttachFil2.transform.position;
			arcFil3.SetPosition(2, new Vector3(x3, position6.y, -2f));
		}
		if (Cooldown <= 0)
		{
			LineRenderer arcFil4 = ArcFil;
			Vector3 position7 = AttachFil1.transform.position;
			float x4 = position7.x;
			Vector3 position8 = AttachFil1.transform.position;
			arcFil4.SetPosition(0, new Vector3(x4, position8.y, -2f));
			LineRenderer arcFil5 = ArcFil;
			Vector3 position9 = AttachFil1.transform.position;
			float x5 = position9.x;
			Vector3 position10 = AttachFil1.transform.position;
			arcFil5.SetPosition(1, new Vector3(x5, position10.y, -2f));
			LineRenderer arcFil6 = ArcFil;
			Vector3 position11 = AttachFil2.transform.position;
			float x6 = position11.x;
			Vector3 position12 = AttachFil2.transform.position;
			arcFil6.SetPosition(2, new Vector3(x6, position12.y, -2f));
			if (direction.magnitude > 0.2f)
			{
				LineRenderer arcFil7 = ArcFil;
				Vector3 position13 = Bras.transform.position;
				float x7 = position13.x;
				Vector3 position14 = Bras.transform.position;
				arcFil7.SetPosition(1, new Vector3(x7, position14.y, -2f));
				LineRenderer arcFil8 = ArcFil;
				Vector3 position15 = AttachFil1.transform.position;
				float x8 = position15.x;
				Vector3 position16 = AttachFil1.transform.position;
				arcFil8.SetPosition(0, new Vector3(x8, position16.y, -2f));
				LineRenderer arcFil9 = ArcFil;
				Vector3 position17 = AttachFil2.transform.position;
				float x9 = position17.x;
				Vector3 position18 = AttachFil2.transform.position;
				arcFil9.SetPosition(2, new Vector3(x9, position18.y, -2f));
			}
		}
	}

	private void FixedUpdate()
	{
		CooldownUlt--;
		CoolDownShoot++;
		Cooldown--;
		timeFirsAtt++;
		if (CooldownUlt == 140)
		{
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
			}
		}
		if (CooldownUlt < 0)
		{
			if (!PlayerOneOrTwo)
			{
				gunsprite.color = new Color(0f, 0.7f, 1f);
			}
			else
			{
				gunsprite.color = new Color(1f, 0f, 0f);
			}
		}
		if (Cooldown <= 190)
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
		if (!PlayerOneOrTwo)
		{
			AvantBras = GameObject.Find("bras 2");
			Bras = GameObject.Find("main 2");
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
		else
		{
			AvantBras = GameObject.Find("bras 2 (3)");
			Bras = GameObject.Find("main 2d");
			if (!DirPlayer.AI)
			{
				direction = rightJoystick.GetInputDirection();
				JoystickOnZero = rightJoystick.IsTouching;
			}
			else
			{
				direction = DirPlayer.direction / 4f;
			}
		}
		direction = direction.normalized;
		rb.AddForce(direction * maniment * Time.fixedDeltaTime);
		if (direction.magnitude != 0f)
		{
			Power = direction;
		}
		if (Cooldown < 50)
		{
		}
		if (Cooldown <= 0 && direction.magnitude > 0.2f)
		{
			SecondBrasDirection = direction;
			SecondBrasDirection.y = SecondBrasDirection.y * 1.5f + 0.3f;
			AvantBras.GetComponent<Rigidbody2D>().AddForce((-direction + new Vector2(0f, 0.2f)) * 300f / 3f, ForceMode2D.Force);
			Bras.GetComponent<Rigidbody2D>().AddForce((direction + new Vector2(0f, 0.4f)) * 100f / 3f, ForceMode2D.Force);
			AvantBras2.GetComponent<Rigidbody2D>().AddForce((direction + new Vector2(0f, 0.4f)) * 100f / 4f, ForceMode2D.Force);
			if (timeFirsAtt <= 100)
			{
			}
		}
		if (CooldownUlt < 0)
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
		if (directionChosen)
		{
			directionChosen = false;
			CooldownUlt = 200;
			gunsprite.color = new Color(0f, 0f, 0f);
			SpriteRenderer[] componentsInChildren2 = PlayerParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer spriteRenderer3 in componentsInChildren2)
			{
				SpriteRenderer spriteRenderer4 = spriteRenderer3;
				Color color4 = spriteRenderer3.color;
				float r2 = color4.r;
				Color color5 = spriteRenderer3.color;
				float g2 = color5.g;
				Color color6 = spriteRenderer3.color;
				spriteRenderer4.color = new Color(r2, g2, color6.b, 0.35f);
				spriteRenderer3.gameObject.layer = 20;
			}
			Corps.GetComponent<Rigidbody2D>().AddForce(Power * dash, ForceMode2D.Impulse);
		}
		if (timeFirsAtt <= 100 || direction.magnitude == 0f)
		{
			return;
		}
		if (CoolDownShoot == 35)
		{
			source.PlayOneShot(PowerAbility);
		}
		if (CoolDownShoot < 50)
		{
			return;
		}
		CoolDownShoot = 0;
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
		Cooldown = 30;
		SuperBullet[num].SetActive(value: false);
		SuperBullet[num].transform.position = base.transform.position;
		SuperBullet[num].transform.rotation = base.transform.rotation;
		SuperBullet[num].transform.Translate(0f, 0.5f, 0f, Space.Self);
		SuperBullet[num].SetActive(value: true);
		BulletSpeed.y = Speed;
		SuperBullet[num].GetComponent<Rigidbody2D>().AddRelativeForce(BulletSpeed * 1.23f, ForceMode2D.Impulse);
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
}
