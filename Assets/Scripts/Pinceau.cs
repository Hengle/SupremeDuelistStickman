using UnityEngine;

public class Pinceau : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

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

	public GameObject PinceauObj;

	public bool IsBlue;

	private PlayerDirection DirPlayer;

	public float speedYoyoPower;

	public float NewAnchorSpeed;

	public bool AvantArriere;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public ParticleSystem TrailBaguette;

	public GameObject Encre;

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
	}

	private void FixedUpdate()
	{
		timeFirsAtt++;
		yoyoPower--;
		Cooldown--;
		rb.AddForce(YoyoMoove * speed * Time.fixedDeltaTime);
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
            ParticleSystem.MainModule main = TrailBaguette.main;
            main.startColor = new Color(1f, 1f, 1f, 0f);
			directionChosen = false;
			Encre.SetActive(value: false);
			Encre.transform.position = base.transform.position;
			Encre.transform.rotation = base.transform.rotation;
			Encre.SetActive(value: true);
			Encre.GetComponent<Rigidbody2D>().AddForce(YoyoPower * 140f, ForceMode2D.Impulse);
			yoyoPower = 30;
			Cooldown = 225;
			ImageIsReady.color = new Color(1f, 1f, 1f);
			source.PlayOneShot(PowerAbility, 0.5f);
		}
		if (Cooldown <= 0)
		{
			if (IsBlue)
			{
                ParticleSystem.MainModule main1 = TrailBaguette.main;
                main1.startColor = new Color(0f, 1f, 1f, 1f);
				ImageIsReady.color = new Color(0f, 1f, 1f);
			}
			else
			{
                ParticleSystem.MainModule main2 = TrailBaguette.main;
                main2.startColor = new Color(1f, 1f, 0f, 1f);
				ImageIsReady.color = new Color(1f, 1f, 0f);
			}
		}
	}
}
