using UnityEngine;

public class appTimeOrCol : MonoBehaviour
{
	public GameObject ObjectApparaitre;

	public int time;

	private void FixedUpdate()
	{
		time++;
		if (time >= 30)
		{
			base.gameObject.SetActive(value: false);
			ObjectApparaitre.SetActive(value: false);
			ObjectApparaitre.transform.position = base.transform.position;
			ObjectApparaitre.SetActive(value: true);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		ObjectApparaitre.SetActive(value: false);
		ObjectApparaitre.transform.position = base.transform.position;
		ObjectApparaitre.SetActive(value: true);
		time = 0;
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		time = 0;
	}
}
