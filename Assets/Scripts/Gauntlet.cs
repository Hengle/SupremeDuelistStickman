using UnityEngine;

public class Gauntlet : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject bras;

	public float SecondAngle;

	public bool PlayerOneOrTwo;

	public Vector2 direction;

	public Vector2 power;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public Rigidbody2D rb;

	public float speed;

	public float speedMain;

	public bool directionChosen;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public float Distance;

	public HingeJoint2D BoomGrab;

	private PlayerDirection DirPlayer;

	public bool JoystickOnZero;

	public float Veloce;

	public GameObject AutreMain;

	public GameObject AutreGloves;

	public int UltTime;

	public SpriteRenderer imageGant;

	public SpriteRenderer autreImageGant;

	public int Cooldown;

	public PlayerDirection Directionplayer;

	public GameObject Propulse1;

	public GameObject Propulse2;

	public GameObject PunchJet1;

	public GameObject PunchJet2;

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
		KnockBack.forceMagnitude = 1060f;
		KnockBackTaille.radius = 1.1f;
		BoomGrab.enabled = true;
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
		if (Directionplayer.ColTime > 0)
		{
			AutreMain.GetComponent<Rigidbody2D>().MovePosition(AutreMain.GetComponent<Rigidbody2D>().position + direction * (speedMain / 1.7f) * Time.fixedDeltaTime);
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
		if (direction.magnitude != 0f)
		{
			power = direction;
		}
		if (direction.magnitude > 0.2f && timeFirsAtt > 100 && Cooldown <= 1)
		{
			PowerhitReady = true;
		}
		if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
		{
			directionChosen = true;
			PowerhitReady = false;
			imageGant.color = new Color(0f, 0f, 0f, 1f);
			autreImageGant.color = new Color(0f, 0f, 0f, 1f);
		}
		if (directionChosen)
		{
			source.PlayOneShot(PowerAbility);
			directionChosen = false;
			Cooldown = 240;
			UltTime = 150;
		}
		if (Cooldown > 0)
		{
			Cooldown--;
			if (Cooldown == 1)
			{
				directionChosen = false;
				imageGant.color = new Color(1f, 1f, 1f, 1f);
				autreImageGant.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		if (UltTime > 0)
		{
			UltTime--;
			if (UltTime > 120)
			{
				AutreGloves.GetComponent<Rigidbody2D>().MovePosition(AutreGloves.GetComponent<Rigidbody2D>().position + power * speed * Time.fixedDeltaTime);
				rb.MovePosition(rb.position + power * (speed / 1.2f) * Time.fixedDeltaTime);
				Propulse1.SetActive(value: true);
				Propulse2.SetActive(value: true);
			}
			if (UltTime == 119)
			{
				base.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				base.gameObject.GetComponent<Collider2D>().enabled = false;
				AutreGloves.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				AutreGloves.gameObject.GetComponent<Collider2D>().enabled = false;
				Propulse1.SetActive(value: false);
				Propulse2.SetActive(value: false);
				PunchJet1.SetActive(value: false);
				PunchJet2.SetActive(value: false);
				PunchJet1.transform.position = base.gameObject.transform.position;
				float num = Mathf.Atan2(power.y, power.x) * 57.29578f;
				PunchJet1.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, num + 90f);
				PunchJet1.SetActive(value: true);
				PunchJet1.GetComponent<Rigidbody2D>().AddForce(power * 25f, ForceMode2D.Impulse);
				PunchJet2.transform.position = AutreGloves.gameObject.transform.position;
				float num2 = Mathf.Atan2(power.y, power.x) * 57.29578f;
				PunchJet2.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, num2 + 90f);
				PunchJet2.SetActive(value: true);
				PunchJet2.GetComponent<Rigidbody2D>().AddForce(power * 25f, ForceMode2D.Impulse);
			}
			if (UltTime == 80)
			{
				base.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				base.gameObject.GetComponent<Collider2D>().enabled = true;
				AutreGloves.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				AutreGloves.gameObject.GetComponent<Collider2D>().enabled = true;
			}
		}
	}
}
