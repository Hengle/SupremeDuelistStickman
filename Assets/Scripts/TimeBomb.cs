using UnityEngine;

public class TimeBomb : MonoBehaviour
{
	public GameObject Explosion;

	public GameObject TimeBombe;

	public int timeToActivate;

	public Rigidbody2D rb;

	public AudioSource source;

	public AudioClip PowerAbility;

	private void Start()
	{
		timeToActivate = UnityEngine.Random.Range(25, 30);
		InvokeRepeating("Bommbedelay", 0.1f, 1f);
		rb = GetComponent<Rigidbody2D>();
		source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
	}

	private void Bommbedelay()
	{
		if (timeToActivate == 0)
		{
			if (!GameObject.Find("EndMessage").GetComponent<SpriteRenderer>().enabled)
			{
				Explosion.SetActive(value: true);
				source.PlayOneShot(PowerAbility);
			}
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			TimeBombe.GetComponent<TextMesh>().text = string.Empty;
			base.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			timeToActivate--;
			TimeBombe.GetComponent<TextMesh>().text = timeToActivate.ToString();
		}
	}
}
