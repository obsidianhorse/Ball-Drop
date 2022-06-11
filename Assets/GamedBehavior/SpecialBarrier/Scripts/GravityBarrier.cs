using UnityEngine;

public class GravityBarrier : MonoBehaviour
{
    [SerializeField] private Vector2 _gravity;
    [SerializeField] private bool _isStoped;

    private const float _Speed = 3;
    private bool _isAnimate = true;
    private MeshRenderer _meshRenderer;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (_isAnimate)
            {
                ChangeView(1.1f);
                _isAnimate = false;
            }
            else
            {
                ChangeView(1.1f);
            }

            if (_isStoped)
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            BallManager.Gravity = _gravity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            BallManager.ResetGravity();
        }
    }


    private void Awake()
    {
        GetComponents();
    }
    private void GetComponents()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void ChangeView(float koeficient)
    {
        /*Color color = _meshRenderer.material.color * koeficient;
        _meshRenderer.materials[0].color = color;*/
    }
}
