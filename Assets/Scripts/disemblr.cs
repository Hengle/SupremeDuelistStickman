using UnityEngine;

public class disemblr : MonoBehaviour
{
	public GameObject ParentStick;

	public GameObject EffetLier;

	public AudioSource source;

	public AudioClip PowerAbility;

	public bool Eletric;

	public void Start()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
	}

	private void OnEnable()
	{
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
	}

	private void ElectricChange()
	{
		Rigidbody2D[] componentsInChildren = ParentStick.gameObject.GetComponentsInChildren<Rigidbody2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.GetComponent<teleportable>() == null && componentsInChildren[i].constraints != RigidbodyConstraints2D.FreezePosition)
			{
				componentsInChildren[i].constraints = (componentsInChildren[i].constraints & ~RigidbodyConstraints2D.FreezeRotation);
			}
		}
		Eletric = false;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (Eletric)
		{
			return;
		}
		UnityEngine.Debug.Log("Electric force");
		if ((base.gameObject.layer != 9 || coll.gameObject.layer != 11) && (base.gameObject.layer != 12 || coll.gameObject.layer != 8))
		{
			return;
		}
		ParentStick = coll.transform.parent.gameObject;
		if (EffetLier.gameObject != null)
		{
			EffetLier.gameObject.SetActive(value: true);
		}
		Rigidbody2D[] componentsInChildren = ParentStick.gameObject.GetComponentsInChildren<Rigidbody2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.GetComponent<teleportable>() == null)
			{
				componentsInChildren[i].constraints = (componentsInChildren[i].constraints | RigidbodyConstraints2D.FreezeRotation);
			}
		}
		Eletric = true;
		Invoke("ElectricChange", 1.5f);
		source.PlayOneShot(PowerAbility);
	}
}
