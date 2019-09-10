using UnityEngine;

public class BombEffector : MonoBehaviour
{
	public GameObject Effet;

	private void Start()
	{
	}

	private void OnEnable()
	{
		Effet.gameObject.SetActive(value: true);
	}
}
