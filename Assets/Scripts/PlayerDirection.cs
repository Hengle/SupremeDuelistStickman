using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
	private GameManager SkinChoose;

	public Vector2 direction;

	public float speed;

	public Rigidbody2D rb;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public bool PlayerOneOrTwo;

	public bool AI;

	public float Devx;

	public float Devy;

	public int PowerWeapon;

	public int Charge;

	public float stunBras;

	public Rigidbody2D RelativeCorpsPoint;

	public int Level;

	public float DirectionHaut;

	public int ColTime;

	public bool AiMaster;

	public int AiSuivrePlayer;

	public int AbilityControl;

	public int timeShield;

	public GameObject Shield;

	public SpriteRenderer AbilityBarre;

	public float lol;

	public int ShieldIntensity;

	public AudioSource source;

	public AudioClip PowerJump;

	public AudioClip PowerBlock;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public bool IsHuman;

	public float PauseCherche;

	public float ability;

	public int R_Cherche;

	public int R_Random;

	public int R_Shield;

	public int R_Jump;

	public int R_Ability;

	public int R_Rienfaire;

	private void Start()
	{
		PauseCherche = 1f;
		ability = 1f;
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		ShieldIntensity = 40;
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (SkinChoose.OnePlayer)
		{
			if (!PlayerOneOrTwo)
			{
				AI = false;
			}
			else
			{
				AI = true;
			}
		}
		else if (!PlayerOneOrTwo)
		{
			AI = false;
		}
		else
		{
			AI = false;
		}
		if (AiMaster)
		{
			AI = true;
		}
		if (AI)
		{
			Level = SkinChoose.AiLevel;
			R_Cherche = Level * 11 + 5;
			R_Random = (9 - Level) * 3;
			R_Shield = Level * 3 + 3;
			R_Jump = Level * 2;
			R_Ability = Level * Level + 15;
			R_Rienfaire = (9 - Level) * 4;
			InvokeRepeating("lul", 0.5f, 0.5f);
		}
	}

	private void FixedUpdate()
	{
		PowerWeapon--;
		stunBras /= 1.4f;
		Charge--;
		if (!AI)
		{
			if (!PlayerOneOrTwo)
			{
				if (!SkinChoose.OnePlayer)
				{
					direction = leftJoystick.GetInputDirection();
				}
				else if (!SkinChoose.LeftUser)
				{
					direction = rightJoystick.GetInputDirection();
				}
				else
				{
					direction = leftJoystick.GetInputDirection();
				}
			}
			else
			{
				direction = rightJoystick.GetInputDirection();
			}
		}
		else if (PowerWeapon < 0)
		{
			if (Charge < 0)
			{
				if (!SkinChoose.TwoPlayerSurvival)
				{
					direction = (GameObject.Find("Corps").transform.position - base.transform.position).normalized;
				}
				else
				{
					if (AiSuivrePlayer == 0)
					{
						direction = (GameObject.Find("Corps").transform.position - base.transform.position).normalized;
					}
					if (AiSuivrePlayer == 1)
					{
						if (!SkinChoose.TwoPlayerSurvival)
						{
							direction = (GameObject.Find("Corps").transform.position - base.transform.position).normalized;
						}
						else
						{
							direction = (GameObject.Find("Corps d").transform.position - base.transform.position).normalized;
						}
					}
				}
			}
		}
		else
		{
			direction = new Vector2(0f, 0f);
		}
		direction = new Vector2(direction.x + Devx, direction.y + Devy);
		direction = direction.normalized * ability;
		if (direction.y > 0f)
		{
			direction.y *= DirectionHaut;
		}
		if (IsHuman)
		{
			if (ColTime > 30)
			{
				if (direction.y > 0.7f)
				{
					if (AbilityBarre != null)
					{
						lol = ((float)AbilityControl + 1f) / 41f;
						AbilityBarre.color = new Color(lol, lol, lol, lol);
						AbilityBarre.transform.localScale = new Vector3(lol * 3f, 0.27f, 1f);
					}
					AbilityControl++;
				}
				else if (direction.y < -0.8f)
				{
					if (AbilityBarre != null)
					{
						lol = ((float)AbilityControl + 1f) / 61f;
						AbilityBarre.color = new Color(lol, lol, lol, lol);
						AbilityBarre.transform.localScale = new Vector3(lol * 3f, 0.27f, 1f);
					}
					AbilityControl++;
				}
				else
				{
					if (AbilityBarre != null)
					{
						AbilityBarre.color = new Color(0f, 0f, 0f, 0f);
						AbilityBarre.transform.localScale = new Vector3(0f, 0f, 0f);
					}
					AbilityControl = 0;
				}
			}
			else
			{
				AbilityControl = 0;
				if (AbilityBarre != null)
				{
					AbilityBarre.color = new Color(0f, 0f, 0f, 0f);
					AbilityBarre.transform.localScale = new Vector3(0f, 0f, 0f);
				}
			}
			if (Shield.gameObject != null && !Shield.gameObject.activeInHierarchy)
			{
				ShieldIntensity++;
				if (ShieldIntensity == 100)
				{
					Shield.GetComponent<DestroyInTime>().timeToDesactive = 140;
					Shield.GetComponent<BouclierAbility>().sizeMax = 6f;
				}
			}
			if (AbilityControl == 45)
			{
				AbilityControl = 0;
				if (AbilityBarre != null)
				{
					AbilityBarre.color = new Color(0f, 0f, 0f, 0f);
					AbilityBarre.transform.localScale = new Vector3(0f, 0f, 0f);
				}
				if (direction.y > 0.7f)
				{
					RelativeCorpsPoint.AddForce(direction * 175f, ForceMode2D.Impulse);
					source.PlayOneShot(PowerJump);
				}
				if (direction.y < -0.8f && Shield.gameObject != null)
				{
					Shield.transform.position = RelativeCorpsPoint.transform.position;
					float num = Shield.GetComponent<DestroyInTime>().timeToDesactive;
					Shield.GetComponent<DestroyInTime>().timeToDesactive = (int)(num / 1.4f);
					Shield.GetComponent<BouclierAbility>().sizeMax = Shield.GetComponent<BouclierAbility>().sizeMax / 1.4f;
					Shield.gameObject.SetActive(value: false);
					Shield.gameObject.SetActive(value: true);
					timeShield = 10;
					ShieldIntensity = 0;
					if (Shield.GetComponent<BouclierAbility>().sizeMax / 6f > 0.2f)
					{
						source.PlayOneShot(PowerBlock, 1f);
					}
				}
			}
			if (timeShield > 0)
			{
				timeShield--;
				if (timeShield != 1)
				{
					RelativeCorpsPoint.velocity = new Vector2(0f, 0f);
				}
			}
		}
		if (ColTime > 0)
		{
			DirectionHaut = 1f;
			ColTime--;
		}
		else
		{
			DirectionHaut = 0f;
		}
		if (stunBras <= 1f)
		{
			rb.MovePosition(rb.position + direction * speed * PauseCherche * Time.fixedDeltaTime);
			ability = 1f;
		}
	}

	private void lul()
	{
		bool flag = false;
		int num = 0;
		if (!IsHuman)
		{
			PowerWeapon = UnityEngine.Random.Range(0, 4);
			if (PowerWeapon != 2)
			{
				Devx = UnityEngine.Random.Range(-0.7f, 0.7f);
				Devy = UnityEngine.Random.Range(-0.7f, 0.7f);
			}
			if (PowerWeapon == 2)
			{
				Devx = 0f;
				Devy = 0f;
				direction = new Vector2(0f, 0f);
				AiSuivrePlayer = UnityEngine.Random.Range(0, 2);
			}
			return;
		}
		flag = false;
		if (Level <= 3)
		{
			R_Ability = 1;
		}
		if (Level <= 6)
		{
			R_Shield = 1;
		}
		int max = R_Cherche + R_Random + R_Shield + R_Jump + R_Rienfaire;
		int num2 = UnityEngine.Random.Range(0, max);
		PauseCherche = 1f;
		ability = 1f;
		if (num2 <= R_Cherche)
		{
			Devx = 0f;
			Devy = 0f;
			flag = true;
		}
		else if (num2 <= R_Cherche + R_Random)
		{
			Devx = UnityEngine.Random.Range(-1f, 1f);
			Devy = UnityEngine.Random.Range(-1f, 1f);
			PauseCherche = 0f;
		}
		else if (num2 <= R_Cherche + R_Random + R_Shield)
		{
			Devy = -30f;
			num = UnityEngine.Random.Range(0, 2);
			if (num == 1)
			{
				flag = true;
			}
		}
		else if (num2 <= R_Cherche + R_Random + R_Shield + R_Jump)
		{
			Devy = 30f;
			num = UnityEngine.Random.Range(0, 2);
			if (num == 1)
			{
				flag = true;
			}
		}
		else if (num2 <= R_Cherche + R_Random + R_Shield + R_Jump + R_Rienfaire)
		{
			PauseCherche = 0f;
		}
		int num3 = UnityEngine.Random.Range(0, 100);
		if (num3 <= R_Ability && Mathf.Abs(Devy) != 30f && flag)
		{
			ability = 0f;
		}
	}
}
