using System.Collections;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    [SerializeField] private float _timeToChangeAlpha = 0.0f;
    [Range(0.01f, 1f)] [SerializeField] private float _intensivelyOfAlpha = 2.0f;


    private const float _Intensively = 1f;





    public void Hide(float intensivelyOfAlpha)
    {
        StartCoroutine(Disappear(intensivelyOfAlpha * -1));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            StartCoroutine(Disappear(_intensivelyOfAlpha * -1));
        }
    }
    private IEnumerator Disappear(float intensively)
    {
        intensively *= _Intensively;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Color color = GetComponent<MeshRenderer>().material.color;

        yield return new WaitForSeconds(_timeToChangeAlpha);
        
        while (color.a >= 0)
        {
            color.a += intensively * Time.deltaTime;
            meshRenderer.material.color = color;

            if (color.a <= 0.05f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
    }

}
