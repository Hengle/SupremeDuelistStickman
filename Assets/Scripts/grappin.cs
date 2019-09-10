using UnityEngine;

public class grappin : MonoBehaviour
{
	private GameManager SkinChoose;

	public GameObject bras;

	public float SecondAngle;

	public bool PlayerOneOrTwo;

	public Vector2 direction;

	public Vector2 power;

	public LeftJoystick leftJoystick;

	public RightJoystick rightJoystick;

	public LineRenderer filDuGrappin;

	public Rigidbody2D rb;

	public float speed;

	public float shoot;

	public bool directionChosen;

	public int Cooldown;

	public int timeFirsAtt;

	public bool PowerhitReady;

	public float Distance;

	public GameObject GrabStatic;

	public GameObject GrabShoot;

	public int GrabCount;

	public bool isGrab;

	public bool Eloi;

	public int timeGrab;

	public float maniment;

	private PlayerDirection DirPlayer;

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
		rb = GetComponent<Rigidbody2D>();
		GrabShoot.GetComponent<Collider2D>().enabled = false;
		GrabShoot.GetComponent<SpriteRenderer>().enabled = false;
		filDuGrappin.gameObject.SetActive(value: false);
		GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		isGrab = true;
		if (PlayerOneOrTwo)
		{
			DirPlayer = GameObject.Find("bout2").GetComponent<PlayerDirection>();
		}
	}

	private void FixedUpdate()
	{
		Cooldown--;
		timeFirsAtt++;
		LineRenderer lineRenderer = filDuGrappin;
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		lineRenderer.SetPosition(0, new Vector3(x, position2.y, -2f));
		LineRenderer lineRenderer2 = filDuGrappin;
		Vector3 position3 = bras.transform.position;
		float x2 = position3.x;
		Vector3 position4 = bras.transform.position;
		lineRenderer2.SetPosition(1, new Vector3(x2, position4.y, -2f));
		Distance = (bras.transform.position - base.transform.position).magnitude;
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
		rb.AddForce(direction * speed * Time.deltaTime);
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
		}
		if (directionChosen)
		{
			if (isGrab)
			{
				timeGrab = 60;
				source.PlayOneShot(PowerAbility);
				directionChosen = false;
				rb.drag = 0f;
				rb.angularDrag = 1f;
				LineRenderer lineRenderer3 = filDuGrappin;
				Vector3 position5 = base.transform.position;
				float x3 = position5.x;
				Vector3 position6 = base.transform.position;
				lineRenderer3.SetPosition(0, new Vector3(x3, position6.y, -2f));
				LineRenderer lineRenderer4 = filDuGrappin;
				Vector3 position7 = base.transform.position;
				float x4 = position7.x;
				Vector3 position8 = base.transform.position;
				lineRenderer4.SetPosition(1, new Vector3(x4, position8.y, -2f));
				GrabStatic.GetComponent<Collider2D>().enabled = false;
				GrabStatic.GetComponent<SpriteRenderer>().enabled = false;
				GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
				GrabShoot.GetComponent<Collider2D>().enabled = true;
				GrabShoot.GetComponent<SpriteRenderer>().enabled = true;
				GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				GrabShoot.transform.position = GrabStatic.transform.position;
				GrabShoot.transform.rotation = GrabStatic.transform.rotation;
				rb.AddForce(power * shoot * 1.2f, ForceMode2D.Impulse);
				filDuGrappin.gameObject.SetActive(value: true);
			}
			isGrab = false;
		}
		GrabCount--;
		if (GrabCount > 0)
		{
			if (!isGrab)
			{
				Rigidbody2D component = bras.GetComponent<Rigidbody2D>();
				Vector2 position9 = bras.GetComponent<Rigidbody2D>().position;
				Vector3 position10 = bras.transform.position;
				float x5 = position10.x;
				Vector3 position11 = base.transform.position;
				float x6 = x5 - position11.x;
				Vector3 position12 = bras.transform.position;
				float y = position12.y;
				Vector3 position13 = base.transform.position;
				Vector2 vector = new Vector2(x6, y - position13.y);
				component.MovePosition(position9 + vector.normalized * speed * Mathf.Log(Distance) * Time.fixedDeltaTime);
				if (Distance > 5f)
				{
					Rigidbody2D rigidbody2D = rb;
					Vector2 position14 = rb.position;
					Vector3 position15 = bras.transform.position;
					float x7 = position15.x;
					Vector3 position16 = base.transform.position;
					float x8 = x7 - position16.x;
					Vector3 position17 = bras.transform.position;
					float y2 = position17.y;
					Vector3 position18 = base.transform.position;
					Vector2 vector2 = new Vector2(x8, y2 - position18.y);
					rigidbody2D.MovePosition(position14 + vector2.normalized * ((0f - speed) / 4f) * Time.fixedDeltaTime);
				}
			}
			if (Distance < 2f)
			{
				GrabStatic.GetComponent<Collider2D>().enabled = true;
				GrabStatic.GetComponent<SpriteRenderer>().enabled = true;
				GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
				GrabShoot.GetComponent<Collider2D>().enabled = false;
				GrabShoot.GetComponent<SpriteRenderer>().enabled = false;
				LineRenderer lineRenderer5 = filDuGrappin;
				Vector3 position19 = base.transform.position;
				float x9 = position19.x;
				Vector3 position20 = base.transform.position;
				lineRenderer5.SetPosition(0, new Vector3(x9, position20.y, -2f));
				LineRenderer lineRenderer6 = filDuGrappin;
				Vector3 position21 = base.transform.position;
				float x10 = position21.x;
				Vector3 position22 = base.transform.position;
				lineRenderer6.SetPosition(1, new Vector3(x10, position22.y, -2f));
				filDuGrappin.gameObject.SetActive(value: false);
				isGrab = true;
				GrabCount = 0;
			}
		}
		else
		{
			GrabStatic.GetComponent<Rigidbody2D>().AddForce(direction * maniment * Time.fixedDeltaTime);
		}
		if (timeGrab > 0)
		{
			timeGrab--;
		}
		if (timeGrab == 1)
		{
			if (directionChosen)
			{
				directionChosen = false;
				base.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			}
			GrabStatic.GetComponent<Collider2D>().enabled = true;
			GrabStatic.GetComponent<SpriteRenderer>().enabled = true;
			GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			GrabShoot.GetComponent<Collider2D>().enabled = false;
			GrabShoot.GetComponent<SpriteRenderer>().enabled = false;
			filDuGrappin.gameObject.SetActive(value: false);
			isGrab = true;
			GrabCount = 0;
			LineRenderer lineRenderer7 = filDuGrappin;
			Vector3 position23 = base.transform.position;
			float x11 = position23.x;
			Vector3 position24 = base.transform.position;
			lineRenderer7.SetPosition(0, new Vector3(x11, position24.y, -2f));
			LineRenderer lineRenderer8 = filDuGrappin;
			Vector3 position25 = base.transform.position;
			float x12 = position25.x;
			Vector3 position26 = base.transform.position;
			lineRenderer8.SetPosition(1, new Vector3(x12, position26.y, -2f));
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.tag == "mur" || coll.transform.tag == "rebond" || coll.transform.tag == "sol" || coll.transform.tag == "arme" || coll.transform.tag == "blue" || coll.transform.tag == "red" || coll.gameObject.layer == 11 || coll.gameObject.layer == 8 || coll.gameObject.layer == 16)
		{
			timeGrab = 200;
			if (GrabCount < 0)
			{
				GrabCount = 100 * Mathf.RoundToInt(Distance);
				rb.drag = 100f;
				rb.angularDrag = 50f;
			}
			LineRenderer lineRenderer = filDuGrappin;
			Vector3 position = base.transform.position;
			float x = position.x;
			Vector3 position2 = base.transform.position;
			lineRenderer.SetPosition(0, new Vector3(x, position2.y, -2f));
			LineRenderer lineRenderer2 = filDuGrappin;
			Vector3 position3 = base.transform.position;
			float x2 = position3.x;
			Vector3 position4 = base.transform.position;
			lineRenderer2.SetPosition(1, new Vector3(x2, position4.y, -2f));
		}
		if (coll.transform.tag == "Untagged")
		{
			if (directionChosen)
			{
				directionChosen = false;
				base.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			}
			GrabStatic.GetComponent<Collider2D>().enabled = true;
			GrabStatic.GetComponent<SpriteRenderer>().enabled = true;
			GrabShoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			GrabShoot.GetComponent<Collider2D>().enabled = false;
			GrabShoot.GetComponent<SpriteRenderer>().enabled = false;
			filDuGrappin.gameObject.SetActive(value: false);
			isGrab = true;
			GrabCount = 0;
			LineRenderer lineRenderer3 = filDuGrappin;
			Vector3 position5 = base.transform.position;
			float x3 = position5.x;
			Vector3 position6 = base.transform.position;
			lineRenderer3.SetPosition(0, new Vector3(x3, position6.y, -2f));
			LineRenderer lineRenderer4 = filDuGrappin;
			Vector3 position7 = base.transform.position;
			float x4 = position7.x;
			Vector3 position8 = base.transform.position;
			lineRenderer4.SetPosition(1, new Vector3(x4, position8.y, -2f));
		}
	}
}
