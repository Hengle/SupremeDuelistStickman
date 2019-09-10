using UnityEngine;

public class Pied : MonoBehaviour
{
	public Rigidbody2D rg;

	public Rigidbody2D rgPied;

	public Vector2 jump;

	public bool haut;

	public float puissanceJump;

	public bool IsPlayer;

	public PlayerDirection DirectionJoueur;

	public int TimeControll;

	private void Start()
	{
		rgPied = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (haut)
		{
			rg.MovePosition(rg.position + jump * Time.fixedDeltaTime);
		}
		TimeControll++;
		if (TimeControll > 100)
		{
			haut = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("sol"))
		{
			TimeControll = 0;
			jump.y = 5.5f + puissanceJump;
			haut = true;
			DirectionJoueur.ColTime = 100;
		}
		if (coll.gameObject.CompareTag("rebond"))
		{
			TimeControll = 0;
			jump.y = 25f;
			haut = true;
			DirectionJoueur.ColTime = 100;
		}
	}

	private void OnCollisionExit2D(Collision2D coll)
	{
		haut = false;
		if (coll.gameObject.CompareTag("sol"))
		{
			DirectionJoueur.ColTime = 100;
		}
		if (coll.gameObject.CompareTag("rebond"))
		{
			DirectionJoueur.ColTime = 100;
		}
	}
}
