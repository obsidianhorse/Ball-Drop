using UnityEngine;

public class Confetti : MonoBehaviour
{
    private ParticleSystemRenderer _renderer;




    private void Start()
    {
        _renderer = GetComponent<ParticleSystemRenderer>();
        SetRandomColor();
    }
    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
    }
}
