using UnityEngine;

public class Hammer : MonoBehaviour
{
	private GameManager SkinChoose;

	public Vector2 Powerhit;

	public Vector2 direction;

	public int RecupHit;

	public bool PlayerOneOrTwo;

	public Rigidbody2D rbSword;

	public float speed2;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public bool directionChosen;

	public float Propulsion;

	public float PropulsionPower;

	public Color Base;

	public bool zeroAtteintGaz;

	public bool playerPress;

	public GameObject Gaz;

	public LineRenderer SwordCharge;

	private Jambe Jambecode1;

	private Jambe Jambecode2;

	public GameObject Jambe1;

	public GameObject Jambe2;

	public float maniment;

	private PlayerDirection DirPlayer;

	public PointEffector2D KnockBack;

	public CircleCollider2D KnockBackTaille;

	public bool JoystickOnZero;

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
		InvokeRepeating("recupstate", 0.7f, 0.4f);
		Base = SwordCharge.startColor;
		Jambecode1 = Jambe1.GetComponent<Jambe>();
		Jambecode2 = Jambe2.GetComponent<Jambe>();
		SwordCharge.sortingLayerName = "Foreground";
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
		KnockBack.forceMagnitude = 1035f;
		KnockBackTaille.radius = 1.1f;
	}

	private void FixedUpdate()
	{
		Jambecode1.WeaponMoove = Powerhit;
		Jambecode2.WeaponMoove = Powerhit;
		if (!PlayerOneOrTwo)
		{
			if (RecupHit < 30)
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
			else
			{
				direction = Powerhit / 2f;
			}
			if (direction.magnitude != 0f)
			{
				Powerhit = direction * 2f;
			}
		}
		else
		{
			if (RecupHit < 30)
			{
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
			else
			{
				direction = Powerhit / 2f;
			}
			if (direction.magnitude != 0f)
			{
				Powerhit = direction * 2f;
			}
		}
		direction = direction.normalized;
		if (direction.magnitude > 0.2f && timeFirsAtt > 100)
		{
			PowerhitReady = true;
		}
		if (direction.magnitude == 0f && PowerhitReady && !JoystickOnZero)
		{
			directionChosen = true;
			PowerhitReady = false;
		}
		timeFirsAtt++;
		if (Propulsion <= -3.4f && zeroAtteintGaz)
		{
			zeroAtteintGaz = false;
			SwordCharge.startColor = Base;
		}
		if (zeroAtteintGaz)
		{
			Powerhit = new Vector2(0f, 0f);
		}
		if (RecupHit > 0)
		{
			RecupHit--;
			if (Propulsion <= 0f)
			{
				Propulsion += 0.07f;
				SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
				if (Powerhit.x < 0f)
				{
					rbSword.AddRelativeForce(new Vector2(0f, speed2) * Time.fixedDeltaTime);
				}
				if (Powerhit.x > 0f)
				{
					rbSword.AddRelativeForce(new Vector2(0f, 0f - speed2) * Time.fixedDeltaTime);
				}
			}
			else
			{
				Powerhit.x = 0f;
				Powerhit.y = 0f;
				Propulsion = 0f;
				Gaz.SetActive(value: false);
				zeroAtteintGaz = true;
			}
		}
		else
		{
			rbSword.AddForce(direction * maniment * Time.fixedDeltaTime);
		}
		if (!directionChosen)
		{
			return;
		}
		SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
		if (Propulsion <= -3.4f && timeFirsAtt > 100)
		{
			source.PlayOneShot(PowerAbility);
			RecupHit = 100;
			if (Powerhit.x > 0.1f)
			{
				direction.x = 0.12f;
			}
			if (Powerhit.x < -0.1f)
			{
				direction.x = -0.12f;
			}
			Gaz.SetActive(value: true);
			SwordCharge.startColor = new Color(0f, 0f, 0f);
		}
		if (RecupHit < 99)
		{
			direction.x = 0f;
			direction.y = 0f;
		}
		directionChosen = false;
	}

	private void recupstate()
	{
		if (Propulsion > -3.4f)
		{
			Propulsion -= 0.35f;
		}
		else
		{
			Propulsion = -3.4f;
		}
		SwordCharge.SetPosition(1, new Vector3(0f, Propulsion));
	}
}
