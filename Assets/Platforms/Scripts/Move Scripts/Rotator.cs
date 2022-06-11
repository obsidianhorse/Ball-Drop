using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private bool _isInstantly;
    [SerializeField] private bool _isLimited;
    [SerializeField] private float _zRotate;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _timeToRotate;

    private bool _isActive = true;
    private const float _CoeffToSpeedOfRotate = 50;




    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive == true && collision.gameObject.tag == "Ball")
        {
            if (_isInstantly == true)
            {
                StartCoroutine(InstanteRotate());
            }
            else if (_isLimited == true)
            {
                StartCoroutine(LimitedRotating());
            }
            else
            {
                StartCoroutine(Rotating());
            }
            _isActive = false;
        }
    }

    private IEnumerator InstanteRotate()
    {
        yield return new WaitForSeconds(_timeToRotate);

        transform.Rotate(_direction);
    }

    private IEnumerator Rotating()
    {
        yield return new WaitForSeconds(_timeToRotate);

        while (true)
        {
            transform.Rotate(_direction * Time.deltaTime);

            yield return null;
        }
    }
    private IEnumerator LimitedRotating()
    {
        float zRotating = _zRotate;
        yield return new WaitForSeconds(_timeToRotate);

        if (_zRotate > 0)
        {
            while (zRotating > 0)
            {
                zRotating -= CalculateRotation(_speed);
                transform.Rotate(new Vector3(0, 0, CalculateRotation(_speed)));

                yield return null;
            }
        }
        else
        {
            while (zRotating < 0)
            {
                zRotating += CalculateRotation(_speed);
                transform.Rotate(new Vector3(0, 0, CalculateRotation(_speed)) * -1);

                yield return null;
            }
        }
    }
    private float CalculateRotation(float speed)
    {
        return speed * Time.deltaTime * _CoeffToSpeedOfRotate;
    }
}
