using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] private float setForceY;
    [SerializeField] private float setForceDirection;

    private static float _forceY;
    private static float _forceDirection;
    private static bool _isGrounded = false;




    private void Start()
    {
        SetFields();
    }

    private void SetFields()
    {
        _forceY = setForceDirection;
        _forceDirection = setForceDirection;
    }

    public static float ForceY
    {
        get { return _forceY; }
        set {  _forceY = value; }
    }
    public static float ForceDirection
    {
        get { return _forceDirection; }
        set { _forceDirection = value; }
    }
    public static bool Grounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }
}
