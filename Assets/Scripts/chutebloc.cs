using UnityEngine;

public class chutebloc : MonoBehaviour
{
	public float time;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		if (time > 0f)
		{
			base.transform.localScale = new Vector3(time, time / 2.96f, time);
			time -= 0.02f;
			if (time < 0.05f)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (time == 0f)
		{
			time = 7.0592f;
		}
	}
}
