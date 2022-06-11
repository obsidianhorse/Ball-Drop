using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private GameObject _handCursor;
    [SerializeField] private Vector3 _velocity;


    private bool _isStopped = false;
    private Rigidbody _ballRigidbody;




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && _isStopped == false)
        {
            _handCursor = Instantiate(_handCursor);
            _handCursor.transform.position = (transform.position + new Vector3(2, -2, -2));

            _ballRigidbody = other.gameObject.GetComponent<Rigidbody>();
            _ballRigidbody.isKinematic = true;
            _isStopped = true;
        }
    }


    private void Update()
    {
        if (_isStopped == true && (Input.touches.Length > 0 || Input.anyKeyDown))
        {
            _ballRigidbody.isKinematic = false;
            _ballRigidbody.velocity = _velocity;
            _ballRigidbody.GetComponent<BallJump>().Jump();

            Destroy(gameObject);
            Destroy(_handCursor);

        }
    }
}
