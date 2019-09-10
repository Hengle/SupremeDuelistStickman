using UnityEngine;

public class transitionInScene : MonoBehaviour
{
	public float Transparent;

	public float SpeedTrans;

	public bool Transition;

	public bool OneTime;

	private void Start()
	{
		if (!OneTime)
		{
			Transition = false;
		}
		else
		{
			Transition = true;
		}
	}

	private void OnEnable()
	{
		Transition = true;
	}

	private void FixedUpdate()
	{
		if (Transition)
		{
			if (Transparent + SpeedTrans < 1f)
			{
				Transparent += SpeedTrans;
				if (Transparent + SpeedTrans > 0.9f && !OneTime)
				{
					Transition = false;
				}
			}
			else
			{
				Transparent = 1f;
			}
			SpriteRenderer component = base.gameObject.GetComponent<SpriteRenderer>();
			Color color = base.gameObject.GetComponent<SpriteRenderer>().color;
			float r = color.r;
			Color color2 = base.gameObject.GetComponent<SpriteRenderer>().color;
			float g = color2.g;
			Color color3 = base.gameObject.GetComponent<SpriteRenderer>().color;
			component.color = new Color(r, g, color3.b, Transparent);
		}
		else
		{
			if (Transparent - SpeedTrans > 0f)
			{
				Transparent -= SpeedTrans;
			}
			else
			{
				Transparent = 0f;
			}
			SpriteRenderer component2 = base.gameObject.GetComponent<SpriteRenderer>();
			Color color4 = base.gameObject.GetComponent<SpriteRenderer>().color;
			float r2 = color4.r;
			Color color5 = base.gameObject.GetComponent<SpriteRenderer>().color;
			float g2 = color5.g;
			Color color6 = base.gameObject.GetComponent<SpriteRenderer>().color;
			component2.color = new Color(r2, g2, color6.b, Transparent);
		}
	}
}
