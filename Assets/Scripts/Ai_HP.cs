using UnityEngine;

public class Ai_HP : MonoBehaviour
{
	public PlayerDirection MouvementAi;

	public bool HasTouch;

	public Rigidbody2D rb;

	public float angleRot;

	public int time;

	public GameObject yeuxNormal;

	public GameObject yeuxMort;

	public barre JoueurVIe;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating("fixeJoueur", 0.7f, 0.4f);
	}

	private void OnEnable()
	{
		MouvementAi.enabled = true;
		HasTouch = false;
		yeuxMort.SetActive(value: false);
		yeuxNormal.SetActive(value: true);
		if (MouvementAi.speed < 7.5f)
		{
			MouvementAi.speed += 0.5f;
		}
	}

	private void OnDisable()
	{
		time = 3;
		HasTouch = false;
	}

	private void FixedUpdate()
	{
		if (time < 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		UnityEngine.Debug.Log("AI collision");
		if (coll.gameObject.tag == "arme" && !HasTouch)
		{
			HasTouch = true;
			MouvementAi.enabled = false;
			time = 3;
			yeuxMort.SetActive(value: true);
			yeuxNormal.SetActive(value: false);
			if (JoueurVIe.Hp > 0f)
			{
				JoueurVIe.TimeRecord += 1f;
			}
		}
		if (coll.gameObject.layer == 8 && !HasTouch)
		{
			JoueurVIe.Hp -= 0.15f;
			HasTouch = true;
			MouvementAi.enabled = false;
			time = 3;
			yeuxMort.SetActive(value: true);
			yeuxNormal.SetActive(value: false);
		}
	}

	private void fixeJoueur()
	{
		if (!HasTouch)
		{
			float num = Mathf.Atan2(MouvementAi.direction.y, MouvementAi.direction.x) * 57.29578f;
			base.transform.rotation = Quaternion.AngleAxis(num - angleRot, Vector3.forward);
		}
		else
		{
			time--;
		}
	}
}
