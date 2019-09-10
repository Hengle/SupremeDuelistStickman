using UnityEngine;

public class TransisionScene : MonoBehaviour
{
	public float Transparent;

	public float SpeedTrans;

	public bool Transition;

	private void Start()
	{
		Transition = false;
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
			}
			else
			{
				Transparent = 1f;
			}
			base.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Transparent);
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
			base.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Transparent);
		}
	}
}
