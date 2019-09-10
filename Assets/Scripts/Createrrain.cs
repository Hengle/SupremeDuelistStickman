using System.Collections.Generic;
using UnityEngine;

public class Createrrain : MonoBehaviour
{
	public Vector2 blocPoolPosition = new Vector2(10f, 3f);

	public float fireTime = 10f;

	public GameObject bloc;

	public float MinPosition;

	public float MaxPosition;

	public int pooledAmount = 3;

	public float xpos;

	public float ypos;

	public float hauteurObjectmin;

	public float hauteurObjectmax;

	public float TimeDepartBloc = 5f;

	public int mirroir;

	private List<GameObject> blocs;

	private void Start()
	{
		blocs = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(bloc);
			gameObject.SetActive(value: false);
			blocs.Add(gameObject);
		}
		InvokeRepeating("CreaBlocs", TimeDepartBloc, fireTime);
	}

	private void CreaBlocs()
	{
		ypos = UnityEngine.Random.Range(hauteurObjectmin, hauteurObjectmax);
		mirroir = UnityEngine.Random.Range(0, 2);
		xpos = UnityEngine.Random.Range(MinPosition, MaxPosition);
		if (mirroir != 0)
		{
		}
		int num = 0;
		while (true)
		{
			if (num < blocs.Count)
			{
				blocPoolPosition.y = ypos;
				blocPoolPosition.x = xpos;
				if (!blocs[num].activeInHierarchy)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		blocs[num].transform.position = blocPoolPosition;
		blocs[num].transform.rotation = base.transform.rotation;
		blocs[num].SetActive(value: true);
	}
}
