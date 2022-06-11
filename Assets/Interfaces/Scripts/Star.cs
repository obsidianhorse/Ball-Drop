using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] float _minTimeToStartAnimation, _maxTimeToStartAnimation;

    private Animation _animation;






    private void Start()
    {
        GetComponents();
        PlayStarAnimation();
    }

    private void GetComponents()
    {
        _animation = GetComponent<Animation>();
    }
    private void PlayStarAnimation()
    {
        StartCoroutine(PlayAnimationCorountine());
    }
    IEnumerator PlayAnimationCorountine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTimeToStartAnimation, _maxTimeToStartAnimation));
            _animation.Play();
        }

    }
}
