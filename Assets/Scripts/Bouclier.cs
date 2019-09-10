using UnityEngine;

public class Bouclier : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public GameObject Bras;

	public GameObject avantBras;

	public GameObject Corps;

	public float speed;

	public Rigidbody2D rb;

	public Vector2 YoyoMoove;

	public Vector2 YoyoPower;

	public bool PlayerOneOrTwo;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public int yoyoPower;

	public int Cooldown;

	public GameObject YOYO;

	public bool IsBlue;

	private PlayerDirection DirPlayer;

	public float speedYoyoPower;

	public float distance;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public AudioSource source;

	public AudioClip PowerAbility;

	public AudioClip ShockWave;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float realVelocity;

	public int Power;

	public GameObject Shockwave;

	public float maniment;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		Power = UnityEngine.Random.Range(0, 2);
		if (Power == 0)
		{
			if (IsBlue)
			{
				ImageIsReady.color = new Color(0f, 1f, 1f);
			}
			else
			{
				ImageIsReady.color = new Color(1f, 1f, 0f);
			}
		}
		else
		{
			ImageIsReady.color = new Color(1f, 0f, 0f);
		}
	}

	private void FixedUpdate()
	{
		distance = (Bras.transform.position - base.transform.position).magnitude;
		timeFirsAtt++;
		yoyoPower--;
		Cooldown--;
		rb.AddForce(YoyoMoove * maniment * Time.fixedDeltaTime);
		if (!PlayerOneOrTwo)
		{
			if (!SkinChoose.OnePlayer)
			{
				YoyoMoove = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
			else if (!SkinChoose.LeftUser)
			{
				YoyoMoove = rightJoystick.GetInputDirection();
				JoystickOnZero = rightJoystick.IsTouching;
			}
			else
			{
				YoyoMoove = leftJoystick.GetInputDirection();
				JoystickOnZero = leftJoystick.IsTouching;
			}
		}
		else if (!DirPlayer.AI)
		{
			YoyoMoove = rightJoystick.GetInputDirection();
			JoystickOnZero = rightJoystick.IsTouching;
		}
		else
		{
			YoyoMoove = DirPlayer.direction / 4f;
		}
		YoyoMoove = YoyoMoove.normalized;
		if (YoyoMoove.magnitude != 0f && Cooldown < 150)
		{
			YoyoPower = YoyoMoove;
		}
		if (Cooldown <= 0)
		{
			if (YoyoMoove.magnitude > 0.2f && timeFirsAtt > 100)
			{
				PowerhitReady = true;
			}
			if (YoyoMoove.magnitude == 0f && PowerhitReady && !JoystickOnZero)
			{
				directionChosen = true;
				PowerhitReady = false;
			}
		}
		if (directionChosen)
		{
			if (Power == 0)
			{
				source.PlayOneShot(PowerAbility);
				yoyoPower = 30;
				rb.GetComponent<Transform>().localScale = base.transform.localScale * 1.7f;
				rb.drag = 10000f;
			}
			else
			{
				Shockwave.transform.position = base.transform.position;
				Shockwave.transform.rotation = base.transform.rotation;
				Shockwave.transform.Rotate(0f, 0f, -90f, Space.Self);
				Shockwave.SetActive(value: true);
				Shockwave.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, 60f), ForceMode2D.Impulse);
				source.PlayOneShot(ShockWave);
			}
			ImageIsReady.color = new Color(0.7f, 0.7f, 0.7f);
			Cooldown = 200;
			directionChosen = false;
		}
		if (Power == 0)
		{
			if (Cooldown == 120)
			{
				rb.drag = 0f;
				rb.GetComponent<Transform>().localScale = base.transform.localScale / 1.7f;
			}
			if (yoyoPower <= 0)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				Bras.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				avantBras.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				Corps.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			}
			if (Cooldown > 150)
			{
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
				Bras.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
				avantBras.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
				Corps.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
				rb.MovePosition(rb.position + YoyoPower * 40f * Time.fixedDeltaTime);
			}
		}
		if (Cooldown != 0)
		{
			return;
		}
		Power = UnityEngine.Random.Range(0, 2);
		if (Power == 0)
		{
			if (IsBlue)
			{
				ImageIsReady.color = new Color(0f, 1f, 1f);
			}
			else
			{
				ImageIsReady.color = new Color(1f, 1f, 0f);
			}
		}
		else
		{
			ImageIsReady.color = new Color(1f, 0f, 0f);
		}
	}
}
