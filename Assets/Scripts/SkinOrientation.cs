using UnityEngine;

public class SkinOrientation : MonoBehaviour
{
	public PlayerDirection dir;

	public SpriteRenderer skin;

	public float orientation;

	public Vector2 direction;

	private void Start()
	{
		skin = base.gameObject.GetComponent<SpriteRenderer>();
		InvokeRepeating("inclineTime", 0.7f, 0.4f);
	}

	private void FixedUpdate()
	{
	}

	private void inclineTime()
	{
		if (dir.direction.magnitude != 0f)
		{
			direction = dir.direction;
		}
		if (direction.x * orientation > 0.1f)
		{
			skin.flipX = false;
		}
		if (direction.x * orientation < 0.1f)
		{
			skin.flipX = true;
		}
	}
}
