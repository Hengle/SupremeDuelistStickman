using UnityEngine;

public class solidEncre : MonoBehaviour
{
	public float xDim;

	public float yDim;

	public float DimChanger;

	public SpriteRenderer Box;

	public SpriteRenderer barAcier;

	public void Start()
	{
		DimChanger = 0.5f;
	}

	private void FixedUpdate()
	{
		Vector3 localScale = base.gameObject.transform.localScale;
		float num = Mathf.Abs(localScale.x);
		Vector3 localScale2 = base.gameObject.transform.localScale;
		if (Mathf.Abs(num - Mathf.Abs(localScale2.y)) > 0.1f)
		{
			Vector3 localScale3 = base.gameObject.transform.localScale;
			float x = localScale3.x;
			Vector3 localScale4 = base.gameObject.transform.localScale;
			if (x > localScale4.y)
			{
				Vector3 localScale5 = base.gameObject.transform.localScale;
				float x2 = localScale5.x;
				Vector3 localScale6 = base.gameObject.transform.localScale;
				float x3 = localScale6.x;
				Vector3 localScale7 = base.gameObject.transform.localScale;
				xDim = x2 - Mathf.Abs(x3 - localScale7.y) / 4f;
			}
			Vector3 localScale8 = base.gameObject.transform.localScale;
			float x4 = localScale8.x;
			Vector3 localScale9 = base.gameObject.transform.localScale;
			if (x4 < localScale9.y)
			{
				Vector3 localScale10 = base.gameObject.transform.localScale;
				float x5 = localScale10.x;
				Vector3 localScale11 = base.gameObject.transform.localScale;
				float y = localScale11.y;
				Vector3 localScale12 = base.gameObject.transform.localScale;
				xDim = x5 + Mathf.Abs(y - localScale12.x) / 4f;
			}
			Vector3 localScale13 = base.gameObject.transform.localScale;
			float y2 = localScale13.y;
			Vector3 localScale14 = base.gameObject.transform.localScale;
			if (y2 > localScale14.x)
			{
				Vector3 localScale15 = base.gameObject.transform.localScale;
				float y3 = localScale15.y;
				Vector3 localScale16 = base.gameObject.transform.localScale;
				float y4 = localScale16.y;
				Vector3 localScale17 = base.gameObject.transform.localScale;
				yDim = y3 - Mathf.Abs(y4 - localScale17.x) / 4f;
			}
			Vector3 localScale18 = base.gameObject.transform.localScale;
			float y5 = localScale18.y;
			Vector3 localScale19 = base.gameObject.transform.localScale;
			if (y5 < localScale19.x)
			{
				Vector3 localScale20 = base.gameObject.transform.localScale;
				float y6 = localScale20.y;
				Vector3 localScale21 = base.gameObject.transform.localScale;
				float x6 = localScale21.x;
				Vector3 localScale22 = base.gameObject.transform.localScale;
				yDim = y6 + Mathf.Abs(x6 - localScale22.y) / 4f;
			}
		}
		else if (xDim > 5f)
		{
			xDim -= DimChanger;
			yDim = xDim;
		}
		base.gameObject.transform.localScale = new Vector3(xDim, yDim, 1f);
	}
}
