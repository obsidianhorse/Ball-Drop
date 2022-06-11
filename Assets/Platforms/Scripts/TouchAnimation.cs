using UnityEngine;

public class TouchAnimation : MonoBehaviour
{
    [SerializeField] private Animation _animation;




    private void OnCollisionEnter(Collision collision)
    {
        _animation.Play("BouncedAnimation");
    }
}
