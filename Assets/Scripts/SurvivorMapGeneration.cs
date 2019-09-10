using UnityEngine;

public class SurvivorMapGeneration : MonoBehaviour
{
	public GameObject EscalierMonte;

	public GameObject EscalierDescend;

	public GameObject EscalierStable;

	public GameObject Propulseur;

	public GameObject Plateform;

	public int TypeObject;

	public float profond;

	public float escalierHauteur;

	public float escalieStablerHauteur;

	public float separationEntreElement;

	public float separationEntreElement1;

	public float separationEntreElement2;

	public float separationEntreElement3;

	public float separationHauteurElement1;

	public float separationHauteurElement2;

	public float separationHauteurElement3;

	public int NumberReset = 1;

	private void Start()
	{
		TypeObject = 1;
		profond = 6.1f;
		escalierHauteur = 1.5f;
		escalieStablerHauteur = 1.5f;
		separationEntreElement = 17.66f;
		separationEntreElement1 = UnityEngine.Random.Range(-10f, 17.66f);
		separationEntreElement2 = UnityEngine.Random.Range(-10f, 17.66f) + separationEntreElement1 / 2f;
		separationEntreElement3 = UnityEngine.Random.Range(-10f, 17.66f) + separationEntreElement2 / 2f;
		separationHauteurElement1 = 15f;
		separationHauteurElement2 = 30f;
		separationHauteurElement3 = 45f;
		while (separationEntreElement < 240f || TypeObject != 2)
		{
			CreationElement();
		}
		while (separationEntreElement1 < 240f || separationEntreElement2 < 240f || separationEntreElement3 < 240f)
		{
			CreationElementSup();
		}
		skinad[] array = Resources.FindObjectsOfTypeAll<skinad>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].gameObject.GetComponent<Rigidbody2D>() != null)
			{
				array[i].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			}
		}
	}

	private void CreationElement()
	{
		if (TypeObject == 1)
		{
			Object.Instantiate(EscalierMonte, new Vector3(separationEntreElement, escalierHauteur, profond), Quaternion.identity);
			separationEntreElement += 17.66f;
			TypeObject++;
		}
		else if (TypeObject == 2)
		{
			Object.Instantiate(EscalierStable, new Vector3(separationEntreElement, escalierHauteur, profond), Quaternion.identity);
			TypeObject++;
			int num = UnityEngine.Random.Range(0, 6);
			if (num >= 1)
			{
				Object.Instantiate(Propulseur, new Vector3(separationEntreElement + UnityEngine.Random.Range(-10f, 10f), escalierHauteur, profond), new Quaternion(0f, 0f, 1f, 1f));
			}
			separationEntreElement += 17.66f;
		}
		else if (TypeObject == 3)
		{
			Object.Instantiate(EscalierDescend, new Vector3(separationEntreElement, escalierHauteur, profond), Quaternion.identity);
			separationEntreElement += UnityEngine.Random.Range(30, 60);
			TypeObject = 1;
		}
	}

	private void CreationElementSup()
	{
		int num = UnityEngine.Random.Range(0, 3);
		TypeObject = UnityEngine.Random.Range(0, 4);
		if (TypeObject == 1 && separationEntreElement1 < 240f)
		{
			Object.Instantiate(Plateform, new Vector3(separationEntreElement1, separationHauteurElement1, profond), Quaternion.identity);
			if (num != 1)
			{
				Object.Instantiate(Propulseur, new Vector3(separationEntreElement1 + UnityEngine.Random.Range(-10f, 10f), separationHauteurElement1, profond), new Quaternion(0f, 0f, 1f, 1f));
			}
			separationEntreElement1 += UnityEngine.Random.Range(30, 70);
		}
		if (TypeObject == 2 && separationEntreElement2 < 240f)
		{
			Object.Instantiate(Plateform, new Vector3(separationEntreElement2, separationHauteurElement2, profond), Quaternion.identity);
			if (num != 1)
			{
				Object.Instantiate(Propulseur, new Vector3(separationEntreElement2 + UnityEngine.Random.Range(-10f, 10f), separationHauteurElement2, profond), new Quaternion(0f, 0f, 1f, 1f));
			}
			separationEntreElement2 += UnityEngine.Random.Range(30, 70);
		}
		if (TypeObject == 3 && separationEntreElement3 < 240f)
		{
			Object.Instantiate(Plateform, new Vector3(separationEntreElement3, separationHauteurElement3, profond), Quaternion.identity);
			if (num != 1)
			{
				Object.Instantiate(Propulseur, new Vector3(separationEntreElement3 + UnityEngine.Random.Range(-10f, 10f), separationHauteurElement3, profond), new Quaternion(0f, 0f, 1f, 1f));
			}
			separationEntreElement3 += UnityEngine.Random.Range(30, 70);
		}
	}
}
