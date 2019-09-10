using UnityEngine;

public class rebondLaser : MonoBehaviour
{
	public AudioSource source;

	public AudioClip ColisionSound;

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

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.layer == 10 || coll.gameObject.layer == 16)
		{
			source.PlayOneShot(ColisionSound);
		}
	}
}
