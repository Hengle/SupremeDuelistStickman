using UnityEngine;

public class DistanceCorrection : MonoBehaviour
{
	public Vector2 InitPosition;

	public Quaternion InitRotation;

	private void Start()
	{
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		InitPosition = new Vector2(x, position2.y);
		InitRotation = base.transform.rotation;
	}

	private void OnEnable()
	{
		Vector3 position = base.transform.position;
		float x = position.x;
		Vector3 position2 = base.transform.position;
		InitPosition = new Vector2(x, position2.y);
		InitRotation = base.transform.rotation;
	}

	private void OnDisable()
	{
		base.transform.SetPositionAndRotation(InitPosition, InitRotation);
	}

	private void Update()
	{
	}
}
