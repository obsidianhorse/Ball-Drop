using UnityEngine;

public class Sticky : MonoBehaviour
{
    [SerializeField] private bool _isHidden = false;




    public void Hide()
    {
        if (_isHidden)
        {
            if (GetComponent<Hidden>() == null)
            {
                gameObject.AddComponent<Hidden>();
                gameObject.GetComponent<Hidden>().Hide(1.0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BallSoundManager.StickyIn.Play();
            if (collision.gameObject.GetComponent<FixedJoint>() == null)
            {
                collision.gameObject.AddComponent<FixedJoint>();
            }
            
            collision.gameObject.GetComponent<FixedJoint>().connectedBody = GetComponent<Rigidbody>();

        }
    }
}
