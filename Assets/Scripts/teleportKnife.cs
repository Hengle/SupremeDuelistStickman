using UnityEngine;

public class teleportKnife : MonoBehaviour
{
	public GameObject Corps;

	public GameObject PointToChange;

	public Vector3 DistanceToTeleport;

	public float xVeloce;

	public float yVeloce;

	public int time;

	public float distance;

	private void OnEnable()
	{
		time = 0;
	}

	private void FixedUpdate()
	{
		time++;
		if (time == 1)
		{
			Collider2D[] componentsInChildren = PointToChange.gameObject.GetComponentsInChildren<Collider2D>();
			foreach (Collider2D collider2D in componentsInChildren)
			{
				if (collider2D.transform.name != "Slice Teleportation")
				{
					collider2D.enabled = false;
				}
			}
		}
		if (time == 8)
		{
			ref Vector3 distanceToTeleport = ref DistanceToTeleport;
			Vector3 position = base.transform.position;
			float x = position.x;
			Vector3 position2 = Corps.transform.position;
			distanceToTeleport.x = x - position2.x;
			ref Vector3 distanceToTeleport2 = ref DistanceToTeleport;
			Vector3 position3 = base.transform.position;
			float y = position3.y;
			Vector3 position4 = Corps.transform.position;
			distanceToTeleport2.y = y - position4.y;
			Rigidbody2D[] componentsInChildren2 = PointToChange.gameObject.GetComponentsInChildren<Rigidbody2D>();
			foreach (Rigidbody2D rigidbody2D in componentsInChildren2)
			{
				rigidbody2D.MovePosition(base.transform.position + DistanceToTeleport / 2f);
			}
		}
		if (time >= 15)
		{
			Collider2D[] componentsInChildren3 = PointToChange.gameObject.GetComponentsInChildren<Collider2D>();
			foreach (Collider2D collider2D2 in componentsInChildren3)
			{
				collider2D2.enabled = true;
			}
			Rigidbody2D[] componentsInChildren4 = PointToChange.gameObject.GetComponentsInChildren<Rigidbody2D>();
			foreach (Rigidbody2D rigidbody2D2 in componentsInChildren4)
			{
				rigidbody2D2.velocity = new Vector2(xVeloce / 1.1f, yVeloce / 1.1f);
			}
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer == 10 && !(coll.transform.tag != "sol"))
		{
		}
	}

	private void OnDisable()
	{
		time = 0;
	}
}
