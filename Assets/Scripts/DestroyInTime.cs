using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
	public int time;

	public int timeToDesactive;

	private void Start()
	{
	}

	private void OnEnable()
	{
		time = 0;
	}

	private void FixedUpdate()
	{
		time++;
		if (time >= timeToDesactive)
		{
			time = 0;
			base.gameObject.SetActive(value: false);
		}
	}
}
