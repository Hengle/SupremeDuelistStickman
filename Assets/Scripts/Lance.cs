using UnityEngine;

public class Lance : MonoBehaviour
{
	private GameManager SkinChoose;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public float speed;

	public Rigidbody2D rb;

	public HingeJoint2D JointManche;

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

	public float NewAnchorSpeed;

	public bool AvantArriere;

	public SpriteRenderer ImageIsReady;

	public bool JoystickOnZero;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float realVelocity;

	public bool avant;

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
			directionChosen = false;
			yoyoPower = 30;
			Cooldown = 200;
			ImageIsReady.color = new Color(1f, 1f, 1f);
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
		if (Cooldown > 130)
		{
			if (AvantArriere)
			{
				HingeJoint2D jointManche = JointManche;
				Vector2 anchor = JointManche.anchor;
				jointManche.anchor = new Vector2(0f, anchor.y - NewAnchorSpeed / 1.5f);
				avant = false;
			}
			else
			{
				HingeJoint2D jointManche2 = JointManche;
				Vector2 anchor2 = JointManche.anchor;
				jointManche2.anchor = new Vector2(0f, anchor2.y + NewAnchorSpeed);
				rb.AddForce(YoyoPower * 5f * speed * Time.fixedDeltaTime);
				if (!avant)
				{
					source.PlayOneShot(PowerAbility);
					avant = true;
				}
			}
			Vector2 anchor3 = JointManche.anchor;
			if (anchor3.y > 0.65f)
			{
				AvantArriere = true;
			}
			Vector2 anchor4 = JointManche.anchor;
			if (anchor4.y < -0.1f)
			{
				AvantArriere = false;
			}
		}
		if (Cooldown == 130)
		{
			JointManche.anchor = new Vector2(0f, -0.1f);
			rb.constraints = RigidbodyConstraints2D.None;
		}
		if (Cooldown <= 0)
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
	}
}
