using UnityEngine;

public class BouclierAbility : MonoBehaviour
{
	public float sizeBase;

	public float sizeMax;

	public float size;

	public float growFactor;

	private float baseSize;

	public bool attackedShield;

	public bool reachMaxSize;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		baseSize = localScale.x;
	}

	private void OnEnable()
	{
		size = baseSize;
		base.transform.localScale = new Vector3(baseSize, baseSize, baseSize);
		attackedShield = false;
		reachMaxSize = false;
	}

	private void FixedUpdate()
	{
		if (size < sizeMax && !attackedShield)
		{
			size += growFactor;
			base.transform.localScale = new Vector3(size, size, size);
		}
		if (size > sizeMax / 1.2f)
		{
			reachMaxSize = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("arme") && reachMaxSize)
		{
			attackedShield = true;
			if (size > 0f)
			{
				size -= 1f;
				base.transform.localScale = new Vector3(size, size, size);
			}
		}
	}
}
