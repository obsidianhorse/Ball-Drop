using UnityEngine;

public class Background : MonoBehaviour
{
    private Camera _camera;
    private static Color _backgroundColor = new Color(0,0,255);
    private static bool _isNeedToChangeBackgroundColor = false;





    public static bool isChangeBackground
    {
        set { _isNeedToChangeBackgroundColor = value; }
    }

    private void Start()
    {
        GetComponents();
        ChangeBackgroundColor();
    }

    private void GetComponents()
    {
        _camera = GetComponent<Camera>();
    }
    private void ChangeBackgroundColor()
    {
        if (_isNeedToChangeBackgroundColor)
        {
            _backgroundColor = Random.ColorHSV(0, 1, 0.2f, 0.5f, 1, 1, 1, 1);
        }
        _camera.backgroundColor = _backgroundColor;
        _isNeedToChangeBackgroundColor = false;
    }
}
