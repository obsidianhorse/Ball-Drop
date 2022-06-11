using UnityEngine;

public class JumpManipulator : MonoBehaviour
{
    [SerializeField] private Transform _positionOfTargetPoint;
    [SerializeField] private float _forceJump = 0.1f;
    [SerializeField] private GameObject _paintingForShowingWay;

    private Vector3 _pointToJump;
    private GameObject[] _points = new GameObject[20];



    private void OnCollisionEnter(Collision collision)
    {
        DrawWayForJumpPoint();
    }
    private void OnCollisionExit(Collision collision)
    {
        DestroyPoints();
    }


    public Vector3 PointJumpTo
    {
        get
        {
            _pointToJump = CalculatePointToJump();

            return _pointToJump;
        }
    }


    private Vector3 CalculatePointToJump()
    {
        Vector3 pointDirection;

        pointDirection = new Vector3(
            _positionOfTargetPoint.localPosition.x,
            _positionOfTargetPoint.localPosition.y, 0);
        pointDirection *= _forceJump;

        return pointDirection;
    }

    private void DrawWayForJumpPoint()
    {
        const float CoefficientForStartPointPosition = 1.03f;
        const float CoefficientForEndPointPosition = 1.20f;
        Vector3 startPoint, endPoint, tempPoint;

        startPoint = new Vector3(transform.position.x, transform.position.y * CoefficientForStartPointPosition, 0);
        endPoint = new Vector3(_positionOfTargetPoint.position.x, _positionOfTargetPoint.position.y * CoefficientForEndPointPosition, 0);

        int index = 0;
        for (float step = 0; step < 1; step += 0.1f)
        {
            tempPoint = endPoint - startPoint;
            tempPoint = endPoint - (step * tempPoint);
            SpawnPoint(tempPoint, step, index);
            index++;
        }
    }
    private void SpawnPoint(Vector3 tempPoint, float step, int index)
    {
        _points[index] = Instantiate(_paintingForShowingWay, tempPoint, Quaternion.identity);
        _points[index].transform.SetParent(transform);
        _points[index].transform.localRotation = Quaternion.Euler(0, 0, 0);
        _points[index].transform.localScale = new Vector3(
            (step * 3) / transform.lossyScale.x,
            (step * 3) / transform.lossyScale.y, 0);
    }
    private void DestroyPoints()
    {
        foreach (var item in _points)
        {
            Destroy(item);
        }
    }
}
