using UnityEngine;

public class ball : MonoBehaviour
{
	public GameObject shootExplosion;

	public int TimeDestroy;

	public bool IsViolet;

	public bool InstantDestroy;

	private void Start()
	{
	}

	private void OnEnable()
	{
		TimeDestroy = 0;
	}

	private void FixedUpdate()
	{
		TimeDestroy--;
		if (TimeDestroy == 1)
		{
			base.gameObject.SetActive(value: false);
			if (!IsViolet && !shootExplosion.activeInHierarchy)
			{
				shootExplosion.transform.position = base.transform.position;
				shootExplosion.SetActive(value: true);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (TimeDestroy <= 0)
		{
			TimeDestroy = 5;
			if (coll.gameObject.tag == "arme")
			{
				TimeDestroy = 4;
			}
			if (InstantDestroy)
			{
				TimeDestroy = 2;
			}
		}
	}
}
