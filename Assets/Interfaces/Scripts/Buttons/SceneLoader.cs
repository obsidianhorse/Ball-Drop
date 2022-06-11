using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    const int _MaxLevel = 60;




    public void LoadScene(string name)
    {
        InterfaceSoundManager.ClickButton.Play();

        SceneManager.LoadScene(name);
        Background.isChangeBackground = true;

        SetCameraBehaviourOn();
    }
    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex <= _MaxLevel)
        {
            SceneManager.LoadScene(nextSceneIndex);
            SetCameraBehaviourOn();
        }
    }
    public void RestartLevel()
    {
        InterfaceSoundManager.ClickButton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetCameraBehaviourOn()
    {
        CameraEffect.IsPlayAnimation = true;
        Background.isChangeBackground = true;
    }
}
