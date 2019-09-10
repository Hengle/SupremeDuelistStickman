using UnityEngine;

public class MontagneApp : MonoBehaviour
{
	public GameObject Montagne;

	public GameObject MontagneCollision;

	private void OnCollisionEnter2D(Collision2D coll)
	{
		Montagne.SetActive(value: false);
		Montagne.transform.position = base.transform.position;
		Montagne.SetActive(value: true);
		MontagneCollision.SetActive(value: false);
		MontagneCollision.transform.position = base.transform.position;
		MontagneCollision.transform.rotation = Montagne.transform.rotation;
		MontagneCollision.SetActive(value: true);
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
	}
}
