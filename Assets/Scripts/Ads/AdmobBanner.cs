using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{

    private BannerView bannerView;
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(appId);
        //MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        Invoke("Clear", 10f);
    }

    private void Clear()
    {
        bannerView.Destroy();
    }
}
