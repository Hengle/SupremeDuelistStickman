using UnityEngine;

public class arrow : MonoBehaviour
{
	public Rigidbody2D rb;

	public float angleRot;

	public bool HasTouch;

	public int TimeDestroy;

	public bool DestroyOnHit;

	public int time;

	public GameObject shootExplosion;

	private void Start()
	{
		rb = base.gameObject.GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		HasTouch = false;
		rb = base.gameObject.GetComponent<Rigidbody2D>();
		TimeDestroy = 0;
	}

	private void FixedUpdate()
	{
		TimeDestroy--;
		if (TimeDestroy == 1)
		{
			base.gameObject.SetActive(value: false);
			rb.constraints = RigidbodyConstraints2D.None;
			if (!shootExplosion.activeInHierarchy)
			{
				shootExplosion.transform.position = base.transform.position;
				shootExplosion.SetActive(value: true);
			}
		}
		if (!HasTouch)
		{
			Vector2 velocity = rb.velocity;
			float y = velocity.y;
			Vector2 velocity2 = rb.velocity;
			float num = Mathf.Atan2(y, velocity2.x) * 57.29578f;
			base.transform.rotation = Quaternion.AngleAxis(num - angleRot, Vector3.forward);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		HasTouch = true;
		if (TimeDestroy <= 0)
		{
			TimeDestroy = 8;
		}
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		if (coll.gameObject.tag == "arme")
		{
		}
		if (coll.gameObject.tag == "sol")
		{
			HasTouch = true;
			if (DestroyOnHit && TimeDestroy <= 0)
			{
				TimeDestroy = 3;
			}
		}
	}
}
