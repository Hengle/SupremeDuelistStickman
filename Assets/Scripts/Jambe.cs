using UnityEngine;

public class Jambe : MonoBehaviour
{
	public JointMotor2D jambe1;

	public GameObject jambe2;

	public Rigidbody2D rb;

	private Jambe autrejambe;

	public float anglejambe;

	public float MaxSpeed;

	public float direction;

	public static bool moove1;

	public float POWER;

	public int state;

	public int time;

	public GameObject DirectionBras;

	private PlayerDirection BrasMove;

	public float revSpeed;

	public bool droitier;

	public GameObject pied;

	public Vector2 WeaponMoove;

	private void Start()
	{
		BrasMove = DirectionBras.GetComponent<PlayerDirection>();
		autrejambe = jambe2.GetComponent<Jambe>();
	}

	private void FixedUpdate()
	{
		HingeJoint2D component = pied.GetComponent<HingeJoint2D>();
		JointAngleLimits2D limits = component.limits;
		HingeJoint2D component2 = base.gameObject.GetComponent<HingeJoint2D>();
		JointMotor2D motor = component2.motor;
		anglejambe = component2.jointAngle;
		rb.MoveRotation(rb.rotation + revSpeed * direction * Time.fixedDeltaTime);
		if (BrasMove.direction.x > 0.1f || WeaponMoove.x > 0.1f)
		{
			limits.min = 0f;
			limits.max = 90f;
			component.limits = limits;
		}
		else if (BrasMove.direction.x < -0.1f || WeaponMoove.x < 0.1f)
		{
			limits.min = -90f;
			limits.max = 0f;
			component.limits = limits;
		}
		if (BrasMove.direction.x == 0f && WeaponMoove.x == 0f)
		{
			if (droitier)
			{
				if (state == 1)
				{
					limits.min = -40f;
					limits.max = 0f;
					component.limits = limits;
				}
				if (state == 2)
				{
					limits.min = 0f;
					limits.max = 40f;
					component.limits = limits;
				}
			}
			if (!droitier)
			{
				if (state == 1)
				{
					limits.min = -40f;
					limits.max = 0f;
					component.limits = limits;
				}
				if (state == 2)
				{
					limits.min = 0f;
					limits.max = 40f;
					component.limits = limits;
				}
			}
		}
		switch (state)
		{
		case 1:
			direction = -1f;
			time++;
			if (time > 2 && autrejambe.state == state)
			{
				if (component2.jointAngle > anglejambe)
				{
					state = 2;
					autrejambe.state = 1;
				}
				else
				{
					state = 1;
					autrejambe.state = 2;
				}
			}
			if ((Mathf.Abs(BrasMove.direction.x) > 0.4f || Mathf.Abs(WeaponMoove.x) > 0.4f) && component2.jointAngle > 45f && autrejambe.anglejambe < -45f)
			{
				state = 2;
				time = 0;
			}
			break;
		case 2:
			direction = 1f;
			time++;
			if (time > 2 && autrejambe.state == state)
			{
				if (component2.jointAngle < anglejambe)
				{
					state = 1;
					autrejambe.state = 2;
				}
				else
				{
					state = 2;
					autrejambe.state = 1;
				}
			}
			if ((Mathf.Abs(BrasMove.direction.x) > 0.4f || Mathf.Abs(WeaponMoove.x) > 0.4f) && component2.jointAngle < -45f && autrejambe.anglejambe > 45f)
			{
				state = 1;
				time = 0;
			}
			break;
		}
	}
}
