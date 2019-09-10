using UnityEngine;

public class waveModulation : MonoBehaviour
{
	public float Mod;

	public bool Grow;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		Mod = localScale.x;
	}

	private void FixedUpdate()
	{
		if (Mod > 0.06f)
		{
			Grow = false;
		}
		if (Mod < 0.02f)
		{
			Grow = true;
		}
		if (Grow)
		{
			Mod += UnityEngine.Random.Range(0f, 0.0001f);
		}
		else
		{
			Mod += UnityEngine.Random.Range(-0.0001f, 0f);
		}
		Transform transform = base.transform;
		float mod = Mod;
		Vector3 localScale = base.transform.localScale;
		transform.localScale = new Vector3(mod, localScale.y, 0f);
	}
}
