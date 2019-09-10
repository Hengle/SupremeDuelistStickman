using UnityEngine;

public class Montagne : MonoBehaviour
{
	public float taille;

	public float Maxtaille;

	public bool HasSound;

	public AudioSource source;

	public AudioClip PowerAbility;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	public float rationTaille;

	public float rationGrossi;

	private void Start()
	{
		if (HasSound)
		{
			if (source == null)
			{
				source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
			}
			Manager = GameObject.Find("GameManager");
			gManag = Manager.GetComponent<GameManager>();
		}
	}

	private void OnEnable()
	{
		if (HasSound)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
			source.PlayOneShot(PowerAbility);
		}
	}

	private void FixedUpdate()
	{
		base.transform.localScale = new Vector3(taille / rationTaille, taille, taille);
		taille += Maxtaille - taille / rationGrossi;
	}

	private void OnDisable()
	{
		taille = 0f;
		base.transform.localScale = new Vector3(taille / rationTaille, taille, taille);
	}
}
