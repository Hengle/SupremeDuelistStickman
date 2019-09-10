using UnityEngine;

public class SCi : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject Montagne;

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

	public Rigidbody2D AutreBras;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public SpriteRenderer symboleUlt;

	public bool isBlue;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float ReculLance;

	public bool StopContinue;

	public Rigidbody2D Corps;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
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
		Bras.AddForce(direction * maniment * Time.fixedDeltaTime);
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
			Cooldown = 220;
			directionChosen = false;
			symboleUlt.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
			Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].gameObject.GetComponent<SCi>() == null)
				{
					Transform transform = componentsInChildren[i].transform;
					Vector3 localScale = componentsInChildren[i].transform.localScale;
					float x = localScale.x;
					Vector3 localScale2 = componentsInChildren[i].transform.localScale;
					float y = localScale2.y * 5f;
					Vector3 localScale3 = componentsInChildren[i].transform.localScale;
					transform.localScale = new Vector3(x, y, localScale3.z);
				}
			}
		}
		if (Cooldown != 135)
		{
			return;
		}
		Transform[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Transform>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (componentsInChildren2[j].gameObject.GetComponent<SCi>() == null)
			{
				Transform transform2 = componentsInChildren2[j].transform;
				Vector3 localScale4 = componentsInChildren2[j].transform.localScale;
				float x2 = localScale4.x;
				Vector3 localScale5 = componentsInChildren2[j].transform.localScale;
				float y2 = localScale5.y / 5f;
				Vector3 localScale6 = componentsInChildren2[j].transform.localScale;
				transform2.localScale = new Vector3(x2, y2, localScale6.z);
			}
		}
	}
}
