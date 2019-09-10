using UnityEngine;

public class explsionActiveKnockBack : MonoBehaviour
{
	public GameObject KnockBack;

	private void OnEnable()
	{
		KnockBack.SetActive(value: true);
	}
}
