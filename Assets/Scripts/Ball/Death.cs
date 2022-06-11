using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _failInterface;
    [SerializeField] private GameObject _popPartialSystem;


    private const int _PaymentForLose = 5;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Lose();
        }
    }

    private void Lose()
    {
        BallSoundManager.Crush.Play();
        SpawnPartialSystem();
        Vibration.Vibrate();
        DisableBall();
        AddMoney();
        ShowLoseInterface();
        AdsManager.ShowInterstitialAd(5);
        Destroy(this);
    }
    private void AddMoney()
    {
        MoneyManager.Money += _PaymentForLose;
    }
    private void DisableBall()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 3);
    }
    private void ShowLoseInterface()
    {
        Instantiate(_failInterface);
        _failInterface.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    private void SpawnPartialSystem()
    {
        Instantiate(_popPartialSystem, transform.position, Quaternion.identity);
    }
}
