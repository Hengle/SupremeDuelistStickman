using UnityEngine;

public class electricity : MonoBehaviour
{
	public GameObject PortalFermer;

	public GameObject ParentStick;

	public AudioSource source;

	public AudioClip PowerAbility1;

	private GameManager gManag;

	public GameObject Manager;

	public GameObject Camera;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		ParentStick = coll.transform.parent.gameObject;
		Rigidbody2D[] componentsInChildren = ParentStick.gameObject.GetComponentsInChildren<Rigidbody2D>();
		Collider2D[] componentsInChildren2 = ParentStick.gameObject.GetComponentsInChildren<Collider2D>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			if (coll.gameObject.GetComponent<teleportable>() == null)
			{
				componentsInChildren2[i].enabled = false;
			}
			UnityEngine.Debug.Log("transparent");
		}
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			if (componentsInChildren[j].gameObject.GetComponent<teleportable>() == null)
			{
				if (componentsInChildren[j].gameObject.GetComponent<Pied>() != null)
				{
					componentsInChildren[j].gameObject.GetComponent<Pied>().haut = false;
				}
				componentsInChildren[j].constraints = RigidbodyConstraints2D.FreezeRotation;
				source.PlayOneShot(PowerAbility1);
			}
		}
	}
}
