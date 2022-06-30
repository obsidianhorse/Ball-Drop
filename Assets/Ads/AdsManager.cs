using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    private static InterstitialAd _interstitialAd;


    private string _gameId = "4746695";
    private static readonly string _winCounter = "WinAdsCounter";
    private static readonly string _loseCounter = "LoseAdsCounter";


    private void Start()
    {
        _interstitialAd = new InterstitialAd();
        Advertisement.Initialize(_gameId);
    }

    public static void ShowInterstitialWinAd()
    {
        PlayerPrefs.SetInt(_winCounter, PlayerPrefs.GetInt(_winCounter) + 1);
        int counter = PlayerPrefs.GetInt(_winCounter);

        if (counter == 2)
        {
            _interstitialAd.ShowAd();
            PlayerPrefs.SetInt(_winCounter, 0);
        }
    }
    public static void ShowInterstitialLoseAd()
    {
        PlayerPrefs.SetInt(_loseCounter, PlayerPrefs.GetInt(_loseCounter) + 1);
        int counter = PlayerPrefs.GetInt(_loseCounter);

        if (counter == 7)
        {
            _interstitialAd.ShowAd();
            PlayerPrefs.SetInt(_loseCounter, 0);
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
