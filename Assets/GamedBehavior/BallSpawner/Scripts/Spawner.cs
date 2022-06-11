using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _gameObjectTargetPoint;
    [SerializeField] private float _speed;

    private Vector3 _startPoint;
    private bool _destroy = false;
    private Vector3 _targetPoint;





    void Start()
    {
        SetTargetPoint();
        SetStartPoint();
    }
    private void FixedUpdate()
    {
        Move();
    }


    private void SetTargetPoint()
    {
        Vector3 targetPoint = _gameObjectTargetPoint.transform.position + new Vector3(0, transform.lossyScale.y, 0);
        _targetPoint = targetPoint;
    }
    private void SetStartPoint()
    {
        _startPoint = transform.position;
    }
    private void Move()
    {

        transform.position = Vector3.Lerp(transform.position, _targetPoint, _speed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, _targetPoint) < 0.2f)
        {
            if (_destroy == true)
            {
                Destroy(gameObject);
            }
            else
            {
                SpawnBall();
                _targetPoint = _startPoint;
            }

            
        }

    }

    private void SpawnBall()
    {
        Instantiate(_ball, _spawnPoint.transform.position, Quaternion.identity);
        _destroy = true;
    }


}
