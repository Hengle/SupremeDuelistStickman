using UnityEngine;

public class ColideResetJump : MonoBehaviour
{
	public bool mutation;

	public GameObject Stickman;

	private void Start()
	{
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if ((coll.gameObject.layer == 9 || coll.gameObject.layer == 11) && mutation)
		{
			mutation = false;
			Stickman = coll.gameObject;
			Bigger();
		}
	}

	public void Bigger()
	{
		base.gameObject.SetActive(value: false);
		float num = 0f;
		num = 1.3f;
		Rigidbody2D[] componentsInChildren = Stickman.transform.parent.GetComponentsInChildren<Rigidbody2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!Stickman.CompareTag("tete"))
			{
				Transform transform = componentsInChildren[i].gameObject.transform;
				Vector3 localScale = componentsInChildren[i].gameObject.transform.localScale;
				float x = localScale.x * num;
				Vector3 localScale2 = componentsInChildren[i].gameObject.transform.localScale;
				float y = localScale2.y * num;
				Vector3 localScale3 = componentsInChildren[i].gameObject.transform.localScale;
				transform.localScale = new Vector3(x, y, localScale3.z);
			}
			else
			{
				Transform transform2 = componentsInChildren[i].gameObject.transform;
				Vector3 localScale4 = componentsInChildren[i].gameObject.transform.localScale;
				float x2 = localScale4.x * num;
				Vector3 localScale5 = componentsInChildren[i].gameObject.transform.localScale;
				float y2 = localScale5.y * num;
				Vector3 localScale6 = componentsInChildren[i].gameObject.transform.localScale;
				transform2.localScale = new Vector3(x2, y2, localScale6.z);
			}
		}
	}
}
