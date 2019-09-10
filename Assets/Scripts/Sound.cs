using UnityEngine;

public class Sound : MonoBehaviour
{
	public AudioSource source;

	private GameManager gManag;

	public GameObject Manager;

	private void Start()
	{
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
	}

	private void Update()
	{
		source.volume = gManag.Volume;
	}
}
