using UnityEngine;

public class MenuLight : MonoBehaviour
{
    private Light _light;




    private void Start()
    {
        _light = GetComponent<Light>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        _light.color = Random.ColorHSV(0, 1, 0.2f, 0.5f, 1, 1, 1, 1);
    }
    
}
