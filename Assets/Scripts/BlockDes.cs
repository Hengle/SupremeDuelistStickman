using UnityEngine;

public class BlockDes : MonoBehaviour
{
	public float Hp;

	public SpriteRenderer AppBlock;

	public AudioSource source;

	public AudioClip CoupArme1;

	public AudioClip CoupArme2;

	public AudioClip CoupArme3;

	private GameManager gManag;

	public GameObject Manager;

	public bool Block;

	private void Start()
	{
		Hp = 1f;
		if (Block && source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (!coll.gameObject.CompareTag("arme"))
		{
			return;
		}
		Hp -= 0.06f;
		if (Hp > 0f)
		{
			AppBlock.color = new Color(Hp, Hp, Hp, 1f);
			if (Block)
			{
				if (source == null)
				{
					source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
				}
				int num = UnityEngine.Random.Range(0, 3);
				if (num == 0)
				{
					source.PlayOneShot(CoupArme1, Hp);
				}
				if (num == 1)
				{
					source.PlayOneShot(CoupArme2, Hp);
				}
				if (num == 2)
				{
					source.PlayOneShot(CoupArme3, Hp);
				}
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void OnDisable()
	{
		Hp = 1f;
		AppBlock.color = new Color(Hp, Hp, Hp, 1f);
	}
}
