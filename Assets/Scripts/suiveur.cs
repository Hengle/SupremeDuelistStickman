using UnityEngine;

public class suiveur : MonoBehaviour
{
	public GameObject Joueur;

	public float xpos;

	public float ypos;

	public float delay;

	public float speed;

	public bool Player1;

	public bool prefDev;

	private void Start()
	{
		if (prefDev)
		{
			return;
		}
		if (Player1)
		{
			if (GameObject.Find("Tete (3)") != null)
			{
				Joueur = GameObject.Find("Tete (3)");
			}
		}
		else
		{
			Joueur = GameObject.Find("Tete");
		}
	}

	private void FixedUpdate()
	{
		Vector3 position = Joueur.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		xpos = (x - position2.x) * speed;
		Vector3 position3 = Joueur.transform.position;
		float y = position3.y;
		Vector3 position4 = base.transform.position;
		ypos = (y - position4.y + delay) * speed;
		base.transform.Translate(Vector2.right * xpos * Time.deltaTime, Space.World);
		base.transform.Translate(Vector2.up * ypos * Time.deltaTime, Space.World);
	}
}
