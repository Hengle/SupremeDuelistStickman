using UnityEngine;

public class camerafollow : MonoBehaviour
{
	public GameObject Joueur;

	public float xpos;

	public float ypos;

	public float delay;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		Vector3 position = Joueur.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		xpos = (x - position2.x + delay) * 3f;
		Vector3 position3 = Joueur.transform.position;
		float y = position3.y;
		Vector3 position4 = base.transform.position;
		ypos = (y - position4.y) * 3f;
		base.transform.Translate(Vector2.right * xpos * Time.deltaTime);
		base.transform.Translate(Vector2.up * ypos * Time.deltaTime);
	}
}
