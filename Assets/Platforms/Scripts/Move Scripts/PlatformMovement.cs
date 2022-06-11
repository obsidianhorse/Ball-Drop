using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _timeToGoAway;




    private void OnCollisionEnter(Collision collision)
    {
        GoAway();
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
            transform.Translate(_direction * Time.deltaTime);

            yield return null;
        }
    }


}
