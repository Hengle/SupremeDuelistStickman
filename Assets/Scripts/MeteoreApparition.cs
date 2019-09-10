using System.Collections.Generic;
using UnityEngine;

public class MeteoreApparition : MonoBehaviour
{
	public Vector2 blocPoolPosition = new Vector2(10f, 3f);

	public float fireTime = 10f;

	public GameObject bloc;

	public float MinPosition;

	public float MaxPosition;

	public int pooledAmount = 3;

	public float xpos;

	private List<GameObject> blocs;

	public bool Enable;

	private void Start()
	{
		blocs = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(bloc);
			gameObject.SetActive(value: false);
			blocs.Add(gameObject);
		}
		InvokeRepeating("CreaBlocs", fireTime, fireTime);
	}

	private void CreaBlocs()
	{
		if (!Enable)
		{
			return;
		}
		xpos = UnityEngine.Random.Range(MinPosition, MaxPosition);
		int num = 0;
		while (true)
		{
			if (num < blocs.Count)
			{
				if (!blocs[num].activeInHierarchy)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		Transform transform = blocs[num].transform;
		Vector3 position = base.gameObject.transform.position;
		transform.position = new Vector3(position.x + xpos, 40f, 0f);
		blocs[num].transform.rotation = base.transform.rotation;
		blocs[num].SetActive(value: true);
	}
}
