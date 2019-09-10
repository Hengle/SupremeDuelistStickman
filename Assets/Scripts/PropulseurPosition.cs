using UnityEngine;

public class PropulseurPosition : MonoBehaviour
{
	public int time;

	private void Start()
	{
		time = 200;
	}

	private void FixedUpdate()
	{
		if (time > -4)
		{
			time--;
		}
	}

	private void OnTriggerStay2D(Collider2D coll)
	{
		if (time > 0 && (coll.transform.tag == "sol" || coll.transform.tag == "rebond"))
		{
			base.transform.Translate(new Vector3(0f, 0.5f, 0f), Space.World);
		}
	}
}
