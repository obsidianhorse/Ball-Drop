using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _pointOfExit;
    [SerializeField] private float _timeToTeleport;
    [SerializeField] private bool _isGoesStop;
    [SerializeField] private bool _isDestroiable;
    [SerializeField] private float _timeToDestroy = 0.3f;
    [SerializeField] private int _countTeleportationToDestroy = 1;
    [SerializeField] private Animation[] _animations;

    private Vector3 _velocity = Vector3.zero;
    private int _currentCountOfTeleportation = 0;

    private SpriteRenderer _spriteRendererOfExitPoint;
    private Vector3 _standartScaleOfExitPoint;
    private Color _standartColorOfExitPoint;



    private void OnTriggerEnter(Collider other)
    {
        GameObject collideObject = other.gameObject;
        if (collideObject.tag == "Ball")
        {
            if (_isGoesStop == false)
            {
                _velocity = collideObject.GetComponent<Rigidbody>().velocity;
            }
            StartCoroutine(TeleportBall(collideObject));

            _animations[0].Play("Teleport Animation");
        }
    }


    private void Start()
    {
        _spriteRendererOfExitPoint = _pointOfExit.GetComponent<SpriteRenderer>();
        _standartScaleOfExitPoint = _pointOfExit.localScale;
        _standartColorOfExitPoint = _spriteRendererOfExitPoint.color;
    }


    private IEnumerator TeleportBall(GameObject ball)
    {
        ball.transform.position = new Vector3(-1000, 0, 0);
        _currentCountOfTeleportation++;


        ChangeViewOfOutPoint(_pointOfExit.localScale * 1.3f, randomColor());
        yield return new WaitForSeconds(_timeToTeleport);
        ChangeViewOfOutPoint(_standartScaleOfExitPoint, _standartColorOfExitPoint);


        ball.GetComponent<Rigidbody>().velocity = _velocity;
        
        ball.transform.position = _pointOfExit.position;
        _animations[1].Play("Teleport Animation");


        DestroyTeleport();
    }
    
    private void ChangeViewOfOutPoint(Vector3 scale, Color color)
    {
        _pointOfExit.localScale = scale;
        _spriteRendererOfExitPoint.color = color;
    }
    private Color randomColor()
    {
        return Color.HSVToRGB(Random.value, 1, 1);
    }

    private void DestroyTeleport()
    {
        if (_isDestroiable == true && _currentCountOfTeleportation >= _countTeleportationToDestroy)
        {
            Destroy(getTeleportGameObject(), _timeToDestroy);
        }
    }
    private GameObject getTeleportGameObject()
    {
        return this.transform.parent.transform.parent.transform.parent.gameObject;
    }
}

