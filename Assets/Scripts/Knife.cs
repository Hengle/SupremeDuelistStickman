using UnityEngine;

public class Knife : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public Vector2 YoyoMoove;

	public Vector2 YoyoPower;

	public bool PlayerOneOrTwo;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public int Cooldown;

	public int numberOfUlt;

	public bool IsBlue;

	public LineRenderer TraceKnife;

	private PlayerDirection DirPlayer;

	public int timeSlach;

	public float speedYoyoPower;

	public float distance;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public GameObject SliceKnife;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

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
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		ImageIsReady = GetComponent<SpriteRenderer>();
		KnockBack.forceMagnitude = 1006f;
		KnockBackTaille.radius = 1.2f;
	}

	private void FixedUpdate()
	{
		timeFirsAtt++;
		Cooldown--;
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
			source.PlayOneShot(PowerAbility);
			if (!SliceKnife.gameObject.activeInHierarchy)
			{
				SliceKnife.transform.position = base.gameObject.transform.position;
				SliceKnife.transform.rotation = base.gameObject.transform.rotation;
				SliceKnife.SetActive(value: true);
				SliceKnife.GetComponent<Rigidbody2D>().AddForce(YoyoPower * 50f, ForceMode2D.Impulse);
			}
			directionChosen = false;
			numberOfUlt++;
			Cooldown = 20;
			TraceKnife.gameObject.SetActive(value: true);
			LineRenderer traceKnife = TraceKnife;
			Vector3 position = base.transform.position;
			float x = position.x;
			Vector3 position2 = base.transform.position;
			float y = position2.y;
			Vector3 position3 = base.transform.position;
			traceKnife.SetPosition(0, new Vector3(x, y, position3.z));
			LineRenderer traceKnife2 = TraceKnife;
			Vector3 position4 = base.transform.position;
			float x2 = position4.x;
			Vector3 position5 = base.transform.position;
			float y2 = position5.y;
			Vector3 position6 = base.transform.position;
			traceKnife2.SetPosition(1, new Vector3(x2, y2, position6.z));
			TraceKnife.endWidth = 1f;
			TraceKnife.startWidth = 1f;
			timeSlach = 30;
			if (numberOfUlt == 3)
			{
				ImageIsReady.color = new Color(1f, 1f, 1f);
				Cooldown = 250;
				numberOfUlt = 0;
			}
		}
		if (timeSlach > 0)
		{
			timeSlach--;
			LineRenderer traceKnife3 = TraceKnife;
			Vector3 position7 = base.transform.position;
			float x3 = position7.x;
			Vector3 position8 = base.transform.position;
			float y3 = position8.y;
			Vector3 position9 = base.transform.position;
			traceKnife3.SetPosition(1, new Vector3(x3, y3, position9.z));
		}
		if (TraceKnife.endWidth > 0f)
		{
			TraceKnife.endWidth -= 0.05f;
			TraceKnife.startWidth -= 0.051f;
			if (TraceKnife.startWidth < 0.1f)
			{
				TraceKnife.gameObject.SetActive(value: false);
			}
		}
		if (Cooldown <= 0)
		{
			if (IsBlue)
			{
				base.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f);
				ImageIsReady.color = new Color(0f, 1f, 1f);
			}
			else
			{
				base.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
				ImageIsReady.color = new Color(1f, 1f, 0f);
			}
		}
	}
}
