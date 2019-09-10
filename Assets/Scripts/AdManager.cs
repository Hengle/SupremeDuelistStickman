using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdManager : MonoBehaviour
{
	private string appIdGlob = "ca-app-pub-3841085600195478~1433114750";

	private string InterstitialId = "ca-app-pub-3841085600195478/4910584515";

	private string RewardId = "ca-app-pub-3841085600195478/4963909699";

	private InterstitialAd interstitial;

	private BannerView bannerView;

	private RewardBasedVideoAd rewardBasedVideo;

	public bool InitMobilAd;

	public static AdManager Instance
	{
		get;
		set;
	}

	public void Start()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
		}
		else if (Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void InitAd()
	{
		string appId = appIdGlob;
		UnityEngine.Debug.Log("init");
		if (!InitMobilAd)
		{
			MobileAds.Initialize(appId);
			InitMobilAd = true;
		}
		RequestInterstitial();
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		RequestRewardBasedVideo();
		rewardBasedVideo.OnAdClosed += RewardHandleRewardBasedVideoClosed;
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
	}

	private void RequestInterstitial()
	{
		string interstitialId = InterstitialId;
		if (interstitial != null)
		{
			interstitial.Destroy();
		}
		interstitial = new InterstitialAd(interstitialId);
		interstitial.OnAdFailedToLoad += InterstitialHandleOnAdFailedToLoad;
		interstitial.OnAdClosed += InterstitialHandleOnAdClosed;
		interstitial.OnAdLeavingApplication += InterstitialHandleOnAdLeavingApplication;
		if (PlayerPrefs.GetInt("PersoAd", 1) == 1)
		{
			AdRequest request = new AdRequest.Builder().Build();
			interstitial.LoadAd(request);
		}
		else
		{
			AdRequest request2 = new AdRequest.Builder().AddExtra("npa", "1").Build();
			interstitial.LoadAd(request2);
		}
	}

	private void RequestRewardBasedVideo()
	{
		string rewardId = RewardId;
		if (PlayerPrefs.GetInt("PersoAd", 1) == 1)
		{
			AdRequest request = new AdRequest.Builder().Build();
			rewardBasedVideo.LoadAd(request, rewardId);
		}
		else
		{
			AdRequest request2 = new AdRequest.Builder().AddExtra("npa", "1").Build();
			rewardBasedVideo.LoadAd(request2, rewardId);
		}
	}

	public void InterstitialHandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	}

	public void InterstitialHandleOnAdClosed(object sender, EventArgs args)
	{
		if (interstitial != null)
		{
			interstitial.Destroy();
		}
		RequestInterstitial();
	}

	public void InterstitialHandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		if (interstitial != null)
		{
			interstitial.Destroy();
		}
		RequestInterstitial();
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		barre[] array = Resources.FindObjectsOfTypeAll<barre>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].RewardDisplay = true;
		}
	}

	public void RewardHandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		RequestRewardBasedVideo();
	}

	public void ShowVideo()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
	}

	public void ShowBanner()
	{
	}

	public void ShowRewardVideo()
	{
		if (rewardBasedVideo.IsLoaded())
		{
			rewardBasedVideo.Show();
		}
	}
}
