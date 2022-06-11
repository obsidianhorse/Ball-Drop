using UnityEngine;
using UnityEngine.UI;


public class GameSound : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;
    [SerializeField] private Image buttonImage;




    private void Start()
    {
        SetImageOnButton();
    }


    public void SoundOnOff()
    {
        AudioListener.pause = !AudioListener.pause;

        SetImageOnButton();
    }
    private void SetImageOnButton()
    {
        _soundOn.SetActive(!AudioListener.pause);
        _soundOff.SetActive(AudioListener.pause);
    }

}
