using UnityEngine;




public class Finish : MonoBehaviour
{
    [SerializeField] private int _nextLevel;
    [SerializeField] private int _currentStage;
    [SerializeField] private GameObject _winInterface;


    private const int _PaymentForWin = 10;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //Vibration.Vibrate();
            //Vibration.VibrateNope();

            MoneyManager.Money += _PaymentForWin;
            other.gameObject.SetActive(false);
            SerpentineEffect();
            ShowWinInterface();
            MarkInDBPassedLevel();
            other.GetComponent<Pause>().Hide();
            CameraEffect.PlayWinAnimation();
            AdsManager.ShowInterstitialWinAd();
        }
    }
    private void SerpentineEffect()
    {
        if (Camera.main.GetComponentsInChildren<ParticleSystem>() != null)
        {
            ParticleSystem[] serpantines = Camera.main.GetComponentsInChildren<ParticleSystem>();

            foreach (var item in serpantines)
            {
                item.Play();
            }
        }
    }
    private void ShowWinInterface()
    {
        GameObject winInterface = Instantiate(_winInterface);
        winInterface.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    private void MarkInDBPassedLevel()
    {
        int passedLevels = int.Parse(DataBase.ExecuteQueryWithAnswer($"SELECT Stage{_currentStage}Levels FROM LEVELS;"));

        if (passedLevels < _nextLevel)
        {
            DataBase.ExecuteQueryWithoutAnswer($"UPDATE LEVELS set Stage{_currentStage}Levels = {_nextLevel};");
        }
    }


}
