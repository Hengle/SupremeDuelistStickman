using UnityEngine;

public class AdsShowGame : MonoBehaviour
{
	public int chanceAds;

	private GameManager gManag;

	public GameObject Manager;

	private void Start()
	{
		Manager = GameObject.Find("GameManager");
		gManag = Manager.GetComponent<GameManager>();
		if (!gManag.Survival)
		{
			chanceAds = UnityEngine.Random.Range(0, 3);
		}
		else
		{
			chanceAds = 1;
		}
		if (chanceAds == 1)
		{
			AdManager.Instance.ShowVideo();
		}
	}
}
