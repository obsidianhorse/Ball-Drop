using UnityEngine;

public class BallManager : MonoBehaviour
{
    private static bool _isManaged = true;
    private static Vector3 _gravity = new Vector3(0, -30, 0);
    private static Vector3 _standartGravity = new Vector3(0, -50, 0);






    private void Start()
    {
        ResetGravity();
        Managed = true;
    }


    public static bool Managed
    {
        get { return _isManaged; }
        set { _isManaged = value; }
    }
    public static Vector3 Gravity
    {
        get { return _gravity; }
        set { Physics.gravity = value; }
    }
    public static void ResetGravity()
    {
        Physics.gravity = _standartGravity;
    }
}
