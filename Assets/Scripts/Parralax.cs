using UnityEngine;

public class Parralax : MonoBehaviour
{
	public GameObject Camera;

	public LineRenderer Background;

	public Vector2 ActualCamPos;

	public Vector2 PastCamPos;

	public float Speed;

	public bool AdaptColor;

	private void Start()
	{
		Invoke("Colorisation", 0.04f);
		Camera = GameObject.Find("Main Camera");
	}

	private void FixedUpdate()
	{
		PastCamPos = ActualCamPos;
		ActualCamPos = Camera.transform.position;
		base.transform.Translate((PastCamPos - ActualCamPos) * Speed * Time.deltaTime, Space.World);
	}

	private void Colorisation()
	{
		if (AdaptColor)
		{
			GetComponent<SpriteRenderer>().color = Background.startColor;
		}
	}
}
