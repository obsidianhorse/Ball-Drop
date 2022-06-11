using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementPointer : MonoBehaviour
{
    [SerializeField] private Transform _pointToMove;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isReturned;
    [SerializeField] private float _timeToGoAway;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private bool _returnFlag = true;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GoAway();
        }
    }

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _pointToMove.position;
    }


    private void GoAway()
    {
        StartCoroutine(GoingAway());
    }
    private IEnumerator GoingAway()
    {
        yield return new WaitForSeconds(_timeToGoAway);

        while (true)
        {
            if (_returnFlag == true)
            {
                ChooseTargetPoint();
            }
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            


            yield return null;
        }
    }
    private void ChooseTargetPoint()
    {
        if (Vector3.Distance(transform.position, _pointToMove.position) <= 1f && _isReturned == true)
        {
            _targetPosition = _startPosition;
            _returnFlag = false;
        }
           
    }
}
