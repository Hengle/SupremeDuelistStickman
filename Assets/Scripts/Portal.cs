using UnityEngine;

public class Portal : MonoBehaviour
{
	public GameObject AutrePortal;

	public GameObject ParentStick;

	public Vector3 DistanceToTeleport;

	public int TimeRecup;

	public int time;

	public int timeToDesactive;

	public int TimeUndoRotation;

	public RigidbodyConstraints2D ContraitePortail;

	public GameObject PortalFermer;

	public AudioSource source;

	public AudioClip PowerAbility1;

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

	private void FixedUpdate()
	{
		PortalFermer.gameObject.SetActive(!AutrePortal.gameObject.activeInHierarchy);
		if (TimeRecup > 0)
		{
			TimeRecup--;
		}
		time++;
		if (time >= timeToDesactive && TimeUndoRotation == 0)
		{
			time = 0;
			base.gameObject.SetActive(value: false);
		}
		if (TimeUndoRotation > 0)
		{
			TimeUndoRotation--;
		}
		if (TimeUndoRotation != 1)
		{
			return;
		}
		Collider2D[] componentsInChildren = ParentStick.gameObject.GetComponentsInChildren<Collider2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
			UnityEngine.Debug.Log("Solide");
		}
		Rigidbody2D[] componentsInChildren2 = ParentStick.gameObject.GetComponentsInChildren<Rigidbody2D>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (componentsInChildren2[j].gameObject.GetComponent<Pied>() != null)
			{
				componentsInChildren2[j].gameObject.GetComponent<Pied>().haut = false;
			}
			if (!GameObject.Find("EndMessage").gameObject.GetComponent<SpriteRenderer>().enabled)
			{
				componentsInChildren2[j].constraints = RigidbodyConstraints2D.None;
			}
			else
			{
				componentsInChildren2[j].constraints = RigidbodyConstraints2D.FreezeAll;
			}
		}
	}

	private void OnEnable()
	{
		TimeRecup = 0;
		if (source == null)
		{
			source = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		}
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		time = 0;
	}

	private void OnDisable()
	{
		TimeRecup = 0;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (TimeRecup != 0 || TimeUndoRotation != 0 || !AutrePortal.gameObject.activeInHierarchy)
		{
			return;
		}
		if (coll.gameObject.GetComponent<teleportable>() != null)
		{
			ref Vector3 distanceToTeleport = ref DistanceToTeleport;
			Vector3 position = AutrePortal.transform.position;
			float x = position.x;
			Vector3 position2 = base.transform.position;
			distanceToTeleport.x = x - position2.x;
			ref Vector3 distanceToTeleport2 = ref DistanceToTeleport;
			Vector3 position3 = AutrePortal.transform.position;
			float y = position3.y;
			Vector3 position4 = base.transform.position;
			distanceToTeleport2.y = y - position4.y;
			ContraitePortail = coll.GetComponent<Rigidbody2D>().constraints;
			coll.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
			coll.GetComponent<Rigidbody2D>().MovePosition(base.transform.position + DistanceToTeleport);
			coll.GetComponent<Rigidbody2D>().constraints = ContraitePortail;
			AutrePortal.GetComponent<Portal>().TimeRecup = 15;
		}
		else
		{
			if (coll.gameObject.layer != 8 && coll.gameObject.layer != 11)
			{
				return;
			}
			TimeRecup = 50;
			AutrePortal.GetComponent<Portal>().TimeRecup = TimeRecup;
			ref Vector3 distanceToTeleport3 = ref DistanceToTeleport;
			Vector3 position5 = AutrePortal.transform.position;
			float x2 = position5.x;
			Vector3 position6 = base.transform.position;
			distanceToTeleport3.x = x2 - position6.x;
			ref Vector3 distanceToTeleport4 = ref DistanceToTeleport;
			Vector3 position7 = AutrePortal.transform.position;
			float y2 = position7.y;
			Vector3 position8 = base.transform.position;
			distanceToTeleport4.y = y2 - position8.y;
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
				Rigidbody2D rigidbody2D = componentsInChildren[j];
				if (componentsInChildren[j].gameObject.GetComponent<teleportable>() == null)
				{
					if (componentsInChildren[j].gameObject.GetComponent<Pied>() != null)
					{
						componentsInChildren[j].gameObject.GetComponent<Pied>().haut = false;
					}
					componentsInChildren[j].constraints = RigidbodyConstraints2D.FreezeRotation;
					rigidbody2D.MovePosition(base.transform.position + DistanceToTeleport);
					source.PlayOneShot(PowerAbility1);
					TimeUndoRotation = 10;
				}
			}
		}
	}
}
