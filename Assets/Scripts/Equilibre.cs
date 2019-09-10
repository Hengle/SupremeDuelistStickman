using UnityEngine;

public class Equilibre : MonoBehaviour
{
	public Rigidbody2D rb2D;

	public float revSpeed = 50f;

	public float stun;

	public Rigidbody2D rg;

	public Vector2 jump;

	public GameObject Epel;

	private Equilibre equil;

	public float rot;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		equil = GetComponent<Equilibre>();
	}

	private void FixedUpdate()
	{
		if (stun < 1f)
		{
			rb2D.MoveRotation(rb2D.rotation + revSpeed * Time.fixedDeltaTime);
		}
		else
		{
			stun -= 1f;
			stun /= 1.1f;
		}
		Quaternion rotation = base.transform.rotation;
		rot = rotation.z;
		revSpeed = rot * -5000f;
	}
}
