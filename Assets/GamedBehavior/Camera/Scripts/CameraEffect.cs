using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    private static bool _isNeedToPlayAnimation = false;
    private static Animation _animation;





    public static bool IsPlayAnimation
    {
        set {_isNeedToPlayAnimation = value; }
    }


    void Start()
    {
        GetComponents();
        PlayBeginAnimation();
    }


    private void GetComponents()
    {
        _animation = GetComponent<Animation>();
    }
    private void PlayBeginAnimation()
    {
        if (_isNeedToPlayAnimation == true)
        {
            _animation.Play("StartCameraAnimation");
            _isNeedToPlayAnimation = false;
        }
    }
    public static void PlayWinAnimation()
    {
        _animation.Play("WinCameraAnimation");
    }
}
