using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsBanner : MonoBehaviour
{
    private string _placementId = "Banner_Android";






    private void Start()
    {
        StartCoroutine(ShowBannerWhenInitioalized());
    }   


    private IEnumerator ShowBannerWhenInitioalized()
    {
        while (Advertisement.isInitialized == false)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(_placementId);
    }
    
}
