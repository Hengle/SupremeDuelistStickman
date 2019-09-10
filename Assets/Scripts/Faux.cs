using UnityEngine;

public class Faux : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject ObjectEnvoi;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Vector2 direction;

	public Vector2 Power;

	public int timeFirsAtt;

	public int Cooldown;

	public Rigidbody2D rb;

	public bool PlayerOneOrTwo;

	public bool PowerhitReady;

	public bool directionChosen;

	public float maniment;

	public Rigidbody2D Bras;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public SpriteRenderer symboleUlt;

	public bool isBlue;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float masseCopy;

	public bool StopContinue;

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
		if (isBlue)
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
		}
		else
		{
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
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
			if (direction.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
			if (isBlue)
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
			}
			else
			{
				symboleUlt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
			}
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			Cooldown = 370;
			directionChosen = false;
			ObjectEnvoi.transform.position = base.transform.position;
			ObjectEnvoi.transform.rotation = base.transform.rotation;
			ObjectEnvoi.gameObject.SetActive(value: true);
			ObjectEnvoi.GetComponent<CircleCollider2D>().radius = 15f;
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
			SpriteRenderer[] componentsInChildren = PlayerParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].gameObject.tag != "arme")
				{
					SpriteRenderer spriteRenderer = componentsInChildren[i];
					SpriteRenderer spriteRenderer2 = spriteRenderer;
					Color color = spriteRenderer.color;
					float r = color.r;
					Color color2 = spriteRenderer.color;
					float g = color2.g;
					Color color3 = spriteRenderer.color;
					spriteRenderer2.color = new Color(r, g, color3.b, 0.35f);
					spriteRenderer.gameObject.layer = 20;
				}
			}
		}
		if (Cooldown > 270)
		{
			ObjectEnvoi.GetComponent<CircleCollider2D>().radius = ObjectEnvoi.GetComponent<CircleCollider2D>().radius - 0.16f;
			ObjectEnvoi.transform.position = base.gameObject.transform.position;
		}
		if (Cooldown != 320)
		{
			return;
		}
		SpriteRenderer[] componentsInChildren2 = PlayerParent.gameObject.GetComponentsInChildren<SpriteRenderer>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (componentsInChildren2[j].gameObject.tag != "arme")
			{
				SpriteRenderer spriteRenderer3 = componentsInChildren2[j];
				SpriteRenderer spriteRenderer4 = spriteRenderer3;
				Color color4 = spriteRenderer3.color;
				float r2 = color4.r;
				Color color5 = spriteRenderer3.color;
				float g2 = color5.g;
				Color color6 = spriteRenderer3.color;
				spriteRenderer4.color = new Color(r2, g2, color6.b, 1f);
				if (!PlayerOneOrTwo)
				{
					spriteRenderer3.gameObject.layer = 8;
				}
				else if (!gManag.TwoPlayerSurvival)
				{
					spriteRenderer3.gameObject.layer = 11;
				}
				else
				{
					spriteRenderer3.gameObject.layer = 8;
				}
			}
		}
	}
}
