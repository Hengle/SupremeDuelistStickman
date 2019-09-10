using UnityEngine;

public class makeview : MonoBehaviour
{
	public float taille;

	public float normaltaille;

	public float Maxtaille;

	public float Mintaille;

	public bool grow;

	public bool newButtonGrwo;

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		taille = localScale.x;
		normaltaille = taille;
		Maxtaille = taille * 1.1f;
		Mintaille = taille / 1.1f;
	}

	private void FixedUpdate()
	{
		if (!newButtonGrwo)
		{
			base.transform.localScale = new Vector3(taille, taille, taille);
		}
		else
		{
			base.transform.localScale = new Vector3(taille, taille / 2f + 0.1f, taille);
		}
		if (grow)
		{
			taille += normaltaille / 150f;
			if (taille > Maxtaille)
			{
				grow = false;
			}
		}
		else
		{
			taille -= normaltaille / 150f;
			if (taille < Mintaille)
			{
				grow = true;
			}
		}
	}
}
