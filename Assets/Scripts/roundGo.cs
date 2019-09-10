using UnityEngine;

public class roundGo : MonoBehaviour
{
	public Rigidbody2D rb;

	public float turnSpeed;

	public int time;

	public int sens;

	private void Start()
	{
		sens = UnityEngine.Random.Range(-5, 5);
		if (sens > 0)
		{
			turnSpeed *= -1f;
		}
	}

	private void FixedUpdate()
	{
		time++;
		if (time > 150)
		{
			base.transform.Rotate(0f, 0f, turnSpeed, Space.Self);
		}
	}
}
