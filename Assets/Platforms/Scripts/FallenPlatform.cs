using System.Collections;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{
    [SerializeField] private float _timeToFall;
    [SerializeField] private float _timeToDestroy = 10;


    private Rigidbody _rigidbody;
    private const float _IntensivityOfDisapear = 1.5f;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            StartCoroutine(Fall());
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(_timeToFall);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(_timeToDestroy);
        if (GetComponent<Hidden>() == null)
        {
            gameObject.AddComponent<Hidden>();
            gameObject.GetComponent<Hidden>().Hide(_IntensivityOfDisapear);
        }
    }
}
