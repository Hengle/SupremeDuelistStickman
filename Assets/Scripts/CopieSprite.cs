using UnityEngine;

public class CopieSprite : MonoBehaviour
{
	public SpriteRenderer SpriteCopie;

	private void Start()
	{
	}

	private void Update()
	{
		GetComponent<SpriteRenderer>().enabled = SpriteCopie.enabled;
	}
}
