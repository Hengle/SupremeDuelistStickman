using UnityEngine;

public class GareManager : MonoBehaviour
{
	public GameObject Train1;

	public GameObject Train2;

	public GameObject AlarmeHaut;

	public GameObject AlarmeBas;

	private void Start()
	{
	}

	private void Update()
	{
		Vector3 position = Train1.transform.position;
		if (Mathf.Abs(position.x) <= 80f)
		{
			AlarmeHaut.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.3f);
		}
		else
		{
			AlarmeHaut.GetComponent<SpriteRenderer>().color = new Color(0f, 0.2f, 0f, 0.3f);
		}
		Vector3 position2 = Train2.transform.position;
		if (Mathf.Abs(position2.x) <= 80f)
		{
			AlarmeBas.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.3f);
		}
		else
		{
			AlarmeBas.GetComponent<SpriteRenderer>().color = new Color(0f, 0.2f, 0f, 0.3f);
		}
	}
}
