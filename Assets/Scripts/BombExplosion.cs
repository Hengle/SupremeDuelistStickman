using UnityEngine;

public class BombExplosion : MonoBehaviour
{
	public GameObject Explosion;

	public AudioSource source;

	public AudioClip PowerAbilityEXPLOSE;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer != 10 || coll.transform.tag != "sol")
		{
			base.gameObject.GetComponent<DestroyInTime>().time = base.gameObject.GetComponent<DestroyInTime>().time * 3;
		}
	}

	private void OnDisable()
	{
		if (source != null)
		{
			source.PlayOneShot(PowerAbilityEXPLOSE);
		}
		if (Explosion != null)
		{
			Explosion.transform.position = base.transform.position;
			Explosion.gameObject.SetActive(value: true);
		}
	}
}
