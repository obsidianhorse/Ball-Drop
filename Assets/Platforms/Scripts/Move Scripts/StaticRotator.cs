using UnityEngine;

public class StaticRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;

    private Transform _transform;





    private void Start()
    {
        GetComponents();
    }
    private void FixedUpdate()
    {
        Rotate();
    }

    private void GetComponents()
    {
        _transform = GetComponent<Transform>();
    }
    private void Rotate()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
    }
    
}
