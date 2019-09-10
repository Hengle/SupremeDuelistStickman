using UnityEngine;

public class SoundMusic : MonoBehaviour
{
	public AudioSource source;

	private GameManager gManag;

	public GameObject Manager;

	public float VolumexD;

	private void Start()
	{
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
	}

	private void Update()
	{
		source.volume = gManag.Volume / VolumexD;
	}
}
