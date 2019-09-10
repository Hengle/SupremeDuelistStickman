using UnityEngine;

public class cameraDualJoystick : MonoBehaviour
{
	private GameManager SkinChoose;

	public Vector3 Zoom;

	public GameObject Joueur;

	public GameObject Joueur2;

	public float xpos;

	public float ypos;

	public float delay;

	public float tailleCamera;

	public float SmouthCamera;

	public Camera cam;

	public float TwoPlayerFocusValue;

	private void Start()
	{
		cam.orthographicSize = tailleCamera;
		SmouthCamera = tailleCamera;
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Update()
	{
		if (!SkinChoose.Survival)
		{
			if (!SkinChoose.OnePlayer)
			{
				Vector3 position = Joueur.transform.position;
				float x = position.x;
				Vector3 position2 = Joueur2.transform.position;
				float num = (x + position2.x) / 2f;
				Vector3 position3 = base.transform.position;
				xpos = (num - position3.x + delay) * 3f;
				Vector3 position4 = Joueur.transform.position;
				float y = position4.y;
				Vector3 position5 = Joueur2.transform.position;
				float num2 = (y + position5.y) / 2f;
				Vector3 position6 = base.transform.position;
				ypos = (num2 - position6.y) * 3f;
				base.transform.Translate(Vector2.right * xpos * Time.deltaTime);
				base.transform.Translate(Vector2.up * ypos * Time.deltaTime);
				Zoom = base.transform.position - Joueur.transform.position;
				Zoom.z = 0f;
				tailleCamera = 11.69f - (16.9f - (Joueur.transform.position - Joueur2.transform.position).magnitude) / 4f;
				cam.orthographicSize = tailleCamera;
			}
			else
			{
				Vector3 position7 = Joueur.transform.position;
				float num3 = position7.x * 5f;
				Vector3 position8 = Joueur2.transform.position;
				float num4 = (num3 + position8.x) / 6f;
				Vector3 position9 = base.transform.position;
				xpos = (num4 - position9.x + delay) * 3f;
				Vector3 position10 = Joueur.transform.position;
				float num5 = position10.y * 5f;
				Vector3 position11 = Joueur2.transform.position;
				float num6 = (num5 + position11.y) / 6f;
				Vector3 position12 = base.transform.position;
				ypos = (num6 - position12.y) * 3f;
				base.transform.Translate(Vector2.right * xpos * Time.deltaTime);
				base.transform.Translate(Vector2.up * ypos * Time.deltaTime);
				Zoom = base.transform.position - Joueur.transform.position;
				Zoom.z = 0f;
				tailleCamera = 11.69f - (16.9f - (Joueur.transform.position - Joueur2.transform.position).magnitude) / 5f;
				cam.orthographicSize = tailleCamera;
			}
		}
		else if (!SkinChoose.TwoPlayerSurvival)
		{
			Vector3 position13 = Joueur.transform.position;
			float x2 = position13.x;
			Vector3 position14 = base.transform.position;
			xpos = (x2 - position14.x + delay) * 3f;
			Vector3 position15 = Joueur.transform.position;
			float y2 = position15.y;
			Vector3 position16 = base.transform.position;
			ypos = (y2 - position16.y) * 3f;
			base.transform.Translate(Vector2.right * xpos * Time.deltaTime);
			base.transform.Translate(Vector2.up * ypos * Time.deltaTime);
			Zoom = base.transform.position - Joueur.transform.position;
			Zoom.z = 0f;
		}
		else
		{
			Vector3 position17 = Joueur.transform.position;
			float x3 = position17.x;
			Vector3 position18 = Joueur2.transform.position;
			float num7 = (x3 + position18.x) / 2f;
			Vector3 position19 = base.transform.position;
			xpos = (num7 - position19.x + delay) * 10f;
			Vector3 position20 = Joueur.transform.position;
			float y3 = position20.y;
			Vector3 position21 = Joueur2.transform.position;
			float num8 = (y3 + position21.y) / 2f;
			Vector3 position22 = base.transform.position;
			ypos = (num8 - position22.y) * 3f;
			base.transform.Translate(Vector2.right * xpos * Time.deltaTime);
			base.transform.Translate(Vector2.up * ypos * Time.deltaTime);
			Zoom = base.transform.position - Joueur.transform.position;
			Zoom.z = 0f;
			tailleCamera = 11.69f - (16.9f - (Joueur.transform.position - Joueur2.transform.position).magnitude) / 10f;
			if (tailleCamera <= TwoPlayerFocusValue)
			{
				tailleCamera = TwoPlayerFocusValue;
			}
			cam.orthographicSize = tailleCamera;
		}
	}
}
