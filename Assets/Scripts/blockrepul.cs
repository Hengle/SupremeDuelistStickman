using UnityEngine;

public class blockrepul : MonoBehaviour
{
	public SpriteRenderer Bloc;

	public float colorIntensity;

	private void Start()
	{
		Bloc = base.gameObject.GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		if (colorIntensity > 0.1f)
		{
			colorIntensity -= 0.05f;
			Bloc.color = new Color(0f, colorIntensity, 0f);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		colorIntensity = 1f;
		Bloc.color = new Color(0f, colorIntensity, 0f);
	}
}
