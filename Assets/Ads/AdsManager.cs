using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    private static InterstitialAd _interstitialAd;


    private string _gameId = "4746695";



    private void Start()
    {
        _interstitialAd = new InterstitialAd();
        Advertisement.Initialize(_gameId);
    }

    public static void ShowInterstitialAd(int probability)
    {
        int number = Random.RandomRange(0, probability);

        if (number == 0)
        {
            _interstitialAd.ShowAd();
        }
    }

    public void OnInitializationComplete()
    {
        _interstitialAd.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
