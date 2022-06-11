using UnityEngine;

public class BallJump : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private Rigidbody _rigidbody;
    private float _xPositionToJumpPoint;
    private float _yPositionToJumpPoint;






    private void OnCollisionEnter(Collision collision)
    {
        

        switch (collision.gameObject.tag)
        {
            case "Platform":
                {
                    if (JumpManager.Grounded == false)
                        BallSoundManager.Land.Play();
                    break;
                }
            case "Sticky":
                {
                    StickyParticleEffect();
                    break;
                }
        }
        JumpManager.Grounded = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        JumpManager.Grounded = true;
        SetJumpPointTo(collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Sticky":
                {
                    StickyParticleEffect();
                    collision.gameObject.GetComponent<Sticky>().Hide();
                    break;
                }
        }
        JumpManager.Grounded = false;
    }


    private void Awake()
    {
        Application.targetFrameRate = 300;
        GetComponents();
    }
    private void Update()
    {
        SetTouch();
        CheckIsOnStickPlatform();
    }

    private void GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void SetTouch()
    {
        bool isReadyToJump = Input.touches.Length > 0 && JumpManager.Grounded == true && BallManager.Managed;

        if (isReadyToJump)
        {
           
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }

        if (Input.GetMouseButtonDown(0) && JumpManager.Grounded == true && BallManager.Managed)
        {
            Jump();
        }
            
    }
    private void CheckIsOnStickPlatform()
    {
        if (GetComponent<FixedJoint>())
        {
            JumpManager.Grounded = true;
        }
    }
    private void SetJumpPointTo(Collision collision)
    {
        JumpManipulator jumpManipulator = collision.gameObject.GetComponent<JumpManipulator>();
        Vector3 pointToJump;

        if (jumpManipulator != null)
        {
            pointToJump = CalculatePointToJump(jumpManipulator.PointJumpTo);
        }
        else
        {
            pointToJump = CalculatePointToJump(collision.contacts[0].normal);
        }

        _xPositionToJumpPoint = pointToJump.x - transform.position.x;
        _yPositionToJumpPoint = pointToJump.y - transform.position.y;

        Debug.DrawLine(transform.position, pointToJump);
    }
    private Vector3 CalculatePointToJump(Vector3 pointPosition)
    {
        Vector3 pointToJump;

        pointToJump = new Vector3(
            transform.position.x + pointPosition.x,
            transform.position.y + pointPosition.y,
            0);

        return pointToJump;
    }

    public void Jump()
    {
        if (GetComponent<FixedJoint>())
        {
            Destroy(GetComponent<FixedJoint>());
        }

        _rigidbody.AddForce(JumpManager.ForceDirection * _xPositionToJumpPoint, JumpManager.ForceY * _yPositionToJumpPoint, 0);

        BallSoundManager.Jump.Play();
        JumpManager.Grounded = false;
    }

    private void StickyParticleEffect()
    {
        Instantiate(_particle, transform.position, Quaternion.identity);
    }

}